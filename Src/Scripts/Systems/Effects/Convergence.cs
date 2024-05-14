namespace NovaDrift.Scripts.Systems.Effects;

public class Convergence : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        /*
         *  武器瞄准 +5%
            +2 武器射弹
            -15% 武器射弹速度、射速和总射弹尺寸
            +75% 武器扩散
         */
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Targeting);
        AddModifierToTarget(DataBuilder.BuildFlatModifier(
            Values[1]), Target.Stats.BulletCount);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.BulletSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.ShootSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[2]), Target.Stats.BulletSize);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[3]), Target.Stats.ShootSpread);
        
    }
}