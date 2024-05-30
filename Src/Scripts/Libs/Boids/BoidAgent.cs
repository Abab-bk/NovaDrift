using System.Collections.Generic;
using System.Linq;
using Godot;

namespace NovaDrift.Scripts.Libs.Boids;

[GlobalClass]
public partial class BoidAgent : Node2D
{
    [Export] private Node2D _owner;
    [Export] private Area2D _rangeArea;
    [Export] private bool _debugDraw = true;
    
    public List<string> BoidGroupNames = new ();
    
    private List<Node2D> _boidsInRange = new ();

    public override void _Ready()
    {
        _rangeArea.BodyEntered += body =>
        {
            foreach (var groupName in BoidGroupNames)
            {
                if (!body.IsInGroup(groupName)) continue;
                if (_boidsInRange.Contains(body)) continue;
                if (body == _owner) continue;
                _boidsInRange.Add(body);
            }
        };

        _rangeArea.BodyExited += body => { _boidsInRange.Remove(body); };
    }

    public void FindTargets()
    {
        _boidsInRange.Clear();
        foreach (var groupName in BoidGroupNames)
        {
            foreach (var node in GetTree().GetNodesInGroup(groupName))
            {
                if (node is not Node2D node2D) return;
                if (!_rangeArea.GetOverlappingBodies().Contains(node2D)) continue;
                if (node == _owner) continue;
                _boidsInRange.Add(node2D);
            }
        }
    }

    private Vector2 SteerSeparation()
    {
        var dir = Vector2.Zero;
        
        foreach (var boid in _boidsInRange)
        {
            var ratio = ((boid.GlobalPosition - GlobalPosition).Length() / 20f) > 0f ? 1f : 0f;
            dir += GlobalPosition.DirectionTo(boid.GlobalPosition) * ratio;
        }
        
        return dir.Normalized();
    }

    public override void _Process(double delta)
    {
        if (_debugDraw) QueueRedraw();
    }

    public override void _Draw()
    {
        if (!_debugDraw) return;

        foreach (var boid in _boidsInRange)
        {
            DrawLine(Vector2.Zero, ToLocal(boid.GlobalPosition), Colors.Red, 10f);
        }
    }
}