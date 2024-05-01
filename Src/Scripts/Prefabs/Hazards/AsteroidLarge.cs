using Godot;
using System;
using NovaDrift.Scripts;
using NovaDrift.Scripts.Prefabs.Hazards;

namespace NovaDrift.Scripts.Prefabs.Hazards;

public partial class AsteroidLarge : AsteroidBase
{
    protected override void Destroy()
    {
        for (int i = 0; i < Random.Shared.Next(2, 3); i++)
        {
            AsteroidBase asteroidSmall = GD.Load<PackedScene>("res://Scenes/Prefabs/Hazards/AsteroidSmall.tscn").Instantiate<AsteroidBase>();
            asteroidSmall.GlobalPosition = GlobalPosition + new Vector2(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100)); 
            Global.GameWorld.CallDeferred(Node.MethodName.AddChild, asteroidSmall);
        }
        
        QueueFree();
    }
}
