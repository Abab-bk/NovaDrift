using Godot;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Systems;

public class BulletBuilder
{
    private readonly BulletBase _bulletBase = GD.Load<PackedScene>("res://Scenes/Prefabs/BulletBase.tscn").Instantiate() as BulletBase;

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
    
    public BulletBase Build()
    {
        return _bulletBase;
    }
}

public class MobBuilder
{
    private readonly MobBase _mobBase = GD.Load<PackedScene>("res://Scenes/Prefabs/Actors/Mobs/MobBase.tscn").Instantiate() as MobBase;
    
    public MobBase Build()
    {
        return _mobBase;
    }

    public MobBuilder SetMobInfo(MobInfo mobInfo)
    {
        _mobBase.MobInfo = mobInfo;
        return this;
    }
}