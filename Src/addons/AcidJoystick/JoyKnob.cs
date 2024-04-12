using System;
using Godot;

namespace AcidJoystick;

public partial class JoyKnob : Sprite2D
{
    [Export] TouchScreenButton _button;
    [Export] float _maxLength = 800f;
    [Export] float _deadZone = 5f;
    
    Joystick _parent;
    
    public override void _Ready()
    {
        _parent = GetNode<Joystick>("../");
        _maxLength *= _parent.Scale.X;
    }

    private void CalculateVector()
    {
        if (Math.Abs(GlobalPosition.X - _parent.GlobalPosition.X) >= _deadZone)
        {
            _parent.TargetPos.X = (GlobalPosition.X - _parent.GlobalPosition.X) / _maxLength;
        }
        if (Math.Abs(GlobalPosition.Y - _parent.GlobalPosition.Y) >= _deadZone)
        {
            _parent.TargetPos.Y = (GlobalPosition.Y - _parent.GlobalPosition.Y) / _maxLength;
        }
    }

    public override void _Process(double delta)
    {
        if (!_button.IsPressed())
        {
            GlobalPosition = _parent.GlobalPosition;
            _parent.TargetPos = Vector2.Zero;
            return;
        }

        CalculateVector();
        if (GetGlobalMousePosition().DistanceTo(_parent.GlobalPosition) > _maxLength)
        {
            var angle = _parent.GlobalPosition.AngleToPoint(GetGlobalMousePosition());
            GlobalPosition = _parent.GlobalPosition + new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * _maxLength;
            return;
        }

        GlobalPosition = GetGlobalMousePosition();
    }
}
