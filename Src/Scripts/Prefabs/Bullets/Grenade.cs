using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Bullets;

public partial class Grenade : BulletBase
{
    protected override void Degenerate() { }

    protected override void OnHitHandle(Actor actor)
    {
        TakeOnHitEvent(actor);
        Blast();
    }

    protected override void OnHitOthersHandle()
    {
        Blast();
    }

    private void Blast()
    {
        var fireBall = 
            new BulletBuilder(BulletBuilder.BulletType.FireBall).
                SetDamage(Damage).
                SetOwner(Target).
                SetBlastRadius(Target.Stats.BlastRadius.Value).
                Build();
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, fireBall);
        fireBall.GlobalPosition = GlobalPosition;
        QueueFree();
    }
}
