using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HitBox : Area2D
{
    public float Damage = 10f;
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
    }

    private void Init()
    {
        CollisionLayer = 0;
        CollisionMask = 0;
        CallDeferred("set_collision_layer_value", (int)_layer, true);
        CallDeferred("set_collision_mask_value", (int)_mask, true);
    }
}
