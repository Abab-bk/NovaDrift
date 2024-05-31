using System;
using AcidWallStudio.SpringSystem;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public MobInfo MobInfo;

    private Node2D _target;
    
    [Export] public string Sign;

    private void AddNodeToSpring(Node node)
    {
        if (node is not Node2D node2D) return;
        Spring.AddTargetPoint(new SpringInfo(SpringType.Push, node2D, 1000f));
    }

    public override void _Ready()
    {
        if (MobInfo == null) throw new Exception("MobInfo 为 Null");
        
        EventBus.OnMobEnteredTree += AddNodeToSpring;
        
        base._Ready();
        AddToGroup("Mobs");
        
        Spring.AddTargetPoint(new SpringInfo(SpringType.Pull, Global.Player, 1f));
        foreach (var mob in GetTree().GetNodesInGroup("Mobs"))
        {
            AddNodeToSpring(mob);
        }

        EventBus.OnMobDied += Spring.RemoveTargetPoint;

        Stats.Health.ValueChanged += (value) =>
        {
            if (value <= 0)
            {
                Die();
            }
        };
        
        // if (Shooter != null) Shooter.Init();
    }
    
    protected override void InitStats()
    {
        Stats.RotationSpeed.BaseValue = 2f;
        
        Stats.Health.BaseValue = MobInfo.Health * Global.GetPlayerLevel();
        Stats.Health.MaxValue.BaseValue = MobInfo.Health * Global.GetPlayerLevel();
        
        Stats.Speed.BaseValue = MobInfo.Speed;
        Stats.Damage.BaseValue = MobInfo.Damage * Global.GetPlayerLevel();
        Stats.ShootSpeed.BaseValue = MobInfo.ShootCd;

        Stats.Targeting.BaseValue = MobInfo.Targeting;

        Stats.BulletCount.BaseValue = MobInfo.BulletCount;
        
        Shooter.SetShootCd(MobInfo.ShootCd);
    }

    public override void Die()
    {
        if (IsDead) return;
        Global.Player.Stats.Exp.Increase(5);
        // Global.Player.Stats.Exp.Increase(50 * Stats.Level);
        EventBus.OnMobDied?.Invoke(this);
        base.Die();
    }

    public float GetDistanceToPlayer()
    {
        return Global.Player.GlobalPosition.DistanceTo(GlobalPosition);
    }

    public void SetTargetAndMove(Node2D target, float delta)
    {
        Rotation = RotationTo(GlobalPosition.AngleToPoint(target.GlobalPosition), delta);
        // LookAt(target.GlobalPosition);
        // TryMoveTo(GlobalPosition.DirectionTo(target.GlobalPosition), delta);

        if (target != _target)
        {
            Spring.RemoveTargetPoint(_target);
            _target = target;
            Spring.AddTargetPoint(new SpringInfo(SpringType.Pull, _target, 1f));
        }

        TryMoveTo(GlobalPosition.DirectionTo(target.GlobalPosition), delta);
        MoveAndSlide();
    }

    public override void TryMoveTo(Vector2 dir, double delta)
    {
        var targetVelocity = Spring.GetMovement() * Stats.Speed.Value;
        // var targetVelocity = dir * Stats.Speed.Value;
        // Velocity = Velocity.MoveToward(targetVelocity, Stats.Acceleration.Value * (float)delta);
        Velocity = targetVelocity;
    }
}
