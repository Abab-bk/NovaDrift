using System;
using Godot;

namespace NovaDrift.Scripts.Vfx;

public abstract partial class BaseVfx : Node2D
{
    public Action OnAnimationEnd;
    public bool IsPlayer;

    public override void _Ready()
    {
        OnAnimationEnd += QueueFree;
    }
}

public static class Area2DExtensions
{
    public static void SetIsPlayer(this Area2D area2D, bool isPlayer)
    {
        area2D.CollisionLayer = 0;
        area2D.CollisionMask = 0;
        
        if (isPlayer)
        {
            area2D.SetCollisionLayer((int)Layer.Player);
            area2D.SetCollisionMask((int)Layer.Mob);
        }
        else
        {
            area2D.SetCollisionLayer((int)Layer.Mob);
            area2D.SetCollisionMask((int)Layer.Player);
        }
    }
}