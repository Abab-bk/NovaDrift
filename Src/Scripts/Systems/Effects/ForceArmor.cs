using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems.Effects;

public class ForceArmor : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        /*
         * '+10% 船体伤害抗性
            +20% 撞击击退效果对目标
            +20% 撞击击退抗性
            当你直接撞击船体时，你会对附近目标造成相当于撞击伤害25%的爆炸伤害。
         */
        
        AddModifierToTarget(
            DataBuilder.BuildPercentAddModifier(Values[0]), Target.Stats.DamageResistance);
        AddModifierToTarget(
            DataBuilder.BuildPercentAddModifier(Values[1]), Target.Stats.ShootKnockBack);
        AddModifierToTarget(
            DataBuilder.BuildPercentAddModifier(Values[2]), Target.Stats.ImpactKnockBackResistance);

        Target.OnHitSomeThing += (body) =>
        {
            if (body is not Actor actor) return;
            actor.TakeDamageWithoutKnockBack(Target.Stats.ImpactDamage.Value * Values[3]);
        };
    }
}