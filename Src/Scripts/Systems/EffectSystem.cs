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
        ability.OnDestroyed += RemoveEffect;
        
        var effect = ability.Effect;
        
        effect.Target = Target;
        effect.OnCreate();
        Effects.Add(effect);
        
        OnAbilityAdded?.Invoke(ability);
    }

    public void RemoveEffect(Ability ability)
    {
        Abilities.Remove(ability);
        Effects.Remove(ability.Effect);
        OnAbilityRemoved?.Invoke(ability);
    }
}