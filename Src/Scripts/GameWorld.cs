using AcidJoystick;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts;

public partial class GameWorld : Node2D
{
    private Joystick _moveJoystick;
    private Joystick _aimJoystick;
    
    public override void _Ready()
    {
        _moveJoystick = GetNode<Joystick>("%MoveJoystick");
        _aimJoystick = GetNode<Joystick>("%AimJoystick");
        
        DataBuilder.Init();

        _moveJoystick.Visible = Global.CurrentPlatform == GamePlatform.Desktop;
        _aimJoystick.Visible = Global.CurrentPlatform == GamePlatform.Desktop;

        Global.GameWorld = this;

        UiManager.Open_Hud();
        
        Player player = GD.Load<PackedScene>("res://Scenes/Prefabs/Actors/Player.tscn").Instantiate<Player>();
        player.JoystickNode = _moveJoystick;
        AddChild(player);
    }
}
