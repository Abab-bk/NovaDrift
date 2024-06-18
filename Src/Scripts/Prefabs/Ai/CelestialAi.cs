using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

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

                    var clone = mob.Duplicate((int)DuplicateFlags.UseInstantiation) as MobBase;
                    if (clone == null) break;
                    
                    clone.MobInfo = DataBuilder.BuildMobInfoById(mob.MobInfo.Id);
                    clone.GlobalPosition = Mob.GlobalPosition;
                    var ai = new MobAiComponent();
                    ai.SetScript(GD.Load<GodotObject>("res://Scripts/Prefabs/Ai/CloneMobAi.cs"));
                    clone.Ai = ai;
                    
                    Global.GameWorld.CallDeferred(Node.MethodName.AddChild, clone);
                    clone.AddChild(ai);
                }
                
                break;
        }
    }
}
