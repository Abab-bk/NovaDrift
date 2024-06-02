using Godot;
using AcidWallStudio.AcidUtilities;
using GTweens.Builders;
using GTweensGodot.Extensions;

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
            case "KeepDistance":
                Mob.Rotation = Mob.RotationTo(Mob.Velocity.Angle(), delta);
                // Should keep distance on 200 - 300
                var distance = Mob.GetDistanceToPlayer();
                if (distance > 300f)
                {
                    Mob.SetTargetAndMove(Global.Player, delta);
                }
                else
                {
                    Mob.TryStop(delta);
                }
                break;
            case "Shoot":
                Mob.Rotation = Mob.RotationTo(Mob.Velocity.Angle(), delta);
                Mob.TryStop(delta);
                Mob.Shoot();
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Dodge":
                var originalColor = Mob.Modulate;
                GTweenSequenceBuilder.New()
                    .Join(Mob.TweenModulate(new Color("ffffff00"), 0.1f))
                    .Join(Mob.TweenGlobalPosition(
                        Mob.GetForwardVector2(Mob.Stats.Speed.Value * 0.5f), 0.1f))
                    .Append(Mob.TweenModulate(originalColor, 0.1f))
                    .AppendCallback(() =>
                    {
                        Machine.SetTrigger("Next");
                    })
                    .Build()
                    .Play();
                break;
        }
    }
}
