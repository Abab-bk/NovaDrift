using AcidWallStudio.AcidUtilities;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Bodies;

public class Assault : Body
{
    public override void Use()
    {
        base.Use();
        
        Actor.Shooter.OnShoot += bullet =>
        {
            if (!Wizard.ChanceOverThreshold((int)(Values[0] * 100f)))
            {
                return;
            }
            bullet.Damage += Actor.Stats.Damage.Value;
        };
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Actor.Stats.ShootSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Actor.Stats.ShootSpread);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[1]), Actor.Stats.BulletSpeed);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[2]), Actor.Stats.ShootingDeceleration);
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[3]), Actor.Stats.MaxShield);
    }
}