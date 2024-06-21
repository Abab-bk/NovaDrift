using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class SnakeBody : Node2D
{
    [Export] private HitBox _area;

    public Actor Actor;
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
        var dir = Actor.Transform.X;
        _velocity = dir * Actor.Stats.Speed.Value;
        GlobalPosition += _velocity * (float)delta;
    }
}
