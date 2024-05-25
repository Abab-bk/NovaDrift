using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class GrenadeShooter : Shooter
{
    public override void _Ready()
    {
        GetBulletFunc = (shooter) => new BulletBuilder(BulletBuilder.BulletType.Grenade)
            .SetIsPlayer(IsPlayer)
            .SetOwner(Actor)
            .SetDamage(Actor.Stats.Damage.Value)
            .SetDegeneration(Actor.Stats.BulletDegeneration.Value)
            .SetSize(Actor.Stats.Size.Value)
            .SetSpeed(Actor.Stats.BulletSpeed.Value * 0.5f)
            .SetSteering(Actor.Stats.Targeting.Value)
            .Build();
        Init();
    }
}
