using Godot;
using System;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Hazards;

public partial class AsteroidBase : Hazard
{
    [Export] private float _health = 100f;
    [Export] private PureHurtBox _hurtBox;
    
    public override void _Ready()
    {
        base._Ready();
        _hurtBox.OnHurt += (f, _) =>
        {
            _health -= f;
            if (_health <= 0) Destroy();
        };

        this.TweenRotation(360f, 10f).SetLoops(10).Play();
    }

    protected virtual void Destroy()
    {
        QueueFree();
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += Vector2.Right.Rotated(GlobalRotation) * 100 * (float)delta;
    }
}
