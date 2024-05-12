namespace NovaDrift.Scripts.Systems.Effects;

public class Juggernaut : Effect
{
    /*
     *  +25% 最大生命
        +40% 撞击伤害和击退效果对目标
        +20% 撞击击退抗性
        -25% 推力
     */

    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Health.MaxValue);
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.ShootKnockBack);
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.Recoil);
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[3]), Target.Stats.Acceleration);
    }
}