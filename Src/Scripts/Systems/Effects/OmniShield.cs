namespace NovaDrift.Scripts.Systems.Effects;

public class OmniShield : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[0]), Target.Stats.MaxShield);
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[1]), Target.Stats.ShieldDamageResistance);
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[2]), Target.Stats.ShieldPower);
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[3]), Target.Stats.Health.MaxValue);
    }
}