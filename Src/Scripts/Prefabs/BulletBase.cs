using System;
using AcidWallStudio.AcidNodes;
using AcidWallStudio.AcidUtilities;
using Godot;
using NathanHoad;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;

public partial class BulletBase : Node2D
{
    [Export] private HitBox _hitBox;
 
    public event Action<float> OnMove;
    public event Action<Actor> OnHit;
    
    public bool IsPlayer = false;
    
    public float Speed = 1300f;
    public float Size = 1f;
    public float Degeneration = 0.8f;

    private SmokeTrail _smokeTrail;
    private Vector2 _velocity = Vector2.Zero;

    public float Damage
    {
        get => _damage.Value;
        set
        {
            _damage.BaseValue = value;
            _hitBox.Damage = value;
        }
    }

    private Stat _damage = new Stat(1f);
    private Vector2 _lastPosition = new Vector2();
    public Vector2 Direction = Vector2.Right;

    public float Steering;
    private Node2D _targetingActor;
    private Vector2 _acceleration = Vector2.Zero;
    
    public override void _Ready()
    {
        _velocity = Direction * Speed;
        Rotation = Direction.Angle();
        
        _smokeTrail = GetNode<SmokeTrail>("%SmokeTrail");
        
        _hitBox.SetIsPlayer(IsPlayer);
        _hitBox.OnHit += (actor) =>
        {
            SoundManager.PlaySound(SoundPaths.BulletHit);
            OnHit?.Invoke(actor);
            QueueFree();
        };
        _hitBox.OnHitOthers += QueueFree;

        Scale = new Vector2(Size, Size);
        Degenerate();

        if (Steering > 0)
        {
            _targetingActor = Wizard.GetClosestTarget(this, IsPlayer ? "Mobs" : "Players");
        }
    }

    private Vector2 Seek()
    {
        if (!IsInstanceValid(_targetingActor)) return Vector2.Zero;
        var desired = GlobalPosition.DirectionTo(_targetingActor.GlobalPosition) * Speed;
        return (desired - _velocity).Normalized() * Steering;
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
        _smokeTrail.AddAgePoint(GlobalPosition);
        OnMove?.Invoke(GlobalPosition.DistanceTo(_lastPosition));

        _acceleration += Seek();
        
        _velocity += _acceleration * (float)delta;
        _velocity = _velocity.LimitLength(Speed);
        Rotation = _velocity.Angle();
        
        Position += _velocity * (float)delta;
        
        _lastPosition = GlobalPosition;
    }
}
