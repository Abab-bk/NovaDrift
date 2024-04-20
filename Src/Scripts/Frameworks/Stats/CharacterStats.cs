using System;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;
using Attribute = NovaDrift.addons.AcidStats.Attribute;

namespace NovaDrift.Scripts.Frameworks.Stats;

public class CharacterStats
{
    public Action OnBodyChanged;
    
    public int Level = 1;

    public Body Body = new Body();

    public Attribute Health;
    public Stat Speed = new Stat(100);
    public Stat Damage = new Stat(30);
    public Attribute Exp = new Attribute(0, 100);
    
    // 武器射击速度
    public Stat ShootSpeed = new Stat(0.5f); // 射击速度，单位为秒，越低越快
    public Stat BulletSpeed = new Stat(1000f); // 子弹射速
    public Stat ShootSpread = new Stat(0f);
    
    // 一般是给玩家用的，无限，一般是Mod
    public readonly EffectSystem EffectSystem = new EffectSystem();
    // 效果
    public readonly BuffSystem BuffSystem = new BuffSystem();
    private Actor _target;

    public void AddBuff(Buff buff)
    {
        BuffSystem.AddBuff(buff);
    }

    public void SetTarget(Actor target)
    {
        _target = target;
        EffectSystem.Target = _target;
        BuffSystem.Target = _target;
    }
    
    public void AddEffect(Effect effect)
    {
        EffectSystem.AddEffect(effect);
    }

    public CharacterStats SetShootSpeed(float value)
    {
        ShootSpeed.BaseValue = value;
        return this;
    }
    
    public CharacterStats SetExp(float value)
    {
        Exp.BaseValue = value;
        return this;
    }

    public CharacterStats SetHealth(float value)
    {
        Health.BaseValue = value;
        return this;
    }

    public CharacterStats SetSpeed(float value)
    {
        Speed.BaseValue = value;
        return this;
    }

    public CharacterStats SetDamage(float value)
    {
        Damage.BaseValue = value;
        return this;
    }
    
    public CharacterStats SetBody(Body value)
    {
        Body = value;
        Health = new Attribute(0, Body.Health);
        OnBodyChanged?.Invoke();
        return this;
    }
    
    public CharacterStats()
    {
        Health = new Attribute(0, Body.Health);
        
        Exp.ValueToMax += (float value) =>
        {
            Level += 1;
        };
    }
}