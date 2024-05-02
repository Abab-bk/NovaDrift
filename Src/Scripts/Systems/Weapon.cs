using System;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Weapons;

namespace NovaDrift.Scripts.Systems;

public class Weapon : IItemInfo
{
    public Actor Actor;
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath { get; set; }
    public string IconPath2 { get; set; }

    public string SceneName;
    
    // TODO: 武器扩散
    public void Use()
    {
        Actor = Global.Player;
        
        BaseShooter shooter = GD.Load<PackedScene>($"res://Scenes/Prefabs/Weapons/{SceneName}.tscn").Instantiate<BaseShooter>();
        shooter.Weapon = this;
        
        BaseShooter originalShooter = Global.Player.Shooter;
        originalShooter.Destroy();
        originalShooter.QueueFree();
        
        shooter.IsPlayer = true;
        shooter.Actor = Global.Player;
        Global.Player.Shooter = shooter;
        Global.Player.ShooterNode.AddChild(shooter);
    }
}