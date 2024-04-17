using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;

public interface IBullet
{
}

public partial class BulletBase : CharacterBody2D, IBullet
{
    [Export] private HitBox _hitBox;
    
    public bool IsPlayer = false;
    
    public float Speed = 1300f;

    public float Damage
    {
        get => _damage;
        set
        {
            _damage = value;
            _hitBox.Damage = _damage;
        }
    }

    private float _damage = 10f;
    public Vector2 TargetDir = new Vector2(0, 0);
    
    public override void _Ready()
    {
        _hitBox.SetIsPlayer(IsPlayer);
        _hitBox.HitDone = QueueFree;
        
        Velocity = GlobalPosition.DirectionTo(TargetDir) * Speed;
    }
    

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
}
