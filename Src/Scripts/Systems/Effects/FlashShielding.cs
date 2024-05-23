namespace NovaDrift.Scripts.Systems.Effects;

public class FlashShielding : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.ShieldCoolDown);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.MaxShield);
    }
}