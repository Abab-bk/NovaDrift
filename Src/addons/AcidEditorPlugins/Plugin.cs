#if TOOLS
using Godot;
using System;

[Tool]
public partial class Plugin : EditorPlugin
{
	private Control _control;
	
	public override void _EnterTree()
	{
		_control = GD.Load<PackedScene>("res://addons/AcidEditorPlugins/Ui.tscn").Instantiate<Control>();
		AddControlToDock(DockSlot.LeftBl, _control);
	}

	public override void _ExitTree()
	{
		RemoveControlFromDocks(_control);
		_control.QueueFree();
	}
}
#endif
