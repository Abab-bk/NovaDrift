using System;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class Snipe : Effect
{
    public override void OnCreate()
    {
        StatModifier modifier = new StatModifier(0f, StatModType.PercentAdd);
        
        Target.OnShoot += bullet =>
        {
            bullet.AddModifierToDamage(modifier);

            bullet.OnMove += distance =>
            {
                modifier.Value += Math.Min(distance/1000f, Values[0]);
            };
        };
        
        AddModifierToTarget(
            new StatModifier(Values[1], StatModType.PercentAdd),
            Target.Stats.ShootSpeed);
    }
}