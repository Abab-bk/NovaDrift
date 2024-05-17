using Godot;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    public override void _Ready()
    {
        AudioSystem.Awake();
    }

    public override void _PhysicsProcess(double delta)
    {
        AudioSystem.GetInstance().Update();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey key)
        {
            if (key.Pressed)
            {
                AudioSystem.GetInstance().PlayOneShotByGuid("{a316c092-2833-46dd-a2bc-197de6de0e83}");
            }
        }
    }
}
