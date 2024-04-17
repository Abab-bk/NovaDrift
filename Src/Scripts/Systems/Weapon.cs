using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Systems;

public class Weapon : IItemInfo
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string SceneName;
    
    public Stat ShootSpeed = new Stat(1f); // 射击速度，单位为秒，越低越快
    public Stat BulletSpeed = new Stat(1000f); // 子弹射速
    public Stat ShootSpread = new Stat(0f);
    
    // TODO: 武器扩散
    
    public void Use()
    {
        Shooter shooter = GD.Load<PackedScene>($"res://Scenes/Prefabs/Weapons/{SceneName}.tscn").Instantiate<Shooter>();
        shooter.Weapon = this;
        
        Shooter originalShooter = Global.Player.Shooter;
        originalShooter.QueueFree();
        
        shooter.IsPlayer = true;
        Global.Player.ShooterNode.AddChild(shooter);
        Global.Player.Shooter = shooter;
        
        shooter.Actor = Global.Player;
    }
}