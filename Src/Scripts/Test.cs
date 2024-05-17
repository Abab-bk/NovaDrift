using AcidWallStudio.Fmod;
using Godot;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    public override void _Ready()
    {
        Fmod.Initialize();
    }

    public override void _PhysicsProcess(double delta)
    {
        Fmod.Update();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey key)
        {
            if (key.Pressed)
            {
                Fmod.PlayOneShotById("event:/OnBulletHit");
            }
        }
    }
}
