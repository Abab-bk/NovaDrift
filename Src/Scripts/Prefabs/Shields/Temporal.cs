using Godot;
using System;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class Temporal : BaseShield
{
    private float _originalSpeed;
    
    protected override void OnBodyEntered(Node2D body)
    {
        base.OnBodyEntered(body);
        if (body is not Actor actor) return;
        actor.Stats.Speed.AddModifier(new StatModifier(
            -Values[0], StatModType.PercentMult, this));
    }

    protected override void OnAreaEntered(Area2D area)
    {
        base.OnAreaEntered(area);
        if (area is not HitBox hitBox) return;
        if (hitBox.Owner is not BulletBase bullet) return;
        if (bullet.IsPlayer) return;
        
        _originalSpeed = bullet.Speed;
        bullet.Speed *= Values[0];
    }

    protected override void OnBodyExited(Node2D body)
    {
        base.OnBodyExited(body);
        if (body is not Actor actor) return;
        actor.Stats.Speed.RemoveAllModifiersFromSource(this);
    }

    protected override void OnAreaExited(Area2D area)
    {
        base.OnAreaExited(area);
        if (area is not HitBox hitBox) return;
        if (hitBox.Owner is not BulletBase bullet) return;
        if (bullet.IsPlayer) return;
        bullet.Speed = _originalSpeed;
    }
}
