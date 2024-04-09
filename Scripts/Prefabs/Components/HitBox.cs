using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HitBox : Area2D
{
    [Export] public bool IsPlayer
    {
        get => _isPlayer;
        set
        {
            _isPlayer = value;
            Init();
        }
    }
    
    private bool _isPlayer = false;
    public float Damage = 10f;
    
    public delegate void HitDoneHandler();
    public HitDoneHandler HitDone;

    public override void _Ready()
    {
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
