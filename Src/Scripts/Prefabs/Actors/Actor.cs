using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    [Export] private Shooter _shooter;
    [Export] private HurtBox _hurtBox;
    
    [Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
    [Export] public bool IsPlayer = false;

    public CharacterStats Stats = new CharacterStats();
    public float ShootCd = 1f;

    private void InitCollision()
    {
        CollisionLayer = 0;
        CollisionMask = 0;
        
        if (IsPlayer)
        {
            CallDeferred("set_collision_layer_value", (int)Layer.Player, true);
            return;
        }
        CallDeferred("set_collision_layer_value", (int)Layer.Mob, true);
    }

    public override void _Ready()
    {
        InitStats();
        InitCollision();

        _hurtBox.SetIsPlayer(IsPlayer);
        
        _visibleOnScreenNotifier2D.ScreenExited += MoveToWorldEdge;
    }

    public virtual void Die()
    {
        QueueFree();
    }

    private void MoveToWorldEdge()
    {
        Vector2 newPos = GlobalPosition;
        if (GlobalPosition.X < 0)
        {
            newPos.X = 2560;
        }

        if (GlobalPosition.X > 2560)
        {
            newPos.X = 0;
        }
        
        if (GlobalPosition.Y < 0)
        {
            newPos.Y = 1440;
        }
        
        if (GlobalPosition.Y > 1440)
        {
            newPos.Y = 0;
        }

        GlobalPosition = newPos;
    }

    protected virtual void InitStats()
    {
    }

    protected virtual void Shoot(Vector2 targetDir)
    {
        _shooter.Shoot(targetDir);
    }
    
}
