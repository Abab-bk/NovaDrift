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

public static class CollisionObjectExtensions
{
    public static void SetIsPlayer(this CollisionObject2D source, bool isPlayer)
    {
        source.CollisionLayer = 0;
        source.CollisionMask = 0;
        
        if (isPlayer)
        {
            source.SetCollisionLayerValue((int)Layer.Player, true);
            source.SetCollisionMaskValue((int)Layer.Mob, true);
        }
        else
        {
            source.SetCollisionLayerValue((int)Layer.Mob, true);
            source.SetCollisionMaskValue((int)Layer.Player, true);
        }
        
        source.SetCollisionMaskValue((int)Layer.Object, true);
    }
}