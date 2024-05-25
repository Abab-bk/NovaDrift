using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Pulse : BaseShooter
{
    // TODO: 需要应用上各种Modifier，包括其他武器
    private Timer _shootTimer;
    
    public override void SetShootCd(float value)
    {
        _shootTimer.WaitTime = value;
    }

    public override void Init()
    {
        _shootTimer = new Timer
        {
            WaitTime = Actor.Stats.ShootSpeed.Value,
            OneShot = true
        };
        AddChild(_shootTimer);
    }

    public override void Shoot()
    {
        if (!_shootTimer.IsStopped()) return;
        _shootTimer.Start();
        
        var circleBlast = GD.Load<PackedScene>("res://Scenes/Vfx/CircleBlast.tscn").Instantiate<CircleBlast>();
        circleBlast.IsPlayer = IsPlayer;
        circleBlast.OnSomeThingHit += node2D =>
        {
            if (node2D is not Actor actor) return;
            if (Actor.IsPlayer && actor is MobBase)
            {
                actor.TakeDamageWithoutKnockBack(Actor.Stats.Damage.Value);
            }
            else if (!Actor.IsPlayer && actor is Player)
            {
                actor.TakeDamageWithoutKnockBack(Actor.Stats.Damage.Value);
            }
        };
        
        AddChild(circleBlast);
    }

    public override void Destroy()
    {
    }
}
