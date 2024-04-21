using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class BurstFire : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(new StatModifier(
            Values[0], StatModType.Flat), Target.Stats.BurstFire);
        AddModifierToTarget(new StatModifier(
            Values[1], StatModType.PercentAdd), Target.Stats.ShootSpeed);
    }
}