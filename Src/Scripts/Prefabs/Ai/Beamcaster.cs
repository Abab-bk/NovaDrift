using System;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Beamcaster : MobAiComponent
{
    [Export] private Timer _timer;

    public override void _Ready()
    {
        base._Ready();
        _timer.Timeout += () => { Machine.SetTrigger("Next"); };
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Moving":
                var dir = Wizard.GetRandom8Dir();
                Mob.TryMoveTo(dir, delta);
                break;
            case "Idle":
                Mob.TryStop(delta);
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Moving":
                _timer.WaitTime = Random.Shared.FloatRange(3f, 7f);
                _timer.Start();
                break;
            case "Idle":
                _timer.WaitTime = Random.Shared.FloatRange(1f, 2f);
                _timer.Start();
                break;
        }
    }
}