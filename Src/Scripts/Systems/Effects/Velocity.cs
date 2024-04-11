using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class Velocity : Effect
{
    public override void OnCreate()
    {
        // + 20% 武器射击速度
        // + 5% 武器伤害
        AddModifierToTarget(
            new StatModifier(0.2f, StatModType.PercentAdd, this),
            Target.Stats.ShootSpeed
            );
        AddModifierToTarget(
            new StatModifier(0.05f, StatModType.PercentAdd, this),
            Target.Stats.Damage
            );
    }

    public override void OnDestroy()
    {
        Target.Stats.ShootSpeed.RemoveAllModifiersFromSource(this);
        Target.Stats.Damage.RemoveAllModifiersFromSource(this);
    }
}