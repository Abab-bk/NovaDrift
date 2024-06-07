using System;
using System.Collections.Generic;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Ui.AbilityItem;

namespace NovaDrift.Scripts.Systems;

public class EffectSystem
{
    public event Action<Ability> OnAbilityAdded;
    public event Action<Ability> OnAbilityRemoved;
    
    public Actor Target;
    public readonly List<Effect> Effects = new List<Effect>();
    public readonly List<Ability> Abilities = new List<Ability>();
    
    public void AddEffect(Ability ability)
    {
        Abilities.Add(ability);
        Logger.Log($"[Effect System] Add effect: {ability.Name}");
        // ability.OnDestroyed += RemoveEffect;
        
        var effect = ability.Effect;
        
        effect.Target = Target;
        effect.OnCreate();
        Effects.Add(effect);
        
        OnAbilityAdded?.Invoke(ability);
    }
    
    public void RemoveAllEffects()
    {
        List<Ability> removed = new List<Ability>();
        foreach (var ability in Abilities)
        {
            removed.Add(ability);
        }

        foreach (var ability in removed)
        {
            RemoveEffect(ability);
        }
    }

    public void RemoveEffect(Ability ability)
    {
        ability.Effect.OnDestroy();
        Abilities.Remove(ability);
        Effects.Remove(ability.Effect);
        Logger.Log($"[Effect System] Remove effect: {ability.Name}");
        OnAbilityRemoved?.Invoke(ability);
    }
}