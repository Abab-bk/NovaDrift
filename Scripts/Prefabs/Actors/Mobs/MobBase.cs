using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Frameworks.Stats;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    protected override void InitStats()
    {
        Stats = new CharacterStats(100, 200);
        
        Stats.Health.ValueChanged += (float value) =>
        {
            GD.Print("Health changed   " + value);
            GD.Print(Stats.Health.StatModifiers.Count);
            if (value <= 0)
            {
                Die();
            }
        };
    }

    public void SetTargetAndMove(Node2D target)
    {
        LookAt(target.GlobalPosition);
        Velocity = GlobalPosition.DirectionTo(target.GlobalPosition) * Stats.Speed.Value;
        MoveAndSlide();
    }
}
