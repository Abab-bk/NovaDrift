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
            if (!Wizard.ChanceOverThreshold(8))
            {
                return;
            }
            bullet.Damage += Actor.Stats.Damage.Value;
        };
        
        AddModifierToTarget(
            new StatModifier(0.15f, StatModType.PercentAdd, this),
            Actor.Stats.ShootingDeceleration
            );

        AddModifierToTarget(
            new StatModifier(0.15f, StatModType.PercentAdd, this),
            Actor.Stats.BulletSpeed
            );
        
        AddModifierToTarget(
            new StatModifier(-0.15f, StatModType.PercentAdd, this),
            Actor.Stats.ShootSpread
            );
        
        AddModifierToTarget(
            new StatModifier(0.15f, StatModType.PercentAdd),
            Actor.Stats.ShootSpread
            );
    }
}