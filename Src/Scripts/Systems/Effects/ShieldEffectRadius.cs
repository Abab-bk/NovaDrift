namespace NovaDrift.Scripts.Systems.Effects;

public class ShieldEffectRadius : Effect
{
    public override void OnCreate()
    {
        /*
         * +25% 护盾效果半径
            +10% 护盾效果强度
         */
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.ShieldRadius);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.ShieldPower);
    }
}