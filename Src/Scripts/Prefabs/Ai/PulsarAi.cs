using Godot;
using System;
using AcidWallStudio.AcidUtilities;
using cfg;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Weapons;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class PulsarAi : MobAiComponent
{
    public override void _Ready()
    {
        // Mob.Shooter.GetBulletFunc = (BaseShooter shooter) => 
        //     new BulletBuilder().
        //         SetIsPlayer(Mob.IsPlayer).
        //         SetDamage(Mob.Stats.Damage.Value).
        //         SetSpeed(Mob.Stats.BulletSpeed.Value).
        //         SetSize(Mob.Stats.BulletSize.Value).
        //         SetDegeneration(Mob.Stats.BulletDegeneration.Value).
        //         SetSteering(Mob.Stats.Targeting.Value).
        //         Build();
        
        base._Ready();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "KeepDistance":
                if (Mob.GetDistanceToPlayer() > 300)
                {
                    Mob.SetTargetAndMove(Global.Player, delta);
                }
                break;
            case "Shoot":
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
                Color originalColor = Mob.Modulate;
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
