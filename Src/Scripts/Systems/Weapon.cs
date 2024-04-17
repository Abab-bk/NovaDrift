using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Systems;

public class Weapon : IItemInfo
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string SceneName;
    
    // TODO: 武器射速
    // TODO: 武器扩散
    // TODO: 子弹速度
    
    public void Use()
    {
        Shooter shooter = GD.Load<PackedScene>($"res://Scenes/Prefabs/Weapons/{SceneName}.tscn").Instantiate<Shooter>();
        
        Shooter originalShooter = Global.Player.Shooter;
        originalShooter.QueueFree();
        
        shooter.IsPlayer = true;
        Global.Player.ShooterNode.AddChild(shooter);
        Global.Player.Shooter = shooter;
        
        shooter.Actor = Global.Player;
    }
}