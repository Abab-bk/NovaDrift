using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

public partial class MoveActorToScreenCenter(Actor actor) : Node2D
{
    public override void _PhysicsProcess(double delta)
    {
        actor.SetTargetPosAndMove(Wizard.GetScreenCenter(), (float)delta);
        if (actor.GlobalPosition.DistanceTo(Wizard.GetScreenCenter()) <= 30)
        {
            actor.Velocity = Vector2.Zero;
            QueueFree();
        }
    }
}