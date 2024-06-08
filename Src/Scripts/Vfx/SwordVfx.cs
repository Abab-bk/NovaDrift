using Godot;

namespace NovaDrift.Scripts.Vfx;

public partial class SwordVfx : BaseVfx
{
    [Export] public Area2D Area2D { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        Area2D.SetIsPlayer(IsPlayer);
    }
}
