using System;
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
    
    protected Timer _burstIntervalTimer;

    public override void _Ready()
    {
        if (Owner is Actor actor)
        {
            IsPlayer = actor.IsPlayer;
        }

        ShootTimer = new Timer();
        AddChild(ShootTimer);
        ShootTimer.OneShot = true;
        ShootTimer.WaitTime = Actor.Stats.ShootSpeed.Value;

        _burstIntervalTimer = new Timer();
        AddChild(_burstIntervalTimer);
        _burstIntervalTimer.OneShot = true;
        _burstIntervalTimer.WaitTime = DataBuilder.Constants.BurstInterval;
        
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

    public virtual async void Shoot(Vector2 targetDir)
    {
        if (!ShootTimer.IsStopped())
        {
            return;
        }

        for (int i = 0; i < Actor.Stats.BurstFire.Value; i++)
        {
            BulletBase bullet = new BulletBuilder().
                SetTargetDir(targetDir).
                SetIsPlayer(IsPlayer).
                SetDamage(Actor.Stats.Damage.Value).
                SetSpeed(Actor.Stats.BulletSpeed.Value).
                SetSize(Actor.Stats.BulletSize.Value).
                SetDegeneration(Actor.Stats.BulletDegeneration.Value).
                Build();
        
            Global.GameWorld.AddChild(bullet);
            bullet.GlobalPosition = GlobalPosition;
            bullet.Rotation = targetDir.Angle();
            ShootTimer.Start();
        
            OnShoot?.Invoke(bullet);
            bullet.OnHit += actor => { OnHit?.Invoke(actor); };
            _burstIntervalTimer.Start();
            await ToSignal(_burstIntervalTimer, Timer.SignalName.Timeout);
        }
    }
}