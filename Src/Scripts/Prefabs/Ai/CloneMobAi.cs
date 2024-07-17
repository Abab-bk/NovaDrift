using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class CloneMobAi : MobAiComponent
{
    // protected override void ConnectProcessSignals(State state, float delta)
    // {
    //     base.ConnectProcessSignals(state, delta);
    //     switch (state.GetName())
    //     {
    //         case "Moving":
    //             Mob.SetTargetAndMove(Global.Player, delta);
    //             break;
    //     }
    // }

    public override void _PhysicsProcess(double delta)
    {
        Mob.SetTargetAndMove(Global.Player, (float)delta);
    }
}
