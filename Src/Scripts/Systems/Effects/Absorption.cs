namespace NovaDrift.Scripts.Systems.Effects;

public class Absorption : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildFlatModifier(
            Values[0]), Target.Stats.Plating);
    }
}