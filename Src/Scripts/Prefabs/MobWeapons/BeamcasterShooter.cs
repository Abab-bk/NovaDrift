using Godot;
using NovaDrift.Scripts.Prefabs.Bullets;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.MobWeapons;

public partial class BeamcasterShooter : BaseShooter
{
    private Timer _timer;

    private Vector2 _bulletPos1 = new (33, -38);
    private Vector2 _bulletPos2 = new (-43, 70);
    
    public override void Destroy()
    {
    }

    public override void Shoot()
    {
        if (!DefaultCooldownTimer.IsStopped()) { return; }
        
        DefaultCooldownTimer.Start();
        
        for (int i = 0; i < Actor.Stats.BulletCount.Value; i++)
        {
            var bulletPos = Vector2.Zero;
            var posOffset = 0f;

            switch (i)
            {
                case 0:
                    bulletPos = _bulletPos1;
                    posOffset = -1000f;
                    break;
                case 1:
                    bulletPos = _bulletPos2;
                    posOffset = -1000f;
                    break;
                case 2:
                    bulletPos = new Vector2(_bulletPos1.X, -_bulletPos1.Y);
                    posOffset = 1000f;
                    break;
                case 3:
                    bulletPos = new Vector2(_bulletPos2.X, -_bulletPos2.Y);
                    posOffset = 1000f;
                    break;
            }

            bulletPos.Rotated(Actor.Rotation);
            
            var bullet = GetBulletFunc.Invoke(this);
            if (bullet is BeamcasterBullet beamcasterBullet) beamcasterBullet.PosOffset = posOffset;
            
            bullet.GlobalPosition = ToGlobal(bulletPos);
            
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