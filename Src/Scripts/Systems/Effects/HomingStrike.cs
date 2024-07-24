using Godot;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Systems.Effects;

public class HomingStrike : Effect
{
    private int _count;
    
    private BulletBase GetBullet()
    {
        var bullet = Target.Shooter.GetBulletFunc.Invoke(Target.Shooter);
        bullet.Steering = Target.Stats.Targeting.Value + 50f;
        bullet.Damage = Target.Stats.Damage.Value * Values[2];
        bullet.Speed = Target.Stats.BulletSpeed.Value * Values[3];
        bullet.Size = Target.Stats.BulletSize.Value * 0.8f;
        bullet.Degeneration = Target.Stats.BulletDegeneration.Value + 2f;
        return bullet;
    }
    
    public override void OnCreate()
    {
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[4]), Target.Stats.ShootSpread);
        
        Target.OnShoot += _ =>
        {
            if (_count >= (int)Values[0])
            {
                for (int i = 0; i < Values[1]; i++)
                {
                    Shoot();
                }
                _count = 0;
                return;
            }
            
            _count += 1;
        };
    }

    private void Shoot()
    {
        for (int i = 0; i < 2; i++)
        {
            BulletBase bullet = GetBullet();
            
            if (i == 0)
            {
                bullet.Direction = bullet.Direction.Rotated(Mathf.DegToRad(
                    Target.GlobalRotationDegrees + 90f
                ));
            }
            else
            {
                bullet.Direction = bullet.Direction.Rotated(Mathf.DegToRad(
                    Target.GlobalRotationDegrees - 90f
                ));
            }

            bullet.Active(Target.GlobalPosition);
            bullet.OnHit += actor => { Target.Shooter.OnHit?.Invoke(actor); };
        }
    }
}