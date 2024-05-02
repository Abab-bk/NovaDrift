namespace NovaDrift.Scripts.Systems.Effects;

public class Payload : Effect
{
    public override void OnCreate()
    {
        /*
         * "+30% 武器伤害
            +12% 武器射弹大小
            +5% 武器爆炸半径
            -12% 武器射速"
         */
        
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Damage);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.BulletSize);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.BlastRadius);
        AddModifierToTarget(DataBuilder.BuildPercentMultModifier(
            Values[3]), Target.Stats.ShootSpeed);
    }
}