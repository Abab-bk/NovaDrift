using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class SnakeBody : Node2D
{
    [Export] private HitBox _area;

    public Node2D Target;
    private Vector2 _velocity;

    public override void _Ready()
    {
        _area.SetIsPlayer(true);
    }

    public void SetDamage(float value)
    {
        _area.Damage = value;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        if (GlobalPosition.DistanceTo(Target.GlobalPosition) < 70f) return;
        
        var dir = GlobalPosition.DirectionTo(Target.GlobalPosition);
        _velocity = dir * Global.Player.Stats.Speed.Value;
        // Rotation = dir.Angle();
        GlobalPosition += _velocity * (float)delta;
    }
}
