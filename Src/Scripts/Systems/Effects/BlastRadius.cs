namespace NovaDrift.Scripts.Systems.Effects;

public class BlastRadius : Effect
{
    // +10% 爆炸半径
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.BlastRadius);
    }
}