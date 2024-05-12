namespace NovaDrift.Scripts.Systems.Effects;

public class HullStrength : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Health.MaxValue);
    }
}