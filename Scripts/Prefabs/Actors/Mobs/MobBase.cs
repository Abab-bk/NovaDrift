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
    }

    public override void Die()
    {
        Global.OnMobDied?.Invoke(this);
        QueueFree();
    }

    public void SetTargetAndMove(Node2D target)
    {
        LookAt(target.GlobalPosition);
        Velocity = GlobalPosition.DirectionTo(target.GlobalPosition) * Stats.Speed.Value;
        MoveAndSlide();
    }
}
