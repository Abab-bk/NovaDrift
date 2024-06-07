using System;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.addons.AcidUtilities;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Polyline2D : Line2D, ICollisionLine2D
{
    [Export] private int _minLength = 4;
    [Export] private int _maxLength = 6;
    
    [Export] private float _minDegrees = -80f;
    [Export] private float _maxDegrees = 80f;
    
    [Export] private float _minStep = 500f;
    [Export] private float _maxStep = 800f;

    public Area2D Area2D;

    public override void _Ready()
    {
        Area2D = new Area2D();
        AddChild(Area2D);
        Generate();
    }

    private void Generate()
    {
        ClearPoints();

        foreach (var node in Area2D.GetChildren())
        {
            node.QueueFree();
        }
        
        var length = Random.Shared.Next(_minLength, _maxLength);
        for (int i = 0; i < length; i++)
        {
            AddPoint();
        }
        
        ((ICollisionLine2D)this).GenerateCollision(this, Area2D);
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