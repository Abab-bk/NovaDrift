using System;
using Godot;
using NovaDrift.addons.AcidUtilities;

namespace NovaDrift.Scripts.Prefabs.Components;

public partial class PathLine2D : Line2D, ICollisionLine2D
{
    public event Action<Vector2> OnPointAdded;
    
    [Export] public float Length = 10f;
    [GetNode] private Node2D _parent;

    private Vector2 _offset = Vector2.Zero;
    private Vector2 _lastPos = Vector2.Zero;

    public override void _Ready()
    {
        if (GetParent() is Node2D parent)
        {
            _parent = parent;
        }

        _offset = Position;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        GlobalPosition = Vector2.Zero;

        var point = _parent.GlobalPosition + _offset;
        
        if (point == _lastPos) return;
        
        _lastPos = point;
        AddPoint(ToLocal(point), 0);
        OnPointAdded?.Invoke(point);
        
        if (GetPointCount() > Length)
        {
            RemovePoint(GetPointCount() - 1);
        }
    }
}