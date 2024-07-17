using Godot;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class SnakeBody : Node2D
{
    [Export] private HitBox _area;

    public bool IsHead;

    public float Speed = 100f;
    public float TurnSpeed = 5f;

    public MarkerManager MarkerManager;
    
    public SnakeBody Next;
    public SnakeBody Previous;

    public void UpdatePosition()
    {
    }

    public override void _Ready()
    {
        MarkerManager = new MarkerManager();
        AddChild(MarkerManager);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsHead) return;
        Rotation = Mathf.LerpAngle(Rotation, GlobalPosition.AngleToPoint(GetGlobalMousePosition()), TurnSpeed * (float)delta);
        Position += Transform.X * Speed * (float)delta;
    }
}
