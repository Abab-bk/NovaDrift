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
    
    public Weapon Weapon = new Weapon();
    
    public bool IsPlayer = false;
    protected Timer ShootTimer;

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

    public virtual void Shoot(Vector2 targetDir)
    {
        if (!ShootTimer.IsStopped())
        {
            return;
        }

        BulletBase bullet = new BulletBuilder().
                                SetTargetDir(targetDir).
                                SetIsPlayer(IsPlayer).
                                SetDamage(Actor.Stats.Damage.Value).
                                SetSpeed(Actor.Stats.BulletSpeed.Value).
                                Build();
        
        Global.GameWorld.AddChild(bullet);
        bullet.GlobalPosition = GlobalPosition;
        bullet.Rotation = targetDir.Angle();
        ShootTimer.Start();
        OnShoot?.Invoke(bullet);
    }
}