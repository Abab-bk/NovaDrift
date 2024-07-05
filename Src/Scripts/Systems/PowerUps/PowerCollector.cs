using Godot;

namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerCollector : PowerUp
{
    public override void Use()
    {
        base.Use();
        var drone = DataBuilder.BuildDroneById(1002);
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, drone);
    }
}