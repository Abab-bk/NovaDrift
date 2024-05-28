using System;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public MobInfo MobInfo;

    [Export] public string Sign;

    public override void _Ready()
    {
        if (MobInfo == null) throw new Exception("MobInfo 为 Null");
        base._Ready();
        AddToGroup("Mobs");
        
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
        Stats.Health.BaseValue = MobInfo.Health * Global.GetPlayerLevel();
        Stats.Health.MaxValue.BaseValue = MobInfo.Health * Global.GetPlayerLevel();
        
        Stats.Speed.BaseValue = MobInfo.Speed;
        Stats.Damage.BaseValue = MobInfo.Damage * Global.GetPlayerLevel();
        Stats.ShootSpeed.BaseValue = MobInfo.ShootCd;

        Stats.Targeting.BaseValue = MobInfo.Targeting;
        
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
        LookAt(target.GlobalPosition);
        TryMoveTo(GlobalPosition.DirectionTo(target.GlobalPosition), delta);
        MoveAndCollide(Velocity * delta);
    }
}
