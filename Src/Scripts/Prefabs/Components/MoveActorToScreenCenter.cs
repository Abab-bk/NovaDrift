using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

public partial class MoveActorToScreenCenter(Actor actor) : Node2D
{
    public override void _PhysicsProcess(double delta)
    {
        if (!IsInstanceValid(actor))
        {
            Logger.Log("[MoveActorToScreenCenter] Actor is null, removing component");
            QueueFree();
            return;
        }

        actor.SetTargetPosAndMove(Wizard.GetScreenCenter(), (float)delta);
        if (actor.GlobalPosition.DistanceTo(Wizard.GetScreenCenter()) <= 30)
        {
            actor.Velocity = Vector2.Zero;
            QueueFree();
        }
    }
}