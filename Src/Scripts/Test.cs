using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    [Export] private Marker2D _marker2D;
    private SnakeContainer _snakeContainer;
    
    public override void _Ready()
    {
        _snakeContainer = new SnakeContainer();
        AddChild(_snakeContainer);

        _snakeContainer.GlobalPosition = _marker2D.GlobalPosition;
        for (int i = 0; i < 10; i++)
        {
            _snakeContainer.AddPart();
        }
    }

    public override void _PhysicsProcess(double delta)
    {
    }
}

