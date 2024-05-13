using System;
using System.Linq.Expressions;
using Godot;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Prefabs.Bullets;

namespace NovaDrift.Scripts.Systems;

public class BulletBuilder
{
    public enum BulletType
    {
        Normal,
        FireBall,
    }
    
    private readonly BulletBase _bulletBase;

    public BulletBuilder(BulletType type = BulletType.Normal)
    {
        switch (type)
        {
            case BulletType.Normal:
                _bulletBase = GD.Load<PackedScene>("res://Scenes/Prefabs/Bullets/NormalBullet.tscn").Instantiate() as BulletBase;
                break;
            case BulletType.FireBall:
                _bulletBase = GD.Load<PackedScene>("res://Scenes/Prefabs/Bullets/FireBall.tscn").Instantiate() as BulletBase;
                break;
            default:
                _bulletBase = GD.Load<PackedScene>("res://Scenes/Prefabs/Bullets/NormalBullet.tscn").Instantiate() as BulletBase;
                throw new Exception("无法识别的子弹类型");
        }
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
        _mobBase = GD.Load<PackedScene>(mobInfo.ScenePath).Instantiate() as MobBase;
        if (_mobBase == null) throw new ("无法找到场景：" + mobInfo.ScenePath);
        _mobBase.MobInfo = mobInfo;
    }

    public MobBase Build()
    {
        return _mobBase;
    }
}