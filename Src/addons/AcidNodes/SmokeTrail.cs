using System;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace AcidWallStudio.AcidNodes;

[GlobalClass]
public partial class SmokeTrail : Line2D
{
    private readonly (float, float) _lifetime = (1f, 2f);
    private readonly float _wildNess = 3f;
    private Vector2 _gravity = Vector2.Up;

    private float _tickSpeed = 0.05f;
    private float _tick = 0f;
    private float _wildSpeed = 0.1f;

    private Tween _tween;
    
    public override void _Ready()
    {
        _tween = CreateTween();
        _tween.TweenProperty(this, "modulate:a", 0f, Random.Shared.FloatRange(_lifetime.Item1, _lifetime.Item2));
    }

    public override void _Process(double delta)
    {
        if (_tick > _tickSpeed)
        {
            _tick = 0f;
            for (int i = 0; i < GetPointCount(); i++)
            {
                Vector2 randVector = new Vector2(
                    Random.Shared.FloatRange(-_wildSpeed, _wildSpeed),
                    Random.Shared.FloatRange(-_wildSpeed, _wildSpeed));
                
                Points[i] += _gravity + (randVector * _wildNess);
            }
        }
        else
        {
            _tick += (float)delta;
        }
    }
}
