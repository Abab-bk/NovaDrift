using Godot;
using System;

namespace NovaDrift.Scripts.Prefabs;

public partial class TouchActionBtn : Control
{
    [Export] private string _prompt;
    [GetNode("Button")] private TouchScreenButton _button;

    private Action _action;
    
    public override void _Ready()
    {
        Hide();
        if (Global.CurrentPlatform == GamePlatform.Desktop) return;
        EventBus.AddActionButton += (_, prompt, action) =>
        {
            if (prompt != _prompt) return;
            _button.Action = _prompt;
            _action = action;
            Show();
        };
    }
    
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(_prompt) && Visible)
        {
            _action?.Invoke();
        }
    }
}
