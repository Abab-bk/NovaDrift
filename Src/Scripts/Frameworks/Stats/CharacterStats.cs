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
    public readonly Stat Speed = new Stat(100);
    public readonly Stat Damage = new Stat(30);
    public readonly Attribute Exp = new Attribute(0, 100);
    
    // 武器射击速度
    public readonly Stat ShootSpeed = new Stat(0.5f); // 射击速度，单位为秒，越低越快
    public readonly Stat BulletSpeed = new Stat(1000f); // 子弹速度
    public readonly Stat ShootSpread = new Stat(0f); // TODO: 修改每个射弹对组合射弹的弧线贡献的角度或宽度。
    public readonly Stat ShootKnockBack = new Stat(10f); // 打中后对目标的击退
    public readonly Stat BurstFire = new Stat(1f); // 使你非常快速地多次发射武器，然后等待相同数量的武器冷却时间，然后才能再次发射，再加上 0.04 秒的单次平坦延迟。
    
    public readonly Stat BulletSize = new Stat(1f); // 子弹大小，单位缩放
    public readonly Stat BulletDegeneration = new Stat(1f); // 子弹退化速度（也就是从开始到消失需要的速度）
    public readonly Stat Recoil = new Stat(0f); // TODO: 射击后武器把自己击退的速度
    public readonly Stat BulletCount = new Stat(1f); // TODO: 发射的子弹数量
    public readonly Stat BlastDamage = new Stat(0f); // TODO: 爆炸伤害
    public readonly Stat BlastRadius = new Stat(0f); // TODO: 爆炸半径
    
    // 一般是给玩家用的，无限，一般是Mod
    public readonly EffectSystem EffectSystem = new EffectSystem();
    // 效果
    public readonly BuffSystem BuffSystem = new BuffSystem();
    private Actor _target;
    private readonly Stat _knockBack = new Stat(10);

    public void AddKnockBack(float value)
    {
        _knockBack.BaseValue += value;
    }

    public float GetKnockBack()
    {
        return _knockBack.Value;
    }
    
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