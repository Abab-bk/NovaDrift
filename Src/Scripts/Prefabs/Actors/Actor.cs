using System;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.SpringSystem;
using DsUi;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Hazards;
using NovaDrift.Scripts.Prefabs.Shields;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    public event Action<Node2D> OnHitSomeThing;
    
    [Export] private HurtBox _hurtBox;
    
    [Export] protected Spring Spring;
    [Export] protected Sprite2D Sprite;
    
    [Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
    [Export] public bool IsPlayer = false;

    [Export]
    public BaseShooter Shooter
    {
        get => _shooter;
        set
        {
            _shooter = value;
            if (_shooter != null)
            {
                _shooter.OnShoot += _OnShoot;
                _shooter.OnHit += _OnShooterHit;
            }
        }
    }

    public BaseShield Shield;
    
    public Action StartShooting;
    public Action StopShooting;
    public Action OnDied;
    public Action<BulletBase> OnShoot;
    public Action OnShooting;
    
    private BaseShooter _shooter;

    public Node2D ShooterNode;
    public Node2D ShieldNode;
    public readonly CharacterStats Stats = new CharacterStats();
    public float ShootCd = 1f;
    
    // protected bool IsShooting = false;
    
    protected bool IsDead = false;
    protected ActorVisual Visual;
    
    
    private Area2D _bodyArea;
    [Export] private GpuParticles2D _speedParticles;

    protected virtual void _OnShoot(BulletBase bullet)
    {
        Stats.AddKnockBack(Stats.ShootKnockBack.Value);
        Shooter.IsPlayer = IsPlayer;
        OnShoot?.Invoke(bullet);
    }
    
    protected void _OnShooterHit(Actor actor)
    {
        actor.Stats.AddKnockBack(Stats.Recoil.Value);
    }

    public void SetTargetPosAndMove(Vector2 pos, float delta)
    {
        LookAt(pos);
        TryMoveTo(GlobalPosition.DirectionTo(pos), delta);
        MoveAndCollide(Velocity * delta);
    }
    
    public virtual void TryMoveTo(Vector2 dir, double delta)
    {
        var targetVelocity = dir * Stats.Speed.Value;
        // TODO
        // if (IsShooting)
        // {
        //     Velocity = Velocity.MoveToward(
        //         targetVelocity,
        //         (Stats.Acceleration.Value - Stats.ShootingDeceleration.Value) *
        //         (float)delta);
        //     return;
        // }
        
        Velocity = Velocity.MoveToward(targetVelocity, Stats.Acceleration.Value * (float)delta);
    }

    public void TryStop(double delta)
    {
        Velocity = Velocity.MoveToward(Vector2.Zero, Stats.Deceleration.Value * (float)delta);
    }
    
    protected float RotationTo(float target, double delta)
    {
        return Mathf.LerpAngle(Rotation, target, Stats.RotationSpeed.Value * (float)delta);
    }

    private void InitCollision()
    {
        CollisionLayer = 0;
        CollisionMask = 0;
        
        if (IsPlayer)
        {
            CallDeferred("set_collision_layer_value", (int)Layer.Player, true);
            return;
        }
        CallDeferred("set_collision_layer_value", (int)Layer.Mob, true);
    }

    public override void _Ready()
    {
        ShooterNode = GetNode<Node2D>("%ShooterNode");
        ShieldNode = GetNode<Node2D>("%ShieldNode");
        _bodyArea = GetNode<Area2D>("%BodyArea");

        Visual = new ActorVisual(this);
        _speedParticles.Emitting = false;
        
        InitStats();
        InitCollision();
        Stats.SetTarget(this);
        Stats.OnBodyChanged += () =>
        {
            Sprite.Texture = GD.Load<Texture2D>(Stats.Body.IconPath);
        };
        
        this.SetIsPlayer(IsPlayer);
        if (IsPlayer) SetCollisionMaskValue((int)Layer.Mob, false);
        
        _hurtBox.OnHit += OnHit;
        _hurtBox.SetIsPlayer(IsPlayer);
        
        _visibleOnScreenNotifier2D.ScreenExited += MoveToWorldEdge;
        
        _bodyArea.SetIsPlayer(IsPlayer);
        _bodyArea.BodyEntered += (body) => OnHitSomeThing?.Invoke(body);
    }

    public override void _ExitTree()
    {
        EventBus.OnWorldColorChanged -= ChangeColor;
    }

    public virtual void Die()
    {
        if (IsDead) return;
        IsDead = true;
        CallDeferred(Node.MethodName.QueueFree);
    }
    
    protected void ChangeColor()
    {
        Modulate = Global.WorldColor.Level1;
    }

    public void TakeDamage(float value)
    {
        Stats.AddKnockBack(Stats.ShootKnockBack.Value);
        Stats.Health.Decrease(value);
        OnHit(value);
    }

    public void TakeDamageWithoutKnockBack(float value)
    {
        Stats.Health.Decrease(value);
        OnHit(value);
    }
    
    public virtual void OnHit(float value)
    {
        Visual.FlashAndRestore();
        UiManager.Open_DamageLabel().ShowValue(value, GetGlobalTransformWithCanvas().Origin);
    }

    private void MoveToWorldEdge()
    {
        Vector2 newPos = GlobalPosition;
        if (GlobalPosition.X < 0)
        {
            newPos.X = 2560;
        }

        if (GlobalPosition.X > 2560)
        {
            newPos.X = 0;
        }
        
        if (GlobalPosition.Y < 0)
        {
            newPos.Y = 1440;
        }
        
        if (GlobalPosition.Y > 1440)
        {
            newPos.Y = 0;
        }

        GlobalPosition = newPos;
    }

    protected virtual void InitStats()
    {
    }

    public virtual void Shoot()
    {
        Shooter.Shoot();
    }

    public override void _Process(double delta)
    {
        _speedParticles.Emitting = Velocity.LengthSquared() > Stats.Speed.Value + 100f && !_speedParticles.IsEmitting();
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity += Stats.ForceVector;

        var collider = MoveAndCollide(Velocity * (float)delta);
        if (collider != null)
        {
            if (collider.GetCollider() is StaticBody2D staticBody2D && staticBody2D.Owner is AsteroidBase)
            {
                Stats.AddKnockBack(20f);
            }

            if (collider.GetCollider() is Actor actor)
            {
                Stats.AddKnockBack(40f);
            }
        }
        
        if (Stats.GetKnockBack() > 0)
        {
            Velocity += Vector2.Right.Rotated(Rotation) * -Stats.GetKnockBack();
            Stats.AddKnockBack(-Stats.GetKnockBack());
        }
    }
}


public class ActorVisual(Node2D target)
{
    private Color _originalColor;
    private bool _flashing = false;
    public void FlashAndRestore()
    {
        if (_flashing) return;
        _flashing = true;
        _originalColor = target.Modulate;
        GTweenSequenceBuilder.New()
            .Append(target.TweenModulate(Colors.White, 0.2f))
            .Append(target.TweenModulate(_originalColor, 0.2f))
            .AppendCallback(() => _flashing = false)
            .Build()
            .Play();
    }
}