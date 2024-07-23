using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class SplitShot : BaseShooter
{
    private Timer _shootTimer;
    
    private Timer _burstIntervalTimer;
    private Timer _burstCooldownTimer;
    private bool _isBursting = false;

    public override void _Ready()
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
        
        Actor.Stats.BulletDegeneration.AddModifier(new StatModifier(-0.5f, StatModType.PercentAdd));
        
        base._Ready();

        GetBulletFunc = shooter => new BulletBuilder().
            SetIsPlayer(IsPlayer).
            SetDamage(Actor.Stats.Damage.Value).
            SetSpeed(Actor.Stats.BulletSpeed.Value).
            SetSize(Actor.Stats.BulletSize.Value).
            SetDegeneration(Actor.Stats.BulletDegeneration.Value).
            Build();

        Actor.Stats.ShootSpeed.ValueChanged += SetShootCd;
    }

    public override void Destroy()
    {
        Actor.Stats.ShootSpeed.ValueChanged -= SetShootCd;
    }

    public override void SetShootCd(float value)
    {
        _shootTimer.Stop();
        _shootTimer.WaitTime = value;
    }
    
    public override void Init()
    {
    }

    public override void Shoot()
    {
        if (!_shootTimer.IsStopped()) { return; }
        if (_isBursting) { return; }
    
        _isBursting = true;
        
        for (int x = 0; x < Actor.Stats.BurstFire.Value; x++)
        {
            for (int i = 0; i < Actor.Stats.BulletCount.Value + 3; i++)
            {
                BulletBase bullet = GetBulletFunc?.Invoke(this);
                if (bullet == null)
                {
                    Logger.LogError("[SplitShot] Bullet is null");
                    return;
                }
                
                bullet.Direction = bullet.Direction.Rotated(Mathf.DegToRad(360f / (Actor.Stats.BulletCount.Value + 3) * i + 1));
    
                bullet.Active(GlobalPosition);
                
                _shootTimer.Start();
        
                OnShoot?.Invoke(bullet);
                
                _burstIntervalTimer.Start();
            }
        }
    
        _burstCooldownTimer.WaitTime = Actor.Stats.ShootSpeed.Value * Actor.Stats.BurstFire.Value;
        _burstCooldownTimer.Start();
    }
}