using System;
using AcidWallStudio.AcidUtilities;

namespace NovaDrift.Scripts.Systems.Effects;

public class AlmostHit : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        Target.OnShoot += bullet =>
        {
            if (Wizard.GetChance() >= Values[0])
            {
                bullet.CanPenetrate += (int)Values[0];
            }
        };
    }
}