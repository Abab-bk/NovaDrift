using AcidJoystick;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts;

public partial class GameWorld : Node2D
{
    public override void _Ready()
    {
        DataBuilder.Init();
        
        Global.GameWorld = this;

        UiManager.Open_Hud();
        
        Player player = GD.Load<PackedScene>("res://Scenes/Prefabs/Actors/Player.tscn").Instantiate<Player>();
        player.JoystickNode = GetNode<Joystick>("%Joystick");
        AddChild(player);
    }
}
