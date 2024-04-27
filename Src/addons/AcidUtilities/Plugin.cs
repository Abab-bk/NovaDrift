#if TOOLS
using Godot;
using System;

namespace AcidWallStudio;

[Tool]
public partial class AcidStatsPlugin : EditorPlugin
{
    public override void _EnterTree()
    {
        // Initialization of the plugin goes here.
    }
    
    public override void _ExitTree()
    {
        // Clean-up of the plugin goes here.
    }
}
#endif