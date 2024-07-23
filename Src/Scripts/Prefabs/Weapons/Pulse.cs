using AcidWallStudio.Fmod;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Pulse : BaseShooter
{
    // TODO: 需要应用上各种Modifier，包括其他武器
    private Timer _shootTimer;

    private PackedScene _scene = GD.Load<PackedScene>("res://Scenes/Vfx/CircleBlast.tscn");
    
    public override void SetShootCd(float value)
    {
        _shootTimer.WaitTime = ClampShootCd(value) * 4f;
    }

    public override void Init()
    {
        _shootTimer = new Timer
        {
            WaitTime = Actor.Stats.ShootSpeed.Value * 4f,
            OneShot = true
        };
        AddChild(_shootTimer);
        GetBulletFunc = _ =>
            new BulletBuilder().
            SetOwner(Actor).
            SetIsPlayer(IsPlayer).
            SetDamage(Actor.Stats.Damage.Value * 0.5f).
            SetSpeed(Actor.Stats.BulletSpeed.Value).
            SetSize(Actor.Stats.BulletSize.Value).
            SetDegeneration(Actor.Stats.BulletDegeneration.Value).
            SetSteering(Actor.Stats.Targeting.Value).
            Build();
    }

    private float GetRadius()
    {
        return 1f + Actor.Stats.BulletSize.Value * 0.5f * (Actor.Stats.BlastRadius.Value * 0.5f);
    }

    public override void Shoot()
    {
        if (!_shootTimer.IsStopped()) return;
        _shootTimer.Start();
        
        var circleBlast = _scene.Instantiate<CircleBlast>();
        circleBlast.IsPlayer = IsPlayer;
        circleBlast.Radius = GetRadius();
        
        circleBlast.OnSomeThingHit += node2D =>
        {
            if (node2D is not Actor actor) return;
            SoundManager.PlayOneShotById("event:/OnBulletHit");
            if (Actor.IsPlayer && actor is MobBase)
            {
                actor.TakeDamageWithoutKnockBack(Actor.Stats.Damage.Value);
            }
            else if (!Actor.IsPlayer && actor is Player)
            {
                actor.TakeDamageWithoutKnockBack(Actor.Stats.Damage.Value);
            }
        };
        
        AddChild(circleBlast);
        
        for (int i = 0; i < Actor.Stats.BulletCount.Value; i++)
        {
            BulletBase bullet = GetBulletFunc?.Invoke(this);
                
            if (bullet == null) continue;
            
            if ((int)Actor.Stats.BulletCount.Value == 1)
            {
                bullet.Direction = bullet.Direction.Rotated(GlobalRotation);
            }
            else
            {
                float arcRad = Mathf.DegToRad(Actor.Stats.ShootSpread.Value);
                float increment = arcRad / (Actor.Stats.BulletCount.Value - 1);
                bullet.Direction = bullet.Direction.Rotated(Actor.GlobalRotation + increment * i - arcRad / 2);
            }

            bullet.Active(GlobalPosition);
                
            OnShoot?.Invoke(bullet);
            bullet.OnHit += body => { OnHit?.Invoke(body); };
        }
    }

    public override void Destroy()
    {
    }
}
