using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class Shooter : Node2D
{
    [Export] private Actor _actor;
    
    public bool IsPlayer = false;
    private Timer _shootTimer;
    private float _shootCd = 0.1f;

    public override void _Ready()
    {
        if (Owner is Actor actor)
        {
            IsPlayer = actor.IsPlayer;
        }

        _shootTimer = new Timer();
        AddChild(_shootTimer);
        _shootTimer.OneShot = true;
        _shootTimer.WaitTime = _shootCd;
    }

    public virtual void Shoot(Vector2 targetDir)
    {
        if (!_shootTimer.IsStopped())
        {
            return;
        }

        BulletBase bullet = new BulletBuilder().
                                SetTargetDir(targetDir).
                                SetIsPlayer(IsPlayer).
                                SetDamage(_actor.Stats.Damage.Value).
                                Build();
        
        Global.GameWorld.AddChild(bullet);
        bullet.GlobalPosition = GlobalPosition;
        _shootTimer.Start();
    }
}