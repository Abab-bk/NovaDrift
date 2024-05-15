namespace NovaDrift.Scripts.Systems.Effects;

public class Streamline : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        /*
         * '+25% 推力
            -10% 大小
            -10% 最大血量
            -20% 碰撞伤害和对目标的击退效果
            -20% 碰撞击退抵抗
         */
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Acceleration);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.Size);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.Health.MaxValue);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[3]), Target.Stats.ImpactDamage);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[3]), Target.Stats.ShootKnockBack);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[4]), Target.Stats.ImpactKnockBackResistance);
    }
}