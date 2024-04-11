using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class Effect
{
    // 目标
    public Actor Target;
    // 冷却时间
    public float Cooldown = 0f;
    // 是否无限时间
    public bool Infinite = false;
    // 是否自动开启
    public bool AutoStart = false;

    public void AddModifierToTarget(StatModifier modifier, Stat target)
    {
        if (Target == null) return;
        target.AddModifier(modifier);
    }

    public virtual void OnCreate()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void OnDestroy()
    {
    }
}