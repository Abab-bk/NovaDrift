using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HitBox : Area2D
{
    [Export] public bool IsWorld;
    
    private bool _isPlayer;
    public float Damage = 1f;
    
    // TODO: 这里不调用，因为这俩事件是从HurtBox发出的，有点奇怪，应该修改
    public Action<Actor> OnHit;
    public Action OnHitOthers;

    public event Action<Node2D> OnHitSomething;

    public override void _Ready()
    {
        BodyEntered += body => OnHitSomething?.Invoke(body);
    }

    public HitBox SetIsPlayer(bool value)
    {
        _isPlayer = value;
        Init();
        return this;
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
