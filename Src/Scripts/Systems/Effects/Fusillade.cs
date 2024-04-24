using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class Fusillade : Effect
{
    public override void OnCreate()
    {
        /*
            减少15%的武器射弹爆炸半径和总射弹伤害。
            减少10%的武器射弹大小和总射弹速度。
            增加15%的武器散布。
        */
        
        base.OnCreate();

        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[0]), Target.Stats.BulletCount);
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[1]), Target.Stats.BulletCount);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[2]), Target.Stats.BlastRadius);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[2]), Target.Stats.Damage);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Target.Stats.BulletSize);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Target.Stats.BulletSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[4]), Target.Stats.ShootSpread);
    }
}