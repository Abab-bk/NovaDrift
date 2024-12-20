using System;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Nodes;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class ToggleDebugActionWidget : DebugActionWidget
{
    [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
    [Export] public Label? Label;
    [Export] public Button? Button;
    [Export] public CheckButton? CheckButton;

    Action<bool>? _setAction;
    Func<bool>? _getAction;
    
    public void Init(Control sizeControl, string name, Action<bool> setAction, Func<bool> getAction)
    {
        LabelAutowrapController!.SizeControl = sizeControl;
        _setAction = setAction;
        _getAction = getAction;
        
        Label!.Text = name;
        Button!.ConnectButtonPressed(Toggle);
        CheckButton!.ToggleMode = true;
        CheckButton!.ButtonPressed = _getAction!.Invoke();
    }
    
    public override bool Focus()
    {
        CheckButton!.GrabFocus();
        return true;
    }

    void Toggle()
    {
        bool newState = !CheckButton!.ButtonPressed;
        _setAction!.Invoke(newState);
        CheckButton!.ButtonPressed = _getAction!.Invoke();
    }
}