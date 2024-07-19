using System.Collections.Generic;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Shields;

namespace NovaDrift.Scripts.Systems;

public class Shield : IItemInfo
{
    public Actor Actor;
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath { get; set; }
    public string IconPath2 { get; set; }
    public float Health;
    public float CoolDown;

    public string SceneName;
    public List<float> Values = new List<float>();
    
    public void Use()
    {
        Actor = Global.Player;
        
        var shield = GD.Load<PackedScene>($"res://Scenes/Prefabs/Shields/{SceneName}.tscn").Instantiate<BaseShield>();
        shield.Shield = this;
        shield.Values = Values;
        shield.Health = new Attribute(0, Health);
        shield.CoolDown = CoolDown;
        
        var originalShield = Global.Player.Shield;

        if (originalShield != null)
        {
            originalShield.Destroy();
            originalShield.QueueFree();
        }
        
        // shield.IsPlayer = true;
        shield.Target = Global.Player;
        Global.Player.SetShield(shield);
        Global.Player.ShieldNode.AddChild(shield);
        shield.SetPlayerColor();
    }
}