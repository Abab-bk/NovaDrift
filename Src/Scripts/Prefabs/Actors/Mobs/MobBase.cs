using System;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public MobInfo MobInfo;

    public override void _Ready()
    {
        base._Ready();
        AddToGroup("Mobs");
        if (MobInfo == null) throw new Exception("MobInfo 为 Null");
        Sprite.Texture = GD.Load<Texture2D>(MobInfo.IconPath);
        
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
        Stats.SetDamage(MobInfo.Damage).SetHealth(MobInfo.Health);
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
