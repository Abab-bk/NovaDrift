using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Systems;

public class Weapon : IItemInfo
{
    public Actor Actor;

    public string Name { get; set; }
    public string Desc { get; set; }
    public string SceneName;
    
    // TODO: 武器扩散
    public void Use()
    {
        Actor = Global.Player;
        
        Shooter shooter = GD.Load<PackedScene>($"res://Scenes/Prefabs/Weapons/{SceneName}.tscn").Instantiate<Shooter>();
        shooter.Weapon = this;
        
        Shooter originalShooter = Global.Player.Shooter;
        originalShooter.Destroy();
        originalShooter.QueueFree();
        
        shooter.IsPlayer = true;
        shooter.Actor = Global.Player;
        Global.Player.Shooter = shooter;
        Global.Player.ShooterNode.AddChild(shooter);
    }
}