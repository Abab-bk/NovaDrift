using Godot;
using NovaDrift.Scripts.Prefabs.Bullets;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.MobWeapons;

public partial class BeamcasterShooter : BaseShooter
{
    private Timer _timer;
    
    public override void Destroy()
    {
    }

    public override void Shoot()
    {
        if (!DefaultCooldownTimer.IsStopped()) { return; }
        
        DefaultCooldownTimer.Start();
        
        for (int i = 0; i < Actor.Stats.BulletCount.Value; i++)
        {
            var bullet = GetBulletFunc.Invoke(this);
            if (bullet is BeamcasterBullet beamcasterBullet) beamcasterBullet.PosOffset = 600f;
            bullet.GlobalPosition = GlobalPosition;
            Global.GameWorld.AddChild(bullet);
            OnShoot?.Invoke(bullet);
            bullet.OnHit += actor => { OnHit?.Invoke(actor); };
        }
    }

    public override void Init()
    {
        SetDefaultCooldownTimer(1f);
        GetBulletFunc = _ => new BulletBuilder().
            SetBulletBase("res://Scenes/Prefabs/Bullets/BeamcasterBullet.tscn").
            SetOwner(Actor).
            SetIsPlayer(IsPlayer).
            SetDamage(Actor.Stats.Damage.Value).
            SetSpeed(Actor.Stats.BulletSpeed.Value).
            SetSize(Actor.Stats.BulletSize.Value).
            SetDegeneration(Actor.Stats.BulletDegeneration.Value).
            SetSteering(Actor.Stats.Targeting.Value).
            Build();;
    }
}