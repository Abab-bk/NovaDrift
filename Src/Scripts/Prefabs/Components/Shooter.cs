using System;
using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Shooter : Node2D, IObject
{
    [Export] public Actor Actor;
    
    public event Action<BulletBase> OnShoot;
    public event Action<Actor> OnHit;
    
    public Weapon Weapon = new Weapon();
    
    public bool IsPlayer = false;
    protected Timer ShootTimer;
    
    protected Timer BurstIntervalTimer;
    protected Timer BurstCooldownTimer;
    protected bool IsBursting = false;

    public override void _Ready()
    {
        if (Owner is Actor actor)
        {
            IsPlayer = actor.IsPlayer;
        }

        BurstCooldownTimer = Wizard.CreateTimer(0.5f);
        AddChild(BurstCooldownTimer);
        BurstCooldownTimer.Timeout += () => IsBursting = false; 
        
        ShootTimer = new Timer();
        AddChild(ShootTimer);
        ShootTimer.OneShot = true;
        ShootTimer.WaitTime = Actor.Stats.ShootSpeed.Value;

        BurstIntervalTimer = new Timer();
        AddChild(BurstIntervalTimer);
        BurstIntervalTimer.OneShot = true;
        BurstIntervalTimer.WaitTime = DataBuilder.Constants.BurstInterval;
        
        Init();
        
        Actor.Stats.ShootSpeed.ValueChanged += SetShootCd;
    }

    public void Destroy()
    {
        Actor.Stats.ShootSpeed.ValueChanged -= SetShootCd;
    }

    public void SetShootCd(float value)
    {
        ShootTimer.Stop();
        ShootTimer.WaitTime = value;
    }
    
    protected virtual void Init()
    {
    }

    public virtual async void Shoot()
    {
        if (!ShootTimer.IsStopped()) { return; }
        if (IsBursting) { return; }

        IsBursting = true;
        
        for (int x = 0; x < Actor.Stats.BurstFire.Value; x++)
        {
            for (int i = 0; i < Actor.Stats.BulletCount.Value; i++)
            {
                BulletBase bullet = new BulletBuilder().
                    SetIsPlayer(IsPlayer).
                    SetDamage(Actor.Stats.Damage.Value).
                    SetSpeed(Actor.Stats.BulletSpeed.Value).
                    SetSize(Actor.Stats.BulletSize.Value).
                    SetDegeneration(Actor.Stats.BulletDegeneration.Value).
                    Build();
                
                bullet.GlobalPosition = GlobalPosition;
                if ((int)Actor.Stats.BulletCount.Value == 1)
                {
                    bullet.Rotation = GlobalRotation;
                }
                else
                {
                    float arcRad = Mathf.DegToRad(Actor.Stats.ShootSpread.Value);
                    float increment = arcRad / (Actor.Stats.BulletCount.Value - 1);
                    bullet.GlobalRotation = Actor.GlobalRotation + increment * i - arcRad / 2;
                }

                Global.GameWorld.AddChild(bullet);
                
                ShootTimer.Start();
        
                OnShoot?.Invoke(bullet);
                bullet.OnHit += actor => { OnHit?.Invoke(actor); };
                BurstIntervalTimer.Start();
                await ToSignal(BurstIntervalTimer, "timeout");
            }
        }

        BurstCooldownTimer.WaitTime = Actor.Stats.ShootSpeed.Value * Actor.Stats.BurstFire.Value;
        BurstCooldownTimer.Start();
    }
}