using System;
using System.Collections.Generic;
using AcidWallStudio.Fmod;
using AcidWallStudio.ObjectPool;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public MobInfo MobInfo;
    public bool IsBoss = false;
    public MobAiComponent Ai;
    public DragonController DragonController;
    
    private Node2D _target;
    public List<string> Tags = new List<string>();
    
    [Export] public string Sign;
    [Export] private HitBox _hitBox;
    [GetNode("%BoidsArea")] private Area2D _boidsArea;

    public NodePool<MobBase> Pool = null;
    public event Action OnRemoved; // GameOver 时触发
    public bool IsActive; // 在 Pool 里就是 false
    
    public override void _Ready()
    {
        base._Ready();
        if (Global.GameContext.IsGameOver)
        {
            QueueFree();
            return;
        }

        Stats.Recoil.BaseValue = 0f;
        if (MobInfo == null) throw new Exception("MobInfo 为 Null");

        Ai = GetNode<MobAiComponent>("%MobAiComponent");
        
        Init(); // base._Ready()
        
        AddToGroup("Mobs");

        _hitBox.Damage = Stats.Damage.Value;
        _hitBox.SetIsPlayer(false);
        
        Stats.Health.ValueChanged += (value) =>
        {
            if (value <= 0)
            {
                Die();
            }
        };

        Stats.Damage.ValueChanged += _ =>
        {
            _hitBox.Damage = Stats.Damage.Value;
        };

        Stats.Size.ValueChanged += _ =>
        {
            Logger.Log($"[MobBase] Size changed: {Stats.Size.Value}");
            UpdateScale();
        };

        // EventBus.OnGameOver += RemoveSelf;
        
        if (Shooter != null) Shooter.Init();
        
        if (_hitBox.GetChild(0) is CollisionShape2D collisionShape2D)
        {
            if (GetNode("CollisionShape2D") is not CollisionShape2D collision) return;
            collisionShape2D.Shape = collision.Shape;
        }

        if (IsBoss)
        {
            Global.GameContext.AppendFollowTarget(this);
            // 因为 BOSS 没有进对象池
            SoundManager.SetMusicParameter(AudioParams.Stage, (int)BackgroundMusicStage.Stage2);
        }
        else
        {
            AddToGroup("NormalMobs");
        }

        UpdateScale();
    }

    public void PoolActive()
    {
        // Visual.Appear();
        InitStats();
        Ai.Active();
    }

    protected override void InitStats()
    {
        Stats.Level = Mathf.Max(Global.GetPlayerLevel() - 1, 1);
        Stats.RotationSpeed.BaseValue = 2f;

        Stats.Size.BaseValue = MobInfo.Size;
        
        Stats.Health.MaxValue.BaseValue = MobInfo.Health;
        Stats.Health.BaseValue = MobInfo.Health;
        
        Stats.Speed.BaseValue = MobInfo.Speed + Stats.Level * 1;
        Stats.Damage.BaseValue = MobInfo.Damage + Stats.Level * 4;
        Stats.ShootSpeed.BaseValue = MobInfo.ShootCd;

        Stats.Targeting.BaseValue = MobInfo.Targeting;

        Stats.BulletCount.BaseValue = MobInfo.BulletCount;
        
        if (IsBoss) Shooter.SetShootCd(MobInfo.ShootCd);
    }

    public override void Shoot()
    {
        if (!IsBoss) return;
        base.Shoot();
    }

    public override void Die()
    {
        InnerRemove();
        
        var temp = new Vector2(10f, 10f);
        for (int i = 0; i < MobInfo.GetExp; i++)
        {
            var expBall = Systems.Pool.Pool.ExpBallPool.Get();
            expBall.GlobalPosition = GlobalPosition + temp * i;
        }

        var dieVfx = Systems.Pool.Pool.DieVfxPool.Get();
        dieVfx.GlobalPosition = GlobalPosition;
        dieVfx.Modulate = Modulate;
        
        EventBus.OnMobDied?.Invoke(this);
        
        Global.Shake(10f);
        
        OnDied?.Invoke();
    }

    private void InnerRemove()
    {
        if (IsDead) return;
        if (!IsActive && !IsBoss) return;
        
        Stats.BuffSystem.RemoveAllBuffs();
        Stats.EffectSystem.RemoveAllEffects();
        
        if (IsBoss)
        {
            Global.GameContext.RemoveFollowTarget(this);
            SoundManager.SetMusicParameter(AudioParams.Stage, (int)BackgroundMusicStage.Stage1);
        }
        
        IsDead = true;
        
        if (Pool != null)
        {
            Pool.Release(this);
        }
        else
        {
            if (IsBoss) Logger.Log("Boss Remove Self");
            QueueFree();
        }
    }

    public void RemoveSelf()
    {
        InnerRemove();
        OnRemoved?.Invoke();
    }

    public float GetDistanceToPlayer()
    {
        return Global.Player.GlobalPosition.DistanceTo(GlobalPosition);
    }

    public void SetTargetAndMove(Node2D target, float delta)
    {
        TryMoveTo(GlobalPosition.DirectionTo(target.GlobalPosition), delta);
        if (Tags.Contains(Constants.Tags.IsDragonBone))
        {
            DragonController.FlipX(Global.Player.GlobalPosition.X < GlobalPosition.X);
            return;
        }
        LookAt(target.GlobalPosition);
    }

    public override void TryMoveTo(Vector2 dir, double delta)
    {
        // Rotation = RotationTo(GlobalPosition.AngleToPoint(dir), delta);
        var targetVelocity = HandleDir(dir) * Stats.Speed.Value;
        Velocity = Velocity.MoveToward(targetVelocity, Stats.Acceleration.Value * (float)delta);
    }
    
    private Vector2 HandleDir(Vector2 movement)
    {
        foreach (var node in _boidsArea.GetOverlappingBodies())
        {
            if (node == this) continue;
            if (node is not MobBase mobBase) continue;
            
            var ratio = (mobBase.GlobalPosition - GlobalPosition).Length() / 20f > 0f ? 1f : 0f;
            movement -= ratio * (mobBase.GlobalPosition - GlobalPosition);
        }
        
        return movement.Normalized();
    }

    public void LookForward(float delta)
    {
        Rotation = RotationTo(Velocity.Angle(), delta);
    }
    
    public void LookAtPlayer(float delta)
    {
        Rotation = RotationTo(GlobalPosition.AngleToPoint(Global.Player.GlobalPosition), delta);
    }
    
    public void LookBack(float delta)
    {
        Rotation = RotationTo(Velocity.Angle() + MathF.PI, delta);
    }

    public override float RotationTo(float target, double delta)
    {
        if (Tags.Contains(Constants.Tags.IsDragonBone)) return Rotation;
        return base.RotationTo(target, delta);
    }
}
