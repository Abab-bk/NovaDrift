#if TOOLS
using Godot;
using System;

[Tool]
public partial class Plugin : EditorPlugin
{
	public override void _EnterTree()
	{
		
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
	}
}
#endif
