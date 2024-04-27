using System;
using AcidWallStudio.AcidNodes;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;

public partial class BulletBase : CharacterBody2D
{
    [Export] private HitBox _hitBox;
 
    public event Action<float> OnMove;
    public event Action<Actor> OnHit;
    
    public bool IsPlayer = false;
    
    public float Speed = 1300f;
    public float Size = 1f;
    public float Degeneration = 0.8f;

    private SmokeTrail _smokeTrail;

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
    private Vector2 _dir;
    
    public override void _Ready()
    {
        _smokeTrail = GetNode<SmokeTrail>("%SmokeTrail");
        
        _hitBox.SetIsPlayer(IsPlayer);
        _hitBox.HitDone += (actor) =>
        {
            OnHit?.Invoke(actor);
            QueueFree();
        };

        Scale = new Vector2(Size, Size);
        _dir = Vector2.Right.Rotated(GlobalRotation);
        
        Tween tween = CreateTween();
        tween.TweenProperty(this, "scale", Vector2.Zero, Degeneration);
        tween.Finished += QueueFree;
    }

    public void AddModifierToDamage(StatModifier modifier)
    {
        _damage.AddModifier(modifier);
        _hitBox.Damage = _damage.Value;
    }

    public override void _PhysicsProcess(double delta)
    {
        _smokeTrail.AddAgePoint(GlobalPosition);
        OnMove?.Invoke(GlobalPosition.DistanceTo(_lastPosition));
        
        Velocity = _dir * Speed;
        MoveAndSlide();
        
        _lastPosition = GlobalPosition;
    }
}
