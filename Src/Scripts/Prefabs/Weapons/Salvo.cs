using Godot;
using System;
using DsUi;
using NovaDrift.Scripts;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.SalvoBulletCount;

public partial class Salvo : Shooter
{
    private SalvoBulletCountPanel _salvoBulletCountPanel;
    private Timer _replenishTimer;

    private int _bulletCount;
    
    public override void _Ready()
    {
        base._Ready();
        _replenishTimer = GetNode<Timer>("ReplenishTimer");
        _salvoBulletCountPanel = UiManager.Open_SalvoBulletCount();

        Actor.StartShooting += () => { _replenishTimer.Stop(); };
        Actor.StopShooting += () => { _replenishTimer.Start(); };
        _replenishTimer.Timeout += () =>
        {
            _bulletCount += 5;
            _salvoBulletCountPanel.UpdateUi(_bulletCount);
        };
        
        _replenishTimer.Start();
    }

    public override void Destroy()
    {
        base.Destroy();
        UiManager.Destroy_SalvoBulletCount();
    }

    public override async void Shoot()
    {
        if (!ShootTimer.IsStopped()) { return; }
        if (IsBursting) { return; }

        IsBursting = true;
        
        for (int x = 0; x < Actor.Stats.BurstFire.Value; x++)
        {
            for (int i = 0; i < _bulletCount; i++)
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
                // await ToSignal(BurstIntervalTimer, "timeout");
            }
        }

        _bulletCount = 0;

        BurstCooldownTimer.WaitTime = Actor.Stats.ShootSpeed.Value * Actor.Stats.BurstFire.Value;
        BurstCooldownTimer.Start();
    }
}
