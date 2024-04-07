using Godot;
using NovaDrift.Scripts.Frameworks.Models;

namespace NovaDrift.Scripts.Frameworks.Commands;

public class ActorMoveCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        PlayerModel model = this.GetModel<PlayerModel>();
        Vector2 mousePos = model.Actor.GetGlobalMousePosition();
        model.Actor.Rotation = mousePos.AngleToPoint(model.Actor.Position);

        if (Input.IsActionPressed("Click"))
        {
            model.Actor.Velocity = model.Actor.GlobalPosition.DirectionTo(mousePos) * model.CharacterStats.Speed.Value;
        }

        model.Actor.MoveAndSlide();
    }
}