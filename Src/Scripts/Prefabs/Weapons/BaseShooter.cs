using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public abstract partial class BaseShooter : Node2D
{
    [Export] public Actor Actor { get; set; }
    
    public Action<BulletBase> OnShoot { get; set; }
    public Action<Actor> OnHit { get; set; }
    
    public Weapon Weapon { get; set; } = new Weapon();

    public bool IsPlayer { get; set; }
    
    public abstract void Shoot();

    public abstract void Destroy();

    public abstract void SetShootCd(float value);

    public abstract void Init();

    public BulletBase GetBullet()
    {
        return new BulletBuilder().
            SetIsPlayer(IsPlayer).
            SetDamage(Actor.Stats.Damage.Value).
            SetSpeed(Actor.Stats.BulletSpeed.Value).
            SetSize(Actor.Stats.BulletSize.Value).
            SetDegeneration(Actor.Stats.BulletDegeneration.Value).
            SetSteering(Actor.Stats.Targeting.Value).
            Build();
    }
}