using Godot;
using System;
using AcidWallStudio.AcidUtilities;
using DsUi;
using NovaDrift.Scripts;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.SalvoBulletCount;

public partial class Salvo : BaseShooter
{
    private SalvoBulletCountPanel _salvoBulletCountPanel;
    private Timer _replenishTimer;

    private int _bulletCount;

    private Action _startShooting;
    private Action _stopShooting;
    
    public override void _Ready()
    {
        _replenishTimer = GetNode<Timer>("ReplenishTimer");
        _salvoBulletCountPanel = UiManager.Open_SalvoBulletCount();

        Actor.StartShooting += _startShooting = () => { _replenishTimer.Stop(); };
        Actor.StopShooting += _stopShooting = () => { _replenishTimer.Start(); };
        _replenishTimer.Timeout += () =>
        {
            _bulletCount += (4 + (int)Actor.Stats.BulletCount.Value - 1) - Mathf.Max(0, _bulletCount - (int)(_bulletCount * 0.5f));
            _salvoBulletCountPanel.UpdateUi(_bulletCount);
        };
        Actor.Stats.ShootSpeed.ValueChanged += f =>
        {
            _replenishTimer.WaitTime -= f / 5;
        };

        _replenishTimer.Start();
        _salvoBulletCountPanel.UpdateUi(_bulletCount);
    }

    public override void Destroy()
    {
        UiManager.Destroy_SalvoBulletCount();
        Actor.StartShooting -= _startShooting;
        Actor.StopShooting -= _stopShooting;
    }

    public override void Shoot()
    {
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

                bullet.Direction = bullet.Direction.Rotated(GlobalRotation);
                bullet.GlobalPosition = GlobalPosition;
                Global.GameWorld.AddChild(bullet);
        
                OnShoot?.Invoke(bullet);
                bullet.OnHit += actor => { OnHit?.Invoke(actor); };
                bullet.OnMove += f =>
                {
                    bullet.Direction = bullet.Direction.Rotated(Random.Shared.FloatRange(-0.2f, 0.2f));
                };
            }
        }

        _bulletCount = 0;
        _salvoBulletCountPanel.UpdateUi(_bulletCount);
    }

    public override void Init()
    {
    }

    public override void SetShootCd(float value)
    {
    }
}
