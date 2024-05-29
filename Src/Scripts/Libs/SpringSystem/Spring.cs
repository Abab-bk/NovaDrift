using System.Collections.Generic;
using Godot;

namespace AcidWallStudio.SpringSystem;

public enum SpringType
{
    Push,
    Pull,
}

public class SpringInfo(SpringType type, Node2D target, float force)
{
    public readonly SpringType Type = type;
    public readonly Node2D Target = target;
    public readonly float Force = force;
}

[GlobalClass]
public partial class Spring : Node2D
{
    [Export] public bool EnabledDraw;
    
    private readonly List<SpringInfo> _targetPoints = new ();
    
    public Vector2 GetMovement()
    {
        var movement = Vector2.Zero;
        
        foreach (var springInfo in _targetPoints)
        {
            if (springInfo.Type == SpringType.Push)
            {
                var target = springInfo.Target;
                var dir = GlobalPosition.DirectionTo(target.GlobalPosition);
                var distance = GlobalPosition.DistanceTo(target.GlobalPosition);
                var springForce = springInfo.Force / (springInfo.Force + distance * distance * distance);
                movement -= dir * springForce;
                continue;
            }

            var pullTarget = springInfo.Target;
            var pullDir = GlobalPosition.DirectionTo(pullTarget.GlobalPosition);
            var pullDistance = GlobalPosition.DistanceTo(pullTarget.GlobalPosition);
            var pushSpringForce = pullDistance - springInfo.Force;
            movement += pullDir * pushSpringForce;
        }
        return movement.Normalized();
    }
    
    public void RemoveTargetPoint(Node2D target)
    {
        _targetPoints.RemoveAll(x => x.Target == target);
    }

    public void AddTargetPoint(SpringInfo info)
    {
        _targetPoints.Add(info);
    }
    
    public void RemoveTargetPoint(SpringInfo info)
    {
        _targetPoints.Remove(info);
    }


    public override void _Draw()
    {
        if (!EnabledDraw) return;
        foreach (var targetPoint in _targetPoints)
        {
            if (targetPoint.Type == SpringType.Pull)
            {
                DrawLine(Vector2.Zero, ToLocal(targetPoint.Target.GlobalPosition), Colors.Green, 10f);
                continue;
            }

            DrawLine(Vector2.Zero, ToLocal(targetPoint.Target.GlobalPosition), Colors.Red, 10f);
        }
    }

    public override void _Process(double delta)
    {
        if (EnabledDraw) QueueRedraw();
    }
}