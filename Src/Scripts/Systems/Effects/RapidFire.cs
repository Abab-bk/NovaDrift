using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class RapidFire : Effect
{
    public override void OnCreate()
    {
        AddModifierToTarget(new StatModifier(
            Values[0], StatModType.PercentAdd, this),
            Target.Stats.ShootSpeed
            );
    }
}