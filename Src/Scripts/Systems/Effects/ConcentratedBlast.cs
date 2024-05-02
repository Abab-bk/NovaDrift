namespace NovaDrift.Scripts.Systems.Effects;

public class ConcentratedBlast : Effect
{
    /*
     * "+35% 爆炸伤害
        -30% 爆炸半径"
     */

    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.BlastDamage);
        AddModifierToTarget(DataBuilder.BuildPercentMultModifier(
            Values[1]), Target.Stats.BlastRadius);
    }
}