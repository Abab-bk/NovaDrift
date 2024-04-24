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
    public string IconPath { get; set; }

    // TODO: 护盾
    public float Health = 100;
    
    public float Acceleration = 1000f;
    public float Deceleration = 300f;
    public float RotationSpeed = 3f; // 越高越灵敏

    public List<float> Values = new List<float>();
    
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

    public virtual void Use()
    {
        Actor = Global.Player;

        Actor.Stats.Body.OnDestroy();
        
        Global.Player.Stats.SetBody(this);
        
        AddModifierToTarget(new StatModifier(Health, StatModType.Flat), Actor.Stats.Health.MaxValue);
        AddModifierToTarget(new StatModifier(Acceleration, StatModType.Flat), Actor.Stats.Acceleration);
        AddModifierToTarget(new StatModifier(Deceleration, StatModType.Flat), Actor.Stats.Deceleration);
        AddModifierToTarget(new StatModifier(RotationSpeed, StatModType.Flat), Actor.Stats.RotationSpeed);
    }
}