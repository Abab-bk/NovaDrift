using System;
using Godot;

namespace NovaDrift.Scripts.Ui.ActionBtn;

public partial class ActionBtnPanel : ActionBtn
{
    public event Action OnPressed;

    private string _action;
    
    public override void OnCreateUi()
    {
        
    }

    public void UpdateUi(string prompt, string action)
    {
        S_Label.Instance.Text = prompt;
        _action = action;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(_action))
        {
            OnPressed?.Invoke();
        }
    }

    public override void OnDestroyUi()
    {
        
    }

}
