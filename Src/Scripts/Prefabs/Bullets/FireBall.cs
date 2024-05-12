using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs.Bullets;

public partial class FireBall : BulletBase, IBlaster
{
    [Export] private Area2D _area2D;
    
    private BlastVfx _blastVfxVfx;
    protected override void Degenerate() { }
    protected override void Move(double delta) { }

    private float _blastRadius;
    
    public void SetBlastRadius(float value)
    {
        _blastRadius = value;
        if (_blastVfxVfx != null)
        {
            _blastVfxVfx.SetBlastRadius(_blastRadius);
        }
    }

    public override void _Ready()
    {
        base._Ready();
       
        _blastVfxVfx = GetNode<BlastVfx>("Blast");
        _blastVfxVfx.OnBlastDone += QueueFree;
        
        _blastVfxVfx.SetBlastRadius(_blastRadius);
        
        foreach (var body in _area2D.GetOverlappingBodies())
        {
            if (body is Actor blastActor)
            {
                if (blastActor is Player player && IsPlayer)
                {
                    player.TakeDamage(Damage);
                }
                else if (blastActor is MobBase mob && !IsPlayer)
                {
                    mob.TakeDamage(Damage);
                }
            }
        }
    }
}
