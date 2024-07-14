using Godot;

namespace AcidJoystick;

[GlobalClass]
public partial class Joystick : Node2D
{
    public Vector2 TargetPos = Vector2.Zero;
    public bool Pressing { get => _knob.Pressing; }

    private JoyKnob _knob;

    public override void _Ready()
    {
        _knob = GetNode<JoyKnob>("JoyKnob");
    }
}
