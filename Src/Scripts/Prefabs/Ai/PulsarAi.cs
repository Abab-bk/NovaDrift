using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class PulsarAi : MobAiComponent
{
    // public override void _Ready()
    // {
    //     // Mob.Shooter.GetBulletFunc = (BaseShooter shooter) => 
    //     //     new BulletBuilder().
    //     //         SetIsPlayer(Mob.IsPlayer).
    //     //         SetDamage(Mob.Stats.Damage.Value).
    //     //         SetSpeed(Mob.Stats.BulletSpeed.Value).
    //     //         SetSize(Mob.Stats.BulletSize.Value).
    //     //         SetDegeneration(Mob.Stats.BulletDegeneration.Value).
    //     //         SetSteering(Mob.Stats.Targeting.Value).
    //     //         Build();
    //     
    //     base._Ready();
    // }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Moving":
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
            case "Targeting":
                Mob.TryStop(delta);
                Mob.LookAtPlayer(delta);
                break;
        }
    }
}
