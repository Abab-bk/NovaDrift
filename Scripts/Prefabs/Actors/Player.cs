using Godot;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    public override void _Ready()
    {
        base._Ready();
        Global.Player = this;
    }

    protected override void InitStats()
    {
        Stats.Speed.BaseValue = 300f;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();
        LookAt(mousePos);
        
        if (Input.IsActionPressed("Click"))
        {
            Velocity = GlobalPosition.DirectionTo(mousePos) * Stats.Speed.Value;
            MoveAndSlide();
        }

        if (Input.IsActionPressed("RClick"))
        {
            Shoot(GlobalPosition.DirectionTo(mousePos));
        }
    }
}
