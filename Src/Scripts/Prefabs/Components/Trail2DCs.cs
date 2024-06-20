using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Trail2DCs : Line2D
{
    [Export] private float _maxLength;

    public override void _Ready()
    {
        SetAsTopLevel(true);
    }

    public override void _Process(double delta)
    {
        if (GetParent() is not Node2D node2D) return;
        var point = node2D.GlobalPosition;
        
        AddPoint(point, 0);

        if (Points.Length > _maxLength)
        {
            RemovePoint(GetPointCount() - 1);
        }
    }
}