using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HurtBox : Area2D
{
    [Export] private Actor _actor;
    public Layer Layer
    {
        get => _layer;
        set
        {
            _layer = value;
            Init();
        }
    }
    public Layer Mask
    {
        get => _mask;
        set
        {
            _mask = value;
            Init();
        }
    }
    
    private Layer _layer = Layer.Player;
    private Layer _mask = Layer.Mob;

    public override void _Ready()
    {
        Init();
        AreaEntered += delegate(Area2D area)
        {
            if (area is HitBox hitBox)
            {
                
                // _actor.CharacterStats.Health.Value -= hitBox.Damage;
            }
        };
    }

    private void Init()
    {
        CollisionLayer = 0;
        CollisionMask = 0;
        CallDeferred("set_collision_layer_value", (int)_layer, true);
        CallDeferred("set_collision_mask_value", (int)_mask, true);
    }
}