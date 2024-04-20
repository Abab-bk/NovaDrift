using System.Collections.Generic;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class EffectSystem
{
    public Actor Target;
    public List<Effect> Effects = new List<Effect>();
    
    public void AddEffect(Effect effect)
    {
        effect.Target = Target;
        effect.OnCreate();
        Effects.Add(effect);
        effect.OnDestroyed += RemoveEffect;
    }

    public void RemoveEffect(Effect effect)
    {
        Effects.Remove(effect);
    }
}