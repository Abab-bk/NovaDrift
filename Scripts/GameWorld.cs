using Godot;

namespace NovaDrift.Scripts;

public partial class GameWorld : Node2D
{
    public override void _Ready()
    {
        Global.GameWorld = this;
    }
}
