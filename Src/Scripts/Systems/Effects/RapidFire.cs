using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class RapidFire : Effect
{
    public override void OnCreate()
    {
        AddModifierToTarget(new StatModifier(
            -0.15f, StatModType.PercentAdd, this),
            Target.Stats.ShootSpeed
            );
    }
}