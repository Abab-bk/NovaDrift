using Godot;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    public CharacterStats CharacterStats = new CharacterStats();
    protected float ShootCd = 1f;
    
    public override void _Ready()
    {
    }

    public virtual void Shoot(Vector2 targetDir)
    {
        BulletBase bullet = new BulletBuilder().SetTargetDir(targetDir).Build();
        Global.GameWorld.AddChild(bullet);
        bullet.GlobalPosition = GlobalPosition;
    }
    
}
