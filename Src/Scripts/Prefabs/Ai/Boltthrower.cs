using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Boltthrower : MobAiComponent
{
    [Export] private Timer _timer;

    public override void _Ready()
    {
        base._Ready();
        _timer.Timeout += () =>
        {
            Mob.Stats.Speed.BaseValue += 100f;
        };
    }

    public override void Active()
    {
        base.Active();
        _timer.Start();
    }

    public override void Release()
    {
        base.Release();
        _timer.Stop();
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