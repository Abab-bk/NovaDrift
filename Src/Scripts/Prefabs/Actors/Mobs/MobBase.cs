using System;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public MobInfo MobInfo;

    [Export] public string Sign;

    public override void _Ready()
    {
        base._Ready();
        AddToGroup("Mobs");
        if (MobInfo == null) throw new Exception("MobInfo 为 Null");
        
        Stats.Health.ValueChanged += (value) =>
        {
            if (value <= 0)
            {
                Die();
            }
        };
    }

    protected override void InitStats()
    {
        Stats.Health.BaseValue = MobInfo.Health * Global.GetPlayerLevel();
        Stats.Health.MaxValue.BaseValue = MobInfo.Health * Global.GetPlayerLevel();
        
        Stats.Speed.BaseValue = MobInfo.Speed;
        Stats.Damage.BaseValue = MobInfo.Damage * Global.GetPlayerLevel();
        
        Shooter.SetShootCd(MobInfo.ShootCd);
    }

    public override void Die()
    {
        Global.OnMobDied?.Invoke(this);
        base.Die();
    }

    private float GetDistanceToPlayer()
    {
        return Global.Player.GlobalPosition.DistanceTo(GlobalPosition);
    }

    public void SetTargetAndMove(Node2D target, float delta)
    {
        LookAt(target.GlobalPosition);
        TryMoveTo(GlobalPosition.DirectionTo(target.GlobalPosition), delta);
        MoveAndSlide();
    }
}
