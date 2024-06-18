using Godot;

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

                var info = DataBuilder.BuildMobInfoById(Mob.MobInfo.Id);
                info.Size = 0.7f;
                
                var mob = Global.WaveSpawnerController.GenerateAMob(info, pos);
                
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
