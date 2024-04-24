using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Bodies;

public class Courser : Body
{
    public override void Use()
    {
        base.Use();
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[0]), Actor.Stats.BulletCount);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Actor.Stats.ShootSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[2]), Actor.Stats.ShootSpread);
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Actor.Stats.Damage);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Actor.Stats.BulletSize);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Actor.Stats.BlastRadius);
    }
}