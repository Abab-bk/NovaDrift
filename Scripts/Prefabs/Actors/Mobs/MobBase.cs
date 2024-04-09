using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Frameworks.Stats;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public override void _Ready()
    {
        base._Ready();
    }

    protected override void InitStats()
    {
        Stats = new CharacterStats(100, 200);
        
        Stats.Health.ValueChangedEvent += (float value) =>
        {
            GD.Print("Health changed");
            GD.Print(value);
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
