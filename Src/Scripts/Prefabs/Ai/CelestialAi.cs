using Godot;
using System;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class CelestialAi : MobAiComponent
{
    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "GoingToPlayer":
                Mob.SetTargetAndMove(Global.Player, delta);
                if (Mob.GetDistanceToPlayer() <= 300)
                {
                    Machine.SetTrigger("Next");
                }
                break;
            case "CirclingPlayer":
                Mob.Velocity = (Mob.GlobalPosition - Global.Player.GlobalPosition).Normalized().Rotated(MathF.PI / 2) *
                               Mob.Stats.Speed.Value;
                Mob.MoveAndSlide();
                Mob.LookAt(Global.Player.GlobalPosition);
                break;
            case "Shoot":
                Mob.LookAt(Global.Player.GlobalPosition);
                Mob.Shoot();
                break;
        }
    }
}
