using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerGunman : PowerUp
{
    public override void Use()
    {
        base.Use();
        var drone = DataBuilder.BuildDroneById(1001);
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, drone);
    }
}