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

    private readonly List<SnakeBody> _snakeBodies = new List<SnakeBody>();
    
    public void AddPart()
    {
        var snakeBody = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/SnakeBody.tscn").Instantiate<SnakeBody>();

        if (_snakeBodies.Count == 0)
        {
            snakeBody.Target = Actor;
        }
        else
        {
            snakeBody.Target = _snakeBodies.Last();
        }
        
        _snakeBodies.Add(snakeBody);
        Global.GameWorld.AddChild(snakeBody);
        snakeBody.GlobalPosition = ToGlobal(SnakeBodySize * _snakeBodies.Count);
    }
}