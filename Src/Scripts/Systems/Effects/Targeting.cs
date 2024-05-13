namespace NovaDrift.Scripts.Systems.Effects;

public class Targeting : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();

        if (Target.Stats.Targeting.Value <= 0)
        {
            AddModifierToTarget(DataBuilder.BuildFlatModifier(
                Values[0]), Target.Stats.Targeting);
        }
        else
        {
            AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
                Values[1]), Target.Stats.Targeting);
        }
    }
}