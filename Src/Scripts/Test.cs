using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    [Export] private Polyline2D _polyline2D;

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            _polyline2D.Generate();
        }
    }
}

