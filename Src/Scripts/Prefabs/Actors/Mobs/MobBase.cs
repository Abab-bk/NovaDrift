using System;
using System.Collections.Generic;
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

    private Node2D _target;
    public List<string> Tags = new List<string>();
    
    [Export] public string Sign;
    [Export] private HitBox _hitBox;

    public override void _Ready()
    {
        Stats.Recoil.BaseValue = 0f;
        if (MobInfo == null) throw new Exception("MobInfo 为 Null");

        Ai = GetNode<MobAiComponent>("%MobAiComponent");
        
        base._Ready();
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
        
        if (Shooter != null) Shooter.Init();
        
        if (_hitBox.GetChild(0) is CollisionShape2D collisionShape2D)
        {
            if (GetNode("CollisionShape2D") is not CollisionShape2D collision) return;
            collisionShape2D.Shape = collision.Shape;
        }
    }
    
    protected override void InitStats()
    {
        Stats.Level = Mathf.Max(Global.GetPlayerLevel() - 1, 1);
        Stats.RotationSpeed.BaseValue = 2f;

        Stats.Size.BaseValue = MobInfo.Size;
        
        Stats.Health.BaseValue = MobInfo.Health * Stats.Level;
        Stats.Health.MaxValue.BaseValue = MobInfo.Health * Stats.Level;
        
        Stats.Speed.BaseValue = MobInfo.Speed;
        Stats.Damage.BaseValue = MobInfo.Damage * Stats.Level;
        Stats.ShootSpeed.BaseValue = MobInfo.ShootCd;

        Stats.Targeting.BaseValue = MobInfo.Targeting;

        Stats.BulletCount.BaseValue = MobInfo.BulletCount;
        
        Shooter.SetShootCd(MobInfo.ShootCd);
    }

    public override void Die()
    {
        if (IsDead) return;

        var temp = new Vector2(10f, 10f);
        for (int i = 0; i < MobInfo.GetExp; i++)
        {
            var expBall = GD.Load<PackedScene>("res://Scenes/Vfx/ExpBall.tscn").Instantiate<ExpBall>();
            expBall.Pos = GlobalPosition + temp * i;
            Global.GameWorld.AddChild(expBall);
        }

        var dieVfx = GD.Load<PackedScene>("res://Scenes/Vfx/DieVfx.tscn").Instantiate<DieVfx>();
        dieVfx.GlobalPosition = GlobalPosition;
        dieVfx.Modulate = Modulate;
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, dieVfx);
        
        EventBus.OnMobDied?.Invoke(this);
        base.Die();
    }

    public void RemoveSelf()
    {
        if (IsDead) return;
       
        SetProcessMode(ProcessModeEnum.Disabled);
        Logger.Log($"[MobBase] Game over, remove self: {Name}");
        
        IsDead = true;
        Stats.BuffSystem.RemoveAllBuffs();
        Stats.EffectSystem.RemoveAllEffects();
        QueueFree();
    }

    public float GetDistanceToPlayer()
    {
        return Global.Player.GlobalPosition.DistanceTo(GlobalPosition);
    }

    public void SetTargetAndMove(Node2D target, float delta)
    {
        TryMoveTo(GlobalPosition.DirectionTo(target.GlobalPosition), delta);
    }

    public override void TryMoveTo(Vector2 dir, double delta)
    {
        Rotation = RotationTo(GlobalPosition.AngleToPoint(dir), delta);
        var targetVelocity = HandleDir(dir) * Stats.Speed.Value;
        Velocity = Velocity.MoveToward(targetVelocity, Stats.Acceleration.Value * (float)delta);
    }
    
    private Vector2 HandleDir(Vector2 movement)
    {
        foreach (var node in GetTree().GetNodesInGroup("Mobs"))
        {
            if (node == this) continue;
            if (node is not MobBase mobBase) continue;
            
            if (GlobalPosition.DistanceTo(mobBase.GlobalPosition) > 100f) continue;
            
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
}
