namespace NovaDrift.Scripts.Systems.Effects;

public class RadiantShields : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.ShieldRadius);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.ShieldCoolDown);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.MaxShield);
    }
}