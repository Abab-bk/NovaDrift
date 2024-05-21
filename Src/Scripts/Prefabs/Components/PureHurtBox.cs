using System;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class PureHurtBox : Area2D
{
    public Action<float> OnHurt;
    public Action<float, Node2D> OnHurtWithSource;

    public override void _Ready()
    {
        AreaEntered += area =>
        {
            if (area is HitBox hitBox)
            {
                hitBox.OnHitOthers?.Invoke();
                TakeDamage(hitBox.Damage);
            }
        };
    }

    private void TakeDamage(float damage) => OnHurt?.Invoke(damage);
}