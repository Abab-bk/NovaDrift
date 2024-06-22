using Godot;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Systems.Bodies;

public class Breaker : Body
{
    public override void Use()
    {
        base.Use();
        Actor.OnHurt += _ =>
        {
            BulletBase bullet = Actor.Shooter.GetBulletFunc.Invoke(Actor.Shooter);
                
            bullet.GlobalPosition = Actor.Shooter.GlobalPosition;
            bullet.Direction = bullet.Direction.Rotated(Actor.Shooter.GlobalRotation);

            Global.GameWorld.CallDeferred(Node.MethodName.AddChild, bullet);
            
            Actor.OnShoot?.Invoke(bullet);
            bullet.OnHit += actor => { Actor.Shooter.OnHit?.Invoke(actor); };
        };
    }
}