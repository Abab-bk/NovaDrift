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
    public Action OnShieldChanged;
    
    public int Level = 1;

    public Body Body = new Body();
    public Shield Shield = new Shield();

    public Attribute Health;
    public readonly Stat Speed = new Stat(1000);
    public readonly Stat Damage = new Stat(30);
    public readonly Attribute Exp = new Attribute(0, 100);
    
    // 武器射击速度
    public readonly Stat 
        ShootSpeed = new Stat(0.5f), // 射击速度，单位为秒，越低越快
        BulletSpeed = new Stat(1500f), // 子弹速度
        ShootSpread = new Stat(120f), // 武器散布 Spread
        ShootKnockBack = new Stat(10f), // 打中后对目标的击退
        BurstFire = new Stat(1f), // 你的武器会快速射击，然后进入一个冷却状态，这个冷却时间与已射出的子弹的冷却时间总和相等。
    
        BulletSize = new Stat(1f), // 子弹大小，单位缩放
        BulletDegeneration = new Stat(10f), // 子弹退化速度（也就是从开始到消失需要的速度）
        Recoil = new Stat(50f), // 射击后武器把自己击退的速度
        BulletCount = new Stat(1f), // 发射的子弹数量
        BlastDamage = new Stat(20f), // 爆炸伤害
        BlastRadius = new Stat(100f), // 爆炸半径
        
        Acceleration = new Stat(1000),
        Deceleration = new Stat(500),
        RotationSpeed = new Stat(1), // 越高越灵敏
        ShootingDeceleration = new Stat(1),
        
        ShieldCoolDown = new Stat(0.0f), // 护盾恢复冷却时间
        ShieldPower = new Stat(0.0f), // 护盾除了保护目标外的任何效果的力量
        ShieldRadius = new Stat(200f); // 护盾半径
    
    
    // 一般是给玩家用的，无限持续时间，一般是Mod
    public readonly EffectSystem EffectSystem = new EffectSystem();
    // 效果，有持续时间一般，比如燃烧状态
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
    
    public void AddEffect(Ability ability)
    {
        EffectSystem.AddEffect(ability);
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
        OnBodyChanged?.Invoke();
        return this;
    }
    
    public CharacterStats SetShield(Shield value)
    {
        Shield = value;
        OnShieldChanged?.Invoke();
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