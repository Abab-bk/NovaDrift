using Godot;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems.BulletPatterns;

public class ShotGunPattern : BulletPattern
{
    public override void SetPattern(
        BulletBase bullet,
        Actor actor,
        int bulletCount,
        int bulletIndex)
    {
        if (bulletCount == 1)
        {
            bullet.Direction = bullet.Direction.Rotated(actor.GlobalRotation);
        }
        else
        {
            float arcRad = Mathf.DegToRad(actor.Stats.ShootSpread.Value);
            float increment = arcRad / (bulletCount - 1);
            bullet.Direction = bullet.Direction.Rotated(actor.GlobalRotation + increment * bulletIndex - arcRad / 2);
        }
    }
}