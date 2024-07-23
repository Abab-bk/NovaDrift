using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Vfx;

public abstract partial class BaseVfx : Node2D
{
    public Action OnAnimationEnd;
    public bool IsPlayer;
    public ActionData ActionData;

    public override void _Ready()
    {
        OnAnimationEnd += QueueFree;
    }
}

public static class CollisionObjectExtensions
{
    public static void SetIsPlayer(this CollisionObject2D source, bool isPlayer)
    {
        source.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayer, 0);
        source.CallDeferred(CollisionObject2D.MethodName.SetCollisionMask, 0);
        
        if (source is Actor)
        {
            if (isPlayer)
            {
                source.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, (int)Layer.Player, true);
            }
            else
            {
                source.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, (int)Layer.Mob, true);
            }
        }
        else
        {
            if (isPlayer)
            {
                source.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, (int)Layer.Player, true);
                source.CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, (int)Layer.Mob, true);
            }
            else
            {
                source.CallDeferred(CollisionObject2D.MethodName.SetCollisionLayerValue, (int)Layer.Mob, true);
                source.CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, (int)Layer.Player, true);
            }
        }

        source.CallDeferred(CollisionObject2D.MethodName.SetCollisionMaskValue, (int)Layer.Object, true);
    }
}