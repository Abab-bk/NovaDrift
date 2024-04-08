using Godot;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    public override void _Ready()
    {
        Global.Player = this;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();
        LookAt(mousePos);
        
        if (Input.IsActionPressed("Click"))
        {
            Velocity = GlobalPosition.DirectionTo(mousePos) * CharacterStats.Speed.Value;
            MoveAndSlide();
        }

        if (Input.IsActionPressed("RClick"))
        {
            if (ShootCd > 0)
            {
                Shoot(GlobalPosition.DirectionTo(mousePos));
                ShootCd -= 1;
            }
            else
            {
                ShootCd += 0.1f;
            }

        }
    }
}
