using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Ai;

public interface IBossAiHelper
{
    public BulletBase GetSpecialBullet(MobBase mob, string bulletPath)
    {
        var bullet = new BulletBuilder()
            .SetBulletBase(bulletPath)
            .SetOwner(mob)
            .SetIsPlayer(mob.IsPlayer)
            .SetDamage(mob.Stats.Damage.Value)
            .SetSpeed(mob.Stats.BulletSpeed.Value)
            .SetSize(mob.Stats.BulletSize.Value)
            .SetDegeneration(mob.Stats.BulletDegeneration.Value)
            .SetSteering(mob.Stats.Targeting.Value)
            .Build();
        
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, bullet);
        return bullet;
    }
}