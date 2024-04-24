namespace NovaDrift.Scripts.Systems.Effects;

public class Volley : Effect
{
    public override void OnCreate()
    {
        
        /*
         *
         *  +2 武器射弹
            -20% 武器射弹爆炸半径和总射弹伤害
            -10% 武器射弹尺寸和总射弹速度
            +20% 武器扩散
         */
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[0]), Target.Stats.BulletCount);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Target.Stats.BlastRadius);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Target.Stats.Damage);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[2]), Target.Stats.BulletSize);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[2]), Target.Stats.BulletSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Target.Stats.ShootSpread);
    }
}