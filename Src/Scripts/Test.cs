using AcidWallStudio.Fmod;
using FMOD;
using FMOD.Studio;
using Godot;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    private Sprite2D _testSprite2d;
    
    public override void _Ready()
    {
        _testSprite2d = GetNode<Sprite2D>("Sprite2D");

        var sprite2 = GetNode<Sprite2D>("Sprite2D2");
        Global.PlayerStand = sprite2;
        
        SoundManager.Initialize();
        _testSprite2d.PlaySound("event:/TestEvent");
    }

    public override void _PhysicsProcess(double delta)
    {
        SoundManager.Update();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey key)
        {
            if (key.Pressed)
            {
                // SoundManager.PlayOneShotById("event:/OnBulletHit");
            }
        }
    }
}
