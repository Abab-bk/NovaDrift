using Godot;

namespace NovaDrift.Scripts;

public partial class StateDebugger : Control
{
    [GetNode("%CurrentStateLabel")] private Label _currentStateLabel;

    private HFSM _stateMachine;
    
    public override void _Ready()
    {
        _stateMachine = HFSMUtils.TryConvert<HFSM>(GetNode("%HFSM"));
    }

    public override void _Process(double delta)
    {
        if (_stateMachine == null) return;
        _currentStateLabel.Text = $"Current State: {_stateMachine.GetCurrentState().GetName()}";
    }
}
