using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts;

public partial class GameWorld : Node2D
{
    public override void _Ready()
    {
        Global.GameWorld = this;

        Player player = GD.Load<PackedScene>("res://Scenes/Prefabs/Actors/Player.tscn").Instantiate<Player>();
        AddChild(player);
    }
}
