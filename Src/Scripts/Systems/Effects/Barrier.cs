using System;

namespace NovaDrift.Scripts.Systems.Effects;

public class Barrier : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        Target.Shield.LimitMaxValue = f => MathF.Min(Values[0], f);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.ShieldCoolDown);
    }
}