using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs.Bullets;

public partial class FireBall : BulletBase
{
    [Export] private Area2D _area2D;
    
    private Blast _blast;
    protected override void Degenerate() { }
    protected override void Move(double delta) { }

    public override void _Ready()
    {
        base._Ready();
       
        _blast = GetNode<Blast>("Blast");
        _blast.OnBlastDone += QueueFree;
        
        foreach (var body in _area2D.GetOverlappingBodies())
        {
            if (body is Actor blastActor)
            {
                if (blastActor is Player player && IsPlayer)
                {
                    player.TakeDamage(20);
                }
                else if (blastActor is MobBase mob && !IsPlayer)
                {
                    mob.TakeDamage(20);
                }
            }
        }
    }
}
