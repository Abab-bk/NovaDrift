using System.Collections.Generic;
using Godot;

namespace NovaDrift.Scripts.Systems.Formations;

public partial class FormationPainter : Node2D
{
    public List<Vector2> UnitPoints = new List<Vector2>();

    public override void _Process(double delta)
    {
        QueueRedraw();
    }

    public override void _Draw()
    {
        foreach (var unitPoint in UnitPoints)
        {
            DrawCircle(unitPoint, 20f, Colors.Red);
        }
    }
}