using System;
using DsUi;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Shields;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Systems.Pool;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    public event Action<Node2D> OnHitSomeThing;
    
    [Export] private HurtBox _hurtBox;
    
    [Export] protected Sprite2D Sprite;
    
    [Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
    [Export] public bool IsPlayer;

    [Export] public BaseShooter Shooter
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
    
    public Node2D ShooterNode;
    public Node2D ShieldNode;
    private Area2D _bodyArea;

    public BaseShield Shield;
    
    public Action StartShooting;
    public Action StopShooting;
    public Action OnDied;
    public Action<BulletBase> OnShoot;
    public Action OnShooting;
    public event Action<float> OnHurt;
    
    private BaseShooter _shooter;

    public readonly CharacterStats Stats = new CharacterStats();
    
    public float ShootCd = 1f;
    
    public bool IsShooting = false;
    
    public bool IsDead;
    protected ActorVisual Visual;
    
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
        Rotation = RotationTo(GlobalPosition.AngleToPoint(pos), delta);
        TryMoveTo(GlobalPosition.DirectionTo(pos), delta);
    }
    
    public virtual void TryMoveTo(Vector2 dir, double delta)
    {
        var targetVelocity = dir * (Stats.Speed.Value * (IsShooting ? 1f - Stats.ShootingDeceleration.Value : 1f));
        
        Velocity = Velocity.MoveToward(targetVelocity, Stats.Acceleration.Value * (float)delta);
    }

    public void TryStop(double delta)
    {
        Velocity = Velocity.MoveToward(Vector2.Zero, Stats.Deceleration.Value * (float)delta);
    }
    
    public virtual float RotationTo(float target, double delta)
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
    
    protected void Init()
    {
        ShooterNode = GetNode<Node2D>("%ShooterNode");
        ShieldNode = GetNode<Node2D>("%ShieldNode");
        _bodyArea = GetNode<Area2D>("%BodyArea");
        
        AddToGroup("Actors");
        
        Visual = new ActorVisual(this);
        
        InitStats();
        InitCollision();

        UpdateScale();
        
        Stats.SetTarget(this);
        Stats.OnBodyChanged += () =>
        {
            Sprite.Texture = GD.Load<Texture2D>(Stats.Body.IconPath);
        };

        StartShooting += () => IsShooting = true;
        StopShooting += () => IsShooting = false;
        
        this.SetIsPlayer(IsPlayer);
        
        _hurtBox.OnHit += OnHit;
        _hurtBox.SetIsPlayer(IsPlayer);
        
        _visibleOnScreenNotifier2D.ScreenExited += MoveToWorldEdge;
        
        _bodyArea.SetIsPlayer(IsPlayer);
        _bodyArea.BodyEntered += (body) => OnHitSomeThing?.Invoke(body);
    }

    protected void UpdateScale()
    {
        if (Stats.Size.Value == 0) return;
        Scale = new Vector2(Stats.Size.Value, Stats.Size.Value);
    }

    public override void _ExitTree()
    {
        EventBus.OnWorldColorChanged -= ChangeColor;
    }

    public virtual void Die()
    {
        if (IsDead) return;
        OnDied?.Invoke();
        IsDead = true;
        Stats.BuffSystem.RemoveAllBuffs();
        Stats.EffectSystem.RemoveAllEffects();
        CallDeferred(Node.MethodName.QueueFree);
    }
    
    protected void ChangeColor()
    {
        Modulate = Global.WorldColor.Level1;
    }

    public void TakeDamage(float value)
    {
        Stats.AddKnockBack(Stats.ShootKnockBack.Value);
        Stats.Health.Decrease(GetRealDamage(value));
        OnHit(GetRealDamage(value));
    }

    public void TakeDamageWithoutKnockBack(float value)
    {
        Stats.Health.Decrease(GetRealDamage(value));
        OnHit(GetRealDamage(value));
    }
    
    public float GetRealDamage(float value)
    {
        return Mathf.Max(1f, value * Stats.InjuryFactor.Value - Stats.Plating.Value);
    }
    
    public virtual void OnHit(float value)
    {
        OnHurt?.Invoke(value);
        Visual.FlashAndRestore();
        UiManager.Open_DamageLabel().ShowValue(value, GetGlobalTransformWithCanvas().Origin);
    }

    private void MoveToWorldEdge()
    {
        // Vector2 newPos = GlobalPosition;
        // if (GlobalPosition.X < 0)
        // {
        //     newPos.X = 2560;
        // }
        //
        // if (GlobalPosition.X > 2560)
        // {
        //     newPos.X = 0;
        // }
        //
        // if (GlobalPosition.Y < 0)
        // {
        //     newPos.Y = 1440;
        // }
        //
        // if (GlobalPosition.Y > 1440)
        // {
        //     newPos.Y = 0;
        // }
        //
        // GlobalPosition = newPos;
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
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity += Stats.ForceVector;

        MoveAndSlide();
        
        if (Stats.GetKnockBack() > 0)
        {
            Velocity += Vector2.Right.Rotated(Rotation) * (-Stats.GetKnockBack() / 5f);
            Stats.AddKnockBack(-Stats.GetKnockBack());
        }
    }
}


public class ActorVisual(Actor target)
{
    private Color _originalColor;
    private bool _flashing;
    
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

    public void Appear()
    {
        target.ProcessMode = Node.ProcessModeEnum.Disabled;
        
        var focusVfx = Pool.FocusVfxPool.Get();
        
        focusVfx.Reparent(target);
        focusVfx.OneShot = true;
        focusVfx.Play();
        
        focusVfx.OnAnimationEnd += () =>
        {
            var blastVfx = Pool.BlastVfxPool.Get();
            
            blastVfx.Reparent(target);
            blastVfx.Position = Vector2.Zero;
            blastVfx.PlaySound = false;
            blastVfx.Play();
            
            target.ProcessMode = Node.ProcessModeEnum.Inherit;
        };
    }
}