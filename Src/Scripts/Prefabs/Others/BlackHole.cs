using Godot;
using System;
using System.Collections.Generic;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Others;
public partial class BlackHole : Node2D
{
    private float _mass = 30000f;
    private List<Actor> _actors = new List<Actor>();
    
    public override void _Ready()
    {
        GetTree().NodeAdded += node =>
        {
            if (node is Actor actor)
            {
                _actors.Add(actor);
            }
        };

        foreach (var actor in GetTree().GetNodesInGroup("Actors"))
        {
            if (actor is Actor actor1)
            {
                _actors.Add(actor1);
            }
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Apply();
    }

    private void Apply()
    {
        foreach (var actor in _actors)
        {
            var dir = actor.GlobalPosition.DirectionTo(GlobalPosition);
            var distance = GlobalPosition.DistanceTo(actor.GlobalPosition);
            var force = _mass / distance;
            var forceVector = dir * force;
            actor.Stats.ForceVector = forceVector;
        }
    }
}
