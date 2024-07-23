using System;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using AcidWallStudio.ObjectPool;
using Godot;
using GodotTask;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;

public partial class BulletBase : Node2D
{
    [Export] private HitBox _hitBox;

    public Actor Target; // Owner
    
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

    public NodePool<BulletBase> Pool = null;

    private Tween _tween;
    private bool _isRelease;
    
    public void Destroy()
    {
        Release();
    }

    protected void TakeOnHitEvent(Actor obj)
    {
        OnHit?.Invoke(obj);
    }

    public void Active(Vector2 pos)
    {
        _isRelease = false;

        Scale = new Vector2(Size, Size);

        Velocity = Direction * Speed;
        Rotation = Direction.Angle();
        _hitBox.SetIsPlayer(IsPlayer);

        if (IsPlayer)
        {
            _hitBox.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, (int)Layer.PlayerBullet, true);
        }
        else
        {
            _hitBox.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, (int)Layer.MobBullet, true);
        }
        
        Degenerate();

        if (Steering > 0)
        {
            TargetingActor = this.GetClosestTarget(IsPlayer ? "Mobs" : "Players");
        }

        GlobalPosition = pos;
        LastPosition = GlobalPosition;

        CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Inherit);
        
        Show();
    }
    
    public void Release()
    {
        if (_isRelease) return;
        
        _isRelease = true;
        
        if (Pool == null)
        {
            QueueFree();
            return;
        }

        _tween.Kill();

        Direction = Vector2.Right;
        Velocity = Vector2.Zero;
        
        Pool.Release(this);
        GlobalPosition = Constants.DefaultPoolPos;
        TargetingActor = null;
    }

    public override void _Ready()
    {
        _hitBox.OnHit += OnHitHandle;
        _hitBox.OnHitOthers += OnHitOthersHandle;
    }

    protected virtual void OnHitOthersHandle()
    {
        Release();
    }

    protected virtual void OnHitHandle(Actor actor)
    {
        SoundManager.PlayOneShotById("event:/OnBulletHit");
        
        var vfx = Systems.Pool.Pool.BounceVfxPool.Get();
        vfx.GlobalPosition = GlobalPosition;
        vfx.Rotation = -Rotation;
        vfx.Modulate = actor.Modulate;
        vfx.Emitting = true;
        
        OnHit?.Invoke(actor);
        if (CanPenetrate > 0)
        {
            CanPenetrate--;
            if (CanPenetrate == 0)
            {
                Release();
            }
        }
        Release();
    }

    private Vector2 Seek()
    {
        if (!IsInstanceValid(TargetingActor)) return Vector2.Zero;
        var desired = GlobalPosition.DirectionTo(TargetingActor.GlobalPosition) * Speed;
        return (desired - Velocity).Normalized() * Steering;
    }

    protected virtual void Degenerate()
    {
        _tween = CreateTween();
        _tween.TweenProperty(this, "scale", Vector2.Zero, Degeneration);
        _tween.Finished += Release;
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
