using Godot;
using System;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Swallow : MobAiComponent
{
    public override void _Ready()
    {
        base._Ready();
        Mob.OnHitSomeThing += (body) =>
        {
            if (body is not Player player) return;
            player.TakeDamage(Mob.Stats.Damage.Value);
            Mob.Die();
        };
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Rush":
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
        }
    }
}
