using Godot;
using System;

namespace NovaDrift.Scripts.Vfx;

public partial class LineVfx : Line2D
{
    public Node2D Target;

    public override void _Ready()
    {
        AddPoint(Vector2.Zero);
        AddPoint(Vector2.Zero);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Target == null) return;
        SetPointPosition(1, ToLocal(Target.GlobalPosition));
    }
}
