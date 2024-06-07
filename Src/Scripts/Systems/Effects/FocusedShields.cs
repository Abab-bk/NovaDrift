namespace NovaDrift.Scripts.Systems.Effects;

public class FocusedShields : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.ShieldPower);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.MaxShield);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.ShieldRadius);
    }
}