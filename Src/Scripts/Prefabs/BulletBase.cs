using System;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;

public interface IBullet
{
}

public partial class BulletBase : CharacterBody2D, IBullet
{
    [Export] private HitBox _hitBox;
 
    public event Action<float> OnMove;
    public event Action<Actor> OnHit;
    
    public bool IsPlayer = false;
    
    public float Speed = 1300f;

    public float Damage
    {
        get => _damage.Value;
        set
        {
            _damage.BaseValue = value;
            _hitBox.Damage = value;
        }
    }

    private Stat _damage = new Stat(1f);
    private Vector2 _lastPosition = new Vector2();
    
    public Vector2 TargetDir = new Vector2(0, 0);
    
    public override void _Ready()
    {
        _hitBox.SetIsPlayer(IsPlayer);
        _hitBox.HitDone += (actor) =>
        {
            OnHit?.Invoke(actor);
            QueueFree();
        };

        Velocity = GlobalPosition.DirectionTo(TargetDir) * Speed;
    }

    public void AddModifierToDamage(StatModifier modifier)
    {
        _damage.AddModifier(modifier);
        _hitBox.Damage = _damage.Value;
    }

    public override void _PhysicsProcess(double delta)
    {
        OnMove?.Invoke(GlobalPosition.DistanceTo(_lastPosition));
        MoveAndSlide();
        _lastPosition = GlobalPosition;
    }
}
