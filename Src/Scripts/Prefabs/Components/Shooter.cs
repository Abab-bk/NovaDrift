using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Shooter : Node2D
{
    [Export] public Actor Actor;
    
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
        ShootTimer.WaitTime = Weapon.ShootSpeed.Value;
        Init();   
    }

    public void SetShootCd(float value)
    {
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
                                SetSpeed(Weapon.BulletSpeed.Value).
                                Build();
        
        Global.GameWorld.AddChild(bullet);
        bullet.GlobalPosition = GlobalPosition;
        bullet.Rotation = targetDir.Angle();
        ShootTimer.Start();
    }
}