using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems.BulletPatterns;

public abstract class BulletPattern
{
    public abstract void SetPattern(BulletBase bullet, Actor actor, int bulletCount, int bulletIndex);
}