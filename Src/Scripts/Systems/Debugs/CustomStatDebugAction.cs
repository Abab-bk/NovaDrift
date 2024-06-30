using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace NovaDrift.Scripts.Systems.Debugs;

public class CustomStatDebugAction : IDebugAction
{
    public string Name { get; }
    
    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        return GD
            .Load<PackedScene>("res://Scenes/Debugs/CustomStatDebugWidget.tscn")
            .Instantiate<AbilityDebugActionWidget>();;
    }
}