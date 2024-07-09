namespace NovaDrift.Scripts.Systems.Effects;

public class RapidReconstruction : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[0]), Target.Stats.Health.MaxValue);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Target.Stats.Regeneration);
    }
}