using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
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
        
        Init();
        
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
                BulletBase bullet = new BulletBuilder().
                    SetIsPlayer(IsPlayer).
                    SetDamage(Actor.Stats.Damage.Value).
                    SetSpeed(Actor.Stats.BulletSpeed.Value).
                    SetSize(Actor.Stats.BulletSize.Value).
                    SetDegeneration(Actor.Stats.BulletDegeneration.Value).
                    Build();
                
                bullet.GlobalPosition = GlobalPosition;
                
                float arcRad = Mathf.DegToRad(Actor.Stats.ShootSpread.Value);
                float increment = arcRad / (Actor.Stats.BulletCount.Value - 1 + 3);
                bullet.Direction = bullet.Direction.Rotated(Actor.GlobalRotation + increment * i - arcRad / 2);
    
                Global.GameWorld.AddChild(bullet);
                
                _shootTimer.Start();
        
                OnShoot?.Invoke(bullet);
                bullet.OnHit += actor =>
                {
                    OnHit?.Invoke(actor);
                    var fireBall = 
                        new BulletBuilder(BulletBuilder.BulletType.FireBall).
                            SetDamage(Actor.Stats.BlastDamage.Value).
                            SetBlastRadius(Actor.Stats.BlastRadius.Value).
                            Build();
                    fireBall.GlobalPosition = bullet.GlobalPosition;
                    // Global.GameWorld.AddChild(fireBall);
                    Global.GameWorld.CallDeferred(Node.MethodName.AddChild, fireBall);
                };
                _burstIntervalTimer.Start();
            }
        }
    
        _burstCooldownTimer.WaitTime = Actor.Stats.ShootSpeed.Value * Actor.Stats.BurstFire.Value;
        _burstCooldownTimer.Start();
    }
}