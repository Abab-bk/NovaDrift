using Godot;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class MobBase : Actor
{
    public override void _Ready()
    {
        base._Ready();
    }

    public void SetTargetAndMove(Node2D target)
    {
        LookAt(target.GlobalPosition);
        Velocity = GlobalPosition.DirectionTo(target.GlobalPosition) * Stats.Speed.Value;
        MoveAndSlide();
    }
}
