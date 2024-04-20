using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class Body : IItemInfo
{
    public Actor Actor;
    public int Id;
    
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath = "res://Assets/Textures/Bodies/Default.png";
    
    // TODO: 护盾
    public float Health = 100;
    public Stat Acceleration = new Stat(1000f);
    public Stat Deceleration = new Stat(300f);
    public Stat RotationSpeed = new Stat(4.5f); // 越高越灵敏
    public Stat ShootingDeceleration = new Stat(500f);
    
    private readonly List<(Stat, StatModifier)> _statModifiers = new List<(Stat, StatModifier)>();

    protected void AddModifierToTarget(StatModifier modifier, Stat target)
    {
        target.AddModifier(modifier);
        _statModifiers.Add((target, modifier));
    }
    
    public virtual void OnDestroy()
    {
        foreach (var value in _statModifiers)
        {
            value.Item1.RemoveAllModifiersFromSource(value.Item2);
        }
    }
    
    
    public Body SetName(string name)
    {
        Name = name;
        return this;
    }
    
    public Body SetDesc(string desc)
    {
        Desc = desc;
        return this;
    }
    
    public Body SetIconPath(string iconName)
    {
        IconPath = $"res://Assets/Textures/Bodies/{iconName}.png";
        return this;
    }

    public Body SetHealth(float health)
    {
        Health = health;
        return this;
    }
    
    public Body SetShootingDeceleration(float shootingDeceleration)
    {
        ShootingDeceleration.BaseValue = shootingDeceleration;
        return this;
    }
    
    public Body SetAcceleration(float acceleration)
    {
        Acceleration.BaseValue = acceleration;
        return this;
    }
    
    public Body SetDeceleration(float deceleration)
    {
        Deceleration.BaseValue = deceleration;
        return this;
    }
    
    public Body SetRotationSpeed(float rotationSpeed)
    {
        RotationSpeed.BaseValue = rotationSpeed;
        return this;
    }

    public virtual void Use()
    {
        Global.Player.Stats.SetBody(this);
        Actor = Global.Player;
    }
}