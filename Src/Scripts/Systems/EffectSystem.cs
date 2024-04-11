using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class EffectSystem
{
    public Actor Target;
    public void AddEffect(Effect effect)
    {
        effect.Target = Target;
        effect.OnCreate();
    }

    public void RemoveEffect(Effect effect)
    {
    }
}