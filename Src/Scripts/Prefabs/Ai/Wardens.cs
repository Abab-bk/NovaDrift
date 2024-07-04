using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Wardens : MobAiComponent
{
    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Moving":
                Mob.SetTargetAndMove(Global.Player, delta);
                Mob.Shoot();
                break;
        }
    }
}
