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
        
        Stats.Health.ValueChanged += (float value) =>
        {
            if (value <= 0)
            {
                Die();
            }
        };
    }

    protected override void InitStats()
    {
        Stats.SetDamage(20f).SetHealth(100f);
        Shooter.SetShootCd(0.8f);
    }

    public override void Die()
    {
        Global.OnMobDied?.Invoke(this);
        QueueFree();
    }

    public float GetDistanceToPlayer()
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
