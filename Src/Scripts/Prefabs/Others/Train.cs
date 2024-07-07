using Godot;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class Train : Node2D, IHazard
{
    public int Length = 2;

    private Vector2 _direction = Vector2.Right;
    
    [GetNode("Timer")] private Timer _timer;

    public override void _Ready()
    {
        _direction = Vector2.Right.Rotated(Rotation);
        
        for (int i = 0; i < Length; i++)
        {
            var body = GD
                .Load<PackedScene>("res://Scenes/Prefabs/Others/TrainBody.tscn")
                .Instantiate<TrainBody>();
            AddChild(body);
            body.Position = Vector2.Zero + new Vector2(-136f, 0f) * i;
        }

        _timer.Timeout += QueueFree;
        _timer.Start();
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += _direction * 600f * (float)delta;
    }
}
