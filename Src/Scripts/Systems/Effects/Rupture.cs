using Godot;

namespace NovaDrift.Scripts.Systems.Effects;

public class Rupture : Effect
{
    public override void OnCreate()
    {
        var builder = new BulletBuilder(BulletBuilder.BulletType.FireBall);
        base.OnCreate();
        EventBus.OnMobDied += mob =>
        {
            builder.
                SetDamage(mob.Stats.Health.MaxValue.Value * Values[0]).
                SetBlastRadius(Target.Stats.BlastRadius.Value).
                Build().
                Active(mob.GlobalPosition);
        };
    }
}