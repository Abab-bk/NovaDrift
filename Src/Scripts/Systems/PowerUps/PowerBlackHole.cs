using Godot;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerBlackHole : PowerUp
{
    public override void Use()
    {
        base.Use();
        var blackHole = GD
            .Load<PackedScene>("res://Scenes/Prefabs/Others/BlackHole.tscn")
            .Instantiate<BlackHole>();
        blackHole.GroupName = "NormalMobs";
        blackHole.Life = 5;
        blackHole.GlobalPosition = Global.Player.GlobalPosition;
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, blackHole);
        
        blackHole.OnDead += () =>
        {
            blackHole.QueueFree();
        };
        
        blackHole.OnActorEnter += actor =>
        {
            actor.TakeDamageWithoutKnockBack(10f);
        };
    }
}