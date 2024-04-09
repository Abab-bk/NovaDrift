using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HurtBox : Area2D
{
    [Export] private Actor _actor;

    public bool IsPlayer
    {
        get => _isPlayer;
        set
        {
            _isPlayer = value;
            Init();
        }
    }

    private bool _isPlayer = false;
    
    public override void _Ready()
    {
        IsPlayer = _actor.IsPlayer;
        AreaEntered += delegate(Area2D area)
        {
            if (area is HitBox hitBox)
            {
                _actor.Stats.Health.AddModifier(new StatModifier(
                    -hitBox.Damage,
                    StatModType.Flat));
                
                hitBox.HitDone?.Invoke();
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