using Godot;
using System;
using AcidWallStudio.AcidUtilities;

namespace NovaDrift.Scripts.Vfx;

public partial class RotationTrail : Node2D
{
    [Export] private Line2D _trail;

    public Vector2 TargetPos;
    public Vector2 MiddlePos;
    public Vector2 StartPos;

    private float _t;

    public override void _Ready()
    {
        GlobalPosition = StartPos;
    }

    public override void _Process(double delta)
    {
        _t += (float)delta;
        GlobalPosition = Wizard.Bezier(StartPos, MiddlePos, TargetPos, _t);
    }
}
