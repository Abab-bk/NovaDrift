using Godot;

namespace NovaDrift.Scripts.Prefabs;

public interface IBullet
{
    public BulletBase SetTargetDir(Vector2 target);
}

public partial class BulletBase : CharacterBody2D, IBullet
{
    public float Speed = 500f;
    private Vector2 TargetDir = new Vector2(0, 0);

    public BulletBase SetTargetDir(Vector2 target)
    {
        TargetDir = target;
        return this;
    }

    public override void _Ready()
    {
        Velocity = GlobalPosition.DirectionTo(TargetDir) * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}
