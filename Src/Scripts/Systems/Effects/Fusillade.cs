using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class Fusillade : Effect
{
    public override void OnCreate()
    {
        /* TODO
         *  减少15%的武器射弹爆炸半径和总射弹伤害。
            减少10%的武器射弹大小和总射弹速度。
            增加15%的武器散布。
         */
        base.OnCreate();
        AddModifierToTarget(new StatModifier(
            Values[0], StatModType.Flat), Target.Stats.BurstFire);
        AddModifierToTarget(new StatModifier(
            2f, StatModType.PercentMult, 999), Target.Stats.BurstFire);
    }
}