using Godot;
using NovaDrift.Scripts.Systems.Pool;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class GyrogunAi : MobAiComponent
{
    public override void _Ready()
    {
        base._Ready();
        Mob.OnDied += () =>
        {
            var pos = Mob.GlobalPosition;
            for (int i = 0; i < 2; i++)
            {
                if (Mob.Tags.Contains("IsClone")) continue;
                
                var mob = Pool.CloneMobPools[Mob.MobInfo.Id].Get();
                mob.GlobalPosition = Mob.GlobalPosition;
                mob.Scale = new Vector2(0.7f, 0.7f);
                mob.Show();
                
                mob.Tags.Add("IsClone");
            }
        };
    }

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
}
