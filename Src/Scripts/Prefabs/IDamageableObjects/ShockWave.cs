using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs.IDamageableObjects;

public partial class ShockWave : Node2D, IDamageable
{
    public bool IsPlayer;
    
    private const float MaxDistance = 4000f;
    
    private Line2D _line;
    private RayCast2D _cast;
    private float _speed = 2000f;
    
    private Vector2 _dir;
    
    private bool _emitted = false;

    private float _damage;

    public void SetDamage(float v)
    {
        _damage = v;
    }

    public override void _Ready()
    {
        _line = new Line2D();
        _cast = new RayCast2D();
        
        AddChild(_line);
        AddChild(_cast);

        _cast.SetCollisionMask(0);
        
        if (IsPlayer)
        {
            _cast.SetCollisionMaskValue((int)Layer.Mob, true);
        }
        else
        {
            _cast.SetCollisionMaskValue((int)Layer.Player, true);
        }

        _line.ClearPoints();
        _line.AddPoint(Vector2.Zero, 0);
        _line.AddPoint(Vector2.Zero, 1);
    }
    
    public void Emit(Vector2 dir)
    {
        _dir = dir;
        _emitted = true;
        _cast.TargetPosition = dir * 50;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!_emitted) return;
        _line.SetPointPosition(1, _line.GetPointPosition(1) + _dir * _speed * (float)delta);
        _cast.GlobalPosition = ToGlobal(_line.GetPointPosition(1));
        var collider = _cast.GetCollider();

        if (_line.GetPointPosition(1).Length() >= MaxDistance)
        {
            QueueFree();
            return;
        }

        if (collider == null) return;
        
        if (collider is Actor actor)
        {
            actor.TakeDamageWithoutKnockBack(_damage);
            QueueFree();
        }
    }
}
