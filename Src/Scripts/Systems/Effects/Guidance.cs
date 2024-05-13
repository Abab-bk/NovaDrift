namespace NovaDrift.Scripts.Systems.Effects;

public class Guidance : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Targeting);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.BulletSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.ShootSpeed);
    }
}