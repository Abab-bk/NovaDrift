using System;
using AcidWallStudio.AcidUtilities;

namespace NovaDrift.Scripts.Systems.Effects;

public class Ampli : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();

        Target.OnShoot += bullet =>
        {
            // if (Target.Velocity.Length() >= 最大速度的 80%)
            if (Wizard.GetChance() <= Values[0])
            {
                bullet.CanPenetrate += (int)Values[0];
            }
        };
    }
}