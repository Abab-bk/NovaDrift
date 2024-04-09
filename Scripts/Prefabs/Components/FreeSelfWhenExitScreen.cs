using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class FreeSelfWhenExitScreen : VisibleOnScreenNotifier2D
{
    public override void _Ready()
    {
        ScreenExited += delegate
        {
            Owner.CallDeferred("queue_free");
        };
    }
}