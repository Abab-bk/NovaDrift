using Godot;
using System;
using GTweens.Easings;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class GetNewItemVfx : Node2D
{
    [Export] private Sprite2D _sprite;
    [Export] private Label _label;
    [Export] private GpuParticles2D _gpuParticles2D;
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Control _control;
    
    public override void _Ready()
    {
        _label.Hide();
        _sprite.Hide();
        _gpuParticles2D.Hide();

        _sprite.Position = _sprite.Position with { Y = -900f };
        _sprite.Show();
        _sprite
            .TweenPosition(Vector2.Zero, 0.5f)
            .SetEasing(Easing.OutCubic)
            .OnComplete(() =>
            {
                _animationPlayer.Play("Floating");
                _label.Show();
                _gpuParticles2D.Show();
            })
            .Play();

        _control.GuiInput += @event =>
        {
            if (@event is InputEventMouseButton)
            {
                QueueFree();
            }
        };
    }
}
