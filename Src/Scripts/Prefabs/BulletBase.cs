using System;
using AcidWallStudio.AcidNodes;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;

public partial class BulletBase : Node2D
{
    [Export] private HitBox _hitBox;

    public Actor Target;
    
    public Action<float> OnMove;
    public event Action<Actor> OnHit;
    
    public bool IsPlayer = false;
    
    public float Speed = 1300f;
    public float Size = 1f;
    public float Degeneration = 0.8f;
    public int CanPenetrate = 0;

    protected Vector2 Velocity = Vector2.Zero;

    public float Damage
    {
        get => _damage.Value;
        set
        {
            _damage.BaseValue = value;
            _hitBox.Damage = value;
        }
    }

    protected Stat _damage = new Stat(1f);
    protected Vector2 LastPosition = new Vector2();
    public Vector2 Direction = Vector2.Right;

    public float Steering;
    protected Node2D TargetingActor;
    protected Vector2 Acceleration = Vector2.Zero;

    protected void TakeOnHitEvent(Actor obj)
    {
        OnHit?.Invoke(obj);
    }

    public override void _Ready()
    {
        Velocity = Direction * Speed;
        Rotation = Direction.Angle();
        
        _hitBox.SetIsPlayer(IsPlayer);
        _hitBox.OnHit += OnHitHandle;
        _hitBox.OnHitOthers += OnHitOthersHandle;

        Scale = new Vector2(Size, Size);
        Degenerate();

        if (Steering > 0)
        {
            TargetingActor = Wizard.GetClosestTarget(this, IsPlayer ? "Mobs" : "Players");
        }
    }

    protected virtual void OnHitOthersHandle()
    {
        QueueFree();
    }

    protected virtual void OnHitHandle(Actor actor)
    {
        SoundManager.PlayOneShotById("event:/OnBulletHit");
        OnHit?.Invoke(actor);
        if (CanPenetrate > 0)
        {
            CanPenetrate--;
            if (CanPenetrate == 0)
            {
                QueueFree();
            }
        }
        QueueFree();
    }

    private Vector2 Seek()
    {
        if (!IsInstanceValid(TargetingActor)) return Vector2.Zero;
        var desired = GlobalPosition.DirectionTo(TargetingActor.GlobalPosition) * Speed;
        return (desired - Velocity).Normalized() * Steering;
    }

    protected virtual void Degenerate()
    {
        Tween tween = CreateTween();
        tween.TweenProperty(this, "scale", Vector2.Zero, Degeneration);
        tween.Finished += QueueFree;
    }

    public void AddModifierToDamage(StatModifier modifier)
    {
        _damage.AddModifier(modifier);
        _hitBox.Damage = _damage.Value;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move(delta);
    }

    protected virtual void Move(double delta)
    {
        OnMove?.Invoke(GlobalPosition.DistanceTo(LastPosition));

        Acceleration += Seek();
        
        Velocity += Acceleration * (float)delta;
        Velocity = Velocity.LimitLength(Speed);
        Rotation = Velocity.Angle();
        
        Position += Velocity * (float)delta;
        
        LastPosition = GlobalPosition;
    }
}
