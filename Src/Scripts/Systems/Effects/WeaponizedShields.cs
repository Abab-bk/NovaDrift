using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Systems.Effects;

public class WeaponizedShields : Effect
{
    private StatModifier _modifier;
    public override void OnCreate()
    {
        base.OnCreate();
        _modifier = DataBuilder.BuildPercentAddModifier(Values[0]);
        Target.Shield.OnBodyEntered += node2D =>
        {
            if (node2D is not MobBase mobBase) return;
            if (mobBase.Stats.InjuryFactor.HasModifier(_modifier)) return;
            AddModifierToTarget(_modifier, mobBase.Stats.InjuryFactor);
        };

        Target.Shield.OnBodyExited += node2D =>
        {
            if (node2D is not MobBase mobBase) return;
            mobBase.Stats.InjuryFactor.RemoveModifier(_modifier);
        };
    }
}