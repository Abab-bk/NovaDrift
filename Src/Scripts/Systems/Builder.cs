using System;
using Godot;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Prefabs.Bullets;

namespace NovaDrift.Scripts.Systems;

public class BulletBuilder
{
    public enum BulletType
    {
        Normal,
        FireBall,
        Grenade,
        Shit,
    }
    
    private BulletBase _bulletBase;

    public BulletBuilder(BulletType type = BulletType.Normal)
    {
        switch (type)
        {
            case BulletType.Normal:
                _bulletBase = Pool.Pool.NormalBulletPool.Get();
                break;
            case BulletType.FireBall:
                _bulletBase = Pool.Pool.FireBallBulletPool.Get();
                break;
            case BulletType.Grenade:
                _bulletBase = Pool.Pool.GrenadeBulletPool.Get();
                break;
            case BulletType.Shit:
                _bulletBase = Pool.Pool.ShitBulletPool.Get();
                break;
            default:
                _bulletBase = Pool.Pool.NormalBulletPool.Get();
                break;
        }
    }

    public BulletBuilder SetBulletBase(string path)
    {
        _bulletBase = GD.Load<PackedScene>(path).Instantiate<BulletBase>();
        return this;
    }


    public BulletBuilder SetOwner(Actor owner)
    {
        _bulletBase.Target = owner;
        return this;
    }

    public BulletBuilder SetDegeneration(float degeneration)
    {
        _bulletBase.Degeneration = degeneration;
        return this;
    }

    public BulletBuilder SetSize(float size)
    {
        _bulletBase.Size = size;
        return this;
    }

    public BulletBuilder SetIsPlayer(bool isPlayer)
    {
        _bulletBase.IsPlayer = isPlayer;
        return this;
    }

    public BulletBuilder SetDamage(float damage)
    {
        _bulletBase.Damage = damage;
        return this;
    }

    public BulletBuilder SetSpeed(float speed)
    {
        _bulletBase.Speed = speed;
        return this;
    }
    
    public BulletBuilder SetBlastRadius(float blastRadius)
    {
        if (_bulletBase is not IBlaster blaster) throw new Exception("子弹类型不支持爆炸");
        blaster.SetBlastRadius(blastRadius);
        return this;
    }

    public BulletBuilder SetSteering(float steering)
    {
        _bulletBase.Steering = steering;
        return this;
    }

    public BulletBase Build()
    {
        return _bulletBase;
    }
}

public class MobBuilder
{
    private readonly MobBase _mobBase;

    public MobBuilder(MobInfo mobInfo)
    {
        _mobBase = GD.Load<PackedScene>(mobInfo.ScenePath).Instantiate<MobBase>();
        _mobBase.MobInfo = mobInfo;
    }

    public MobBase Build()
    {
        return _mobBase;
    }
}