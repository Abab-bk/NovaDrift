using Godot;
using NovaDrift.Scripts.Frameworks.Commands;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    public override void _Ready()
    {
        Earth.Player = this;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("Click"))
        {
            this.SendCommand(new ActorMoveCommand());
        }
    }
}
