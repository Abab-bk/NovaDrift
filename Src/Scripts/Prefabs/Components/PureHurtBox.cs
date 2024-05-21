using System;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class PureHurtBox : Area2D
{
    public Action<float, Node2D> OnHurt;

    public override void _Ready()
    {
        AreaEntered += area =>
        {
            if (area is HitBox hitBox)
            {
                hitBox.OnHitOthers?.Invoke();
                TakeDamage(hitBox.Damage, area);
            }
        };
    }

    private void TakeDamage(float damage, Node2D node2D) => OnHurt?.Invoke(damage, node2D);
}