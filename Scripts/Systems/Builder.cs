using Godot;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Systems;

public class BulletBuilder
{
    private readonly BulletBase _bulletBase = GD.Load<PackedScene>("res://Scenes/Prefabs/BulletBase.tscn").Instantiate() as BulletBase;
    
    
    public BulletBuilder SetTargetDir(Vector2 target)
    {
        _bulletBase.SetTargetDir(target);
        return this;
    }
    
    public BulletBase Build()
    {
        return _bulletBase;
    }
}