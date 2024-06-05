using System;
using AcidWallStudio.AcidUtilities;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Polyline2D : Line2D
{
    public event Action OnAnimationEnded;
    
    [Export] private int _minLength = 4;
    [Export] private int _maxLength = 6;
    
    [Export] private float _minDegrees = -80f;
    [Export] private float _maxDegrees = 80f;
    
    [Export] private float _minStep = 200f;
    [Export] private float _maxStep = 300f;

    public override async void _Ready()
    {
        Generate();
        await ToSignal(GetTree().CreateTimer(2.0), Timer.SignalName.Timeout);
        OnAnimationEnded?.Invoke();
        QueueFree();
    }

    private void Generate()
    {
        ClearPoints();
        var length = Random.Shared.Next(_minLength, _maxLength);
        for (int i = 0; i < length; i++)
        {
            AddPoint();
        }
    }

    private void AddPoint()
    {
        if (GetPointCount() == 0)
        {
            AddPoint(ToLocal(GlobalPosition));
            return;
        }

        var point = GetPoints()[GetPoints().Length - 1];
        
        var angle = Random.Shared.FloatRange(_minDegrees, _maxDegrees);
        var step = Random.Shared.FloatRange(_minStep, _maxStep);
        
        AddPoint(point + Vector2.Right.Rotated(Mathf.DegToRad(angle)) * step);
    }
}