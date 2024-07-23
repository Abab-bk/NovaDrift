using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Systems.BulletPatterns;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Shooter : BaseShooter
{
    private Timer _shootTimer;
    
    private Timer _burstIntervalTimer;
    private Timer _burstCooldownTimer;
    private bool _isBursting;
    
    private ShotGunPattern _defaultPattern = new ShotGunPattern();
    
    public override void _EnterTree()
    {
        if (Owner is Actor actor)
        {
            Actor = actor;
        }
    }

    public override void _Ready()
    {
        GetBulletFunc = (shooter) => shooter.GetBullet();
        Init();
    }

    public override void Destroy()
    {
        base.Destroy();
        Actor.Stats.ShootSpeed.ValueChanged -= SetShootCd;
    }

    public override void SetShootCd(float value)
    {
        _shootTimer.Stop();
        _shootTimer.WaitTime = value;
    }
    
    public override void Init()
    {
        if (Owner is Actor actor)
        {
            IsPlayer = actor.IsPlayer;
        }

        _burstCooldownTimer = Wizard.CreateTimer(0.5f);
        AddChild(_burstCooldownTimer);
        _burstCooldownTimer.Timeout += () => _isBursting = false; 
        
        _shootTimer = new Timer();
        AddChild(_shootTimer);
        _shootTimer.OneShot = true;
        _shootTimer.WaitTime = Actor.Stats.ShootSpeed.Value;

        _burstIntervalTimer = new Timer();
        AddChild(_burstIntervalTimer);
        _burstIntervalTimer.OneShot = true;
        _burstIntervalTimer.WaitTime = DataBuilder.Constants.BurstInterval;
        
        Actor.Stats.ShootSpeed.ValueChanged += SetShootCd;
        
        SetShootCd(Actor.Stats.ShootSpeed.Value);
    }

    public override void Shoot()
    {
        ShootWithConfig(_defaultPattern, (int)Actor.Stats.BulletCount.Value);
    }

    public override void ShootWithConfig(BulletPattern bulletPattern, int bulletCount)
    {
        if (!_shootTimer.IsStopped()) { return; }
        if (_isBursting) { return; }

        _isBursting = true;
        
        for (int i = 0; i < bulletCount; i++)
        {
            BulletBase bullet = GetBulletFunc.Invoke(this);
            bulletPattern.SetPattern(bullet, Actor, bulletCount, i);
            bullet.Active(GlobalPosition);
            
            _shootTimer.Start();
            
            OnShoot?.Invoke(bullet);
            bullet.OnHit += actor => { OnHit?.Invoke(actor); };
            _burstIntervalTimer.Start();
        }
        
        _burstCooldownTimer.WaitTime = Actor.Stats.ShootSpeed.Value * Actor.Stats.BurstFire.Value;
        _burstCooldownTimer.Start();
    }
}