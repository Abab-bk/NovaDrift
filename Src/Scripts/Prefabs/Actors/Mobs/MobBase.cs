using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Frameworks.Stats;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    protected override void InitStats()
    {
        Stats.SetDamage(20f);
        
        Stats.Health.ValueChanged += (float value) =>
        {
            if (value <= 0)
            {
                Die();
            }
        };
        
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
