using Godot;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems.BulletPatterns;

public class CirclePattern : BulletPattern
{
    public override void SetPattern(BulletBase bullet, Actor actor, int bulletCount, int bulletIndex)
    {
        bullet.Direction = bullet.Direction.Rotated(Mathf.DegToRad((360f / bulletCount) * bulletIndex + 1));
    }
}