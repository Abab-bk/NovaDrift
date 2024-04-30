using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

public partial class MoveActorToScreenCenter : Node2D
{
    private Actor _actor;
    
    public MoveActorToScreenCenter(Actor actor) { _actor = actor; }

    public override void _PhysicsProcess(double delta)
    {
        _actor.SetTargetPosAndMove(Wizard.GetScreenCenter(), (float)delta);
        if (_actor.GlobalPosition.DistanceTo(Wizard.GetScreenCenter()) <= 30)
        {
            _actor.Velocity = Vector2.Zero;
            QueueFree();
        }
    }
}