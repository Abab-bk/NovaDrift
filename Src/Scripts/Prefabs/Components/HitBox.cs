using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HitBox : Area2D
{
    [Export] public bool IsWorld = false;
    
    private bool _isPlayer = false;
    public float Damage = 1f;
    
    public Action<Actor> OnHit;
    public Action OnHitOthers;
    
    public void SetIsPlayer(bool value)
    {
        _isPlayer = value;
        Init();
    }

    private void Init()
    {
        CollisionLayer = 0;
        CollisionMask = 0;

        if (_isPlayer || IsWorld)
        {
            CallDeferred("set_collision_layer_value", (int)Layer.PlayerHitBox, true);
            CallDeferred("set_collision_mask_value", (int)Layer.MobHurtBox, true);
        }

        if (!_isPlayer || IsWorld)
        {
            CallDeferred("set_collision_layer_value", (int)Layer.MobHitBox, true);
            CallDeferred("set_collision_mask_value", (int)Layer.PlayerHurtBox, true);
        }
    }
}
