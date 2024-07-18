using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.BulletPatterns;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public abstract partial class BaseShooter : Node2D
{
    [Export] public Actor Actor { get; set; }
    
    public Action<BulletBase> OnShoot { get; set; }
    public Action<Actor> OnHit { get; set; }
    public Func<BaseShooter, BulletBase> GetBulletFunc { get; set; }
    
    protected Timer DefaultCooldownTimer { get; set; }
    
    public Weapon Weapon { get; set; } = new Weapon();

    public bool IsPlayer { get; set; }
    
    public abstract void Shoot();

    public virtual void ShootWithConfig(BulletPattern bulletPattern, int bulletCount)
    {
        for (int i = 0; i < Actor.Stats.BulletCount.Value; i++)
        {
            BulletBase bullet = GetBulletFunc.Invoke(this);
            bullet.GlobalPosition = GlobalPosition;
            bulletPattern.SetPattern(bullet, Actor, bulletCount, i);
            
            Global.GameWorld.AddChild(bullet);
            
            OnShoot?.Invoke(bullet);
            bullet.OnHit += actor => { OnHit?.Invoke(actor); };
        }
    }

    public abstract void Destroy();

    public virtual void SetShootCd(float value)
    {
        if (DefaultCooldownTimer != null) DefaultCooldownTimer.WaitTime = value;
    }

    public abstract void Init();

    public override void _Ready()
    {
        Init();
    }

    protected void SetDefaultCooldownTimer(float waitTime)
    {
        DefaultCooldownTimer = new Timer()
        {
            WaitTime = waitTime,
            OneShot = true,
        };
        AddChild(DefaultCooldownTimer);
    }

    public BulletBase GetBullet()
    {
        return new BulletBuilder().
            SetOwner(Actor).
            SetIsPlayer(IsPlayer).
            SetDamage(Actor.Stats.Damage.Value).
            SetSpeed(Actor.Stats.BulletSpeed.Value).
            SetSize(Actor.Stats.BulletSize.Value).
            SetDegeneration(Actor.Stats.BulletDegeneration.Value).
            SetSteering(Actor.Stats.Targeting.Value).
            Build();
    }
}