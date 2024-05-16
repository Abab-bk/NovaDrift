using Godot;
using System;
using AcidWallStudio.AcidUtilities;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class GyrogunAi : MobAiComponent
{
    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "RunningToCenter":
                Mob.TryMoveTo(Mob.GlobalPosition.DirectionTo(Wizard.GetScreenCenter()), delta);
                Mob.Rotate(Mathf.DegToRad(50 * delta));
                
                if (Mob.GlobalPosition.DistanceTo(Wizard.GetScreenCenter()) <= 10)
                {
                    Machine.SetTrigger("Next");
                }
                Mob.Shoot();
                break;
            case "RunningToPlayer":
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
        }
    }
}
