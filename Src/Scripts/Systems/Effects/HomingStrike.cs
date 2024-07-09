using Godot;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Systems.Effects;

public class HomingStrike : Effect
{
    private int _count;
    
    private BulletBase GetBullet()
    {
        return new BulletBuilder().
            SetOwner(Target).
            SetIsPlayer(Target.IsPlayer).
            SetDamage(Target.Stats.Damage.Value * Values[2]).
            SetSpeed(Target.Stats.BulletSpeed.Value * Values[3]).
            SetSize(Target.Stats.BulletSize.Value).
            SetDegeneration(Target.Stats.BulletDegeneration.Value + 2f).
            SetSteering(Target.Stats.Targeting.Value + 1f).
            Build();
    }
    
    public override void OnCreate()
    {
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(Values[4]), Target.Stats.ShootSpread);
        
        Target.OnShoot += _ =>
        {
            if (_count >= (int)Values[0])
            {
                for (int i = 0; i < 1 + Values[1]; i++)
                {
                    Shoot();
                }
                _count = 0;
                return;
            }
            
            _count += 1;
            Shoot();
        };
    }

    private void Shoot()
    {
        for (int i = 0; i < 2; i++)
        {
            BulletBase bullet = GetBullet();
                
            bullet.GlobalPosition = Target.GlobalPosition;

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

            Global.GameWorld.AddChild(bullet);
            bullet.OnHit += actor => { Target.Shooter.OnHit?.Invoke(actor); };
        }
    }
}