using System.Collections.Generic;
using System.Linq;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Systems;

public partial class SnakeContainer : Node2D
{
    public static readonly Vector2 SnakeBodySize = new Vector2(-70f, 0);
    
    public Actor Actor;

    private List<SnakeBody> _snakeBodies = new List<SnakeBody>();
    
    public void AddPart()
    {
        var snakeBody = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/SnakeBody.tscn").Instantiate<SnakeBody>();
        snakeBody.Actor = Actor;
        _snakeBodies.Add(snakeBody);
        Global.GameWorld.AddChild(snakeBody);
        snakeBody.GlobalPosition = ToGlobal(SnakeBodySize * _snakeBodies.Count);
    }
}