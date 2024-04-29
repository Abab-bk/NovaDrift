using Godot;
using Godot.Collections;
using NathanHoad;
using NovaDrift.Scripts;

public partial class Blast : Node2D
{
    [Export] private Area2D _area2D;
    
    public override void _Ready()
    {
        SoundManager.PlaySound(SoundPaths.Blast);
    }

    public Array<Node2D> GetBodies()
    {
        return _area2D.GetOverlappingBodies();
    }
}
