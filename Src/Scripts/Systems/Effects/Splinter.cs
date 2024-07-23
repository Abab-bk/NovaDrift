using Godot;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Systems.Effects;

public class Splinter : Effect
{
    private readonly BulletBuilder _builder = new BulletBuilder();
    
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.ShootSpeed);
        Target.OnShoot += bullet =>
        {
            bullet.OnHit += actor =>
            {
                int miniBulletCount = Mathf.Min(10,
                    (int)(Target.Stats.BulletCount.Value * Target.Stats.BulletSize.Value * 0.8f));
                
                for (int i = 0; i < miniBulletCount; i++)
                {
                    BulletBase miniBullet = _builder.
                        SetIsPlayer(Target.IsPlayer).
                        SetDamage(Target.Stats.Damage.Value).
                        SetSpeed(Target.Stats.BulletSpeed.Value).
                        SetSize(0.3f).
                        SetDegeneration(Target.Stats.BulletDegeneration.Value).
                        Build();
                
                    if (miniBulletCount == 1)
                    {
                        miniBullet.Direction = miniBullet.Direction;
                    }
                    else
                    {
                        float arcRad = Mathf.DegToRad(360f);
                        float increment = arcRad / (miniBulletCount - 1);
                        miniBullet.Direction = miniBullet.Direction.Rotated(miniBullet.GlobalRotation + increment * i - arcRad / 2);
                    }

                    miniBullet.Active(bullet.GlobalPosition);
                }
            };
        };
    }
}