using System;
using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace AcidWallStudio.AcidNodes;

[GlobalClass]
public partial class SmokeTrail : Line2D
{
    private (float, float) _lifetime = (1f, 2f);
    [Export] private float _wildNess = 3f;
    [Export] private Vector2 _gravity = Vector2.Up;
    [Export] private float _minSpawnDistance = 5.0f;

    private float _tickSpeed = 0.05f;
    private float _tick = 0f;
    private float _wildSpeed = 0.1f;

    private Tween _tween;
    private List<float> _pointsAge = new List<float>();
    
    
    public override void _Ready()
    {
        TopLevel = true;
        _tween = CreateTween();
        _tween.TweenProperty(this, "modulate:a", 0f, Random.Shared.FloatRange(_lifetime.Item1, _lifetime.Item2));
    }

    public void AddAgePoint(Vector2 pointPos)
    {
        if (GetPointCount() > 0 && pointPos.DistanceTo(Points[GetPointCount() - 1]) < _minSpawnDistance) return;
        _pointsAge.Add(0.0f);
        AddPoint(pointPos);
    }

    public override void _Process(double delta)
    {
        if (_tick > _tickSpeed)
        {
            _tick = 0f;
            for (int i = 0; i < GetPointCount(); i++)
            {
                _pointsAge[i] += 5f * (float)delta;
                
                Vector2 randVector = new Vector2(
                    Random.Shared.FloatRange(-_wildSpeed, _wildSpeed),
                    Random.Shared.FloatRange(-_wildSpeed, _wildSpeed));
                
                Points[i] += _gravity + (randVector * _wildNess * _pointsAge[i]);
            }
        }
        else
        {
            _tick += (float)delta;
        }
    }
}
