using System;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HurtBox : Area2D
{
    [Export] public Actor Actor;
    private bool _isPlayer = false;

    public event Action<float> OnHit;
    
    public void SetIsPlayer(bool value)
    {
        _isPlayer = value;
        Init();
    }

    public override void _Ready()
    {
        AreaEntered += (Area2D area) =>
        {
            if (area is HitBox hitBox)
            {
                var damage = Actor.GetRealDamage(hitBox.Damage);
                Actor.Stats.Health.Decrease(damage);
                OnHit?.Invoke(damage);
                hitBox.OnHit?.Invoke((Actor)Owner);
            }
        };
    }

    private void Init()
    {
        CollisionLayer = 0;
        CollisionMask = 0;
        
        if (_isPlayer)
        {
            CallDeferred("set_collision_layer_value", (int)Layer.PlayerHurtBox, true);
            CallDeferred("set_collision_mask_value", (int)Layer.MobHitBox, true);
            return;
        }
        CallDeferred("set_collision_layer_value", (int)Layer.MobHurtBox, true);
        CallDeferred("set_collision_mask_value", (int)Layer.PlayerHitBox, true);
    }
}