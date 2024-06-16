using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Boltthrower : MobAiComponent
{
    [Export] private Timer _timer;
    
    public override void _Ready()
    {
        base._Ready();
        _timer.Start();
        _timer.Timeout += () =>
        {
            Mob.Stats.Speed.BaseValue += 100f;
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