using Godot;

namespace NovaDrift.Scripts.Systems.Effects;

public class Rupture : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        EventBus.OnMobDied += mob =>
        {
            var fireBall = 
                new BulletBuilder(BulletBuilder.BulletType.FireBall).
                    SetDamage(mob.Stats.Health.MaxValue.Value * Values[0]).
                    SetBlastRadius(Target.Stats.BlastRadius.Value).
                    Build();
            fireBall.GlobalPosition = mob.GlobalPosition;
            Global.GameWorld.CallDeferred(Node.MethodName.AddChild, fireBall);
            GD.Print(Target.Stats.BlastRadius.Value);
        };
    }
}