using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class FreeSelfWhenExitScreen : VisibleOnScreenNotifier2D
{
    [Export] private string ReleaseMethod = "queue_free";
    
    public override void _Ready()
    {
        ScreenExited += delegate
        {
            Owner.CallDeferred(ReleaseMethod);
        };
    }
}