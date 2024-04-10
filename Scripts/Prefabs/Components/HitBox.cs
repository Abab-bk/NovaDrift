using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HitBox : Area2D
{
    private bool _isPlayer = false;
    public float Damage = 1f;
    
    public delegate void HitDoneHandler();
    public HitDoneHandler HitDone;
    
    public void SetIsPlayer(bool value)
    {
        _isPlayer = value;
        Init();
    }

    private void Init()
    {
        CollisionLayer = 0;
        CollisionMask = 0;

        if (_isPlayer)
        {
            CallDeferred("set_collision_layer_value", (int)Layer.PlayerHitBox, true);
            CallDeferred("set_collision_mask_value", (int)Layer.MobHurtBox, true);
            return;
        }
        CallDeferred("set_collision_layer_value", (int)Layer.MobHitBox, true);
        CallDeferred("set_collision_mask_value", (int)Layer.PlayerHurtBox, true);
    }
}
