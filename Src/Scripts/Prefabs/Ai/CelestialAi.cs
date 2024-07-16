using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems.Pool;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class CelestialAi : MobAiComponent
{
    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Moving":
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Clone":
                Mob.Velocity = Vector2.Zero;

                for (int i = 0; i < 3; i++)
                {
                    var mob = GetTree().GetNodesInGroup("Mobs").PickRandom() as MobBase;
                    if (mob == null) break;
                    
                    var clone = Pool.CloneMobPools[mob.MobInfo.Id].Get();
                    clone.GlobalPosition = Mob.GlobalPosition;
                    clone.Show();
                }
                
                break;
        }
    }
}
