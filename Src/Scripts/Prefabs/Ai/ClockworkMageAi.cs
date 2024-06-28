using Godot;
using System;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class ClockworkMageAi : MobAiComponent
{
    [Export] private DragonController _dragonController;

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Idle":
                _dragonController.Play("Idle");
                break;
        }
    }
}
