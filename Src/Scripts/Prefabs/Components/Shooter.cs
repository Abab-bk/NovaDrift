using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Shooter : Node2D
{
    [Export] public Actor Actor;
    
    public bool IsPlayer = false;
    protected Timer ShootTimer;
    private float _shootCd = 0.1f;

    public override void _Ready()
    {
        if (Owner is Actor actor)
        {
            IsPlayer = actor.IsPlayer;
        }

        ShootTimer = new Timer();
        AddChild(ShootTimer);
        ShootTimer.OneShot = true;
        ShootTimer.WaitTime = _shootCd;
        Init();   
    }

    public void SetShootCd(float value)
    {
        _shootCd = value;
        ShootTimer.WaitTime = _shootCd;
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
                                Build();
        
        Global.GameWorld.AddChild(bullet);
        bullet.GlobalPosition = GlobalPosition;
        bullet.Rotation = targetDir.Angle();
        ShootTimer.Start();
    }
}