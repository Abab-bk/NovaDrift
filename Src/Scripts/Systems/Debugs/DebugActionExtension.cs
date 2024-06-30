using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;

namespace NovaDrift.Scripts.Systems.Debugs;

public static class DebugActionExtension
{
    public static IDebugAction AddCustomStat(this IDebugActionsSection section)
    {
        IDebugAction debugAction = new CustomStatDebugAction();
        section.Add(debugAction);
        return debugAction;
    }
}