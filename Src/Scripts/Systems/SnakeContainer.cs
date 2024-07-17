using System.Collections.Generic;
using System.Linq;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Systems;

public partial class SnakeContainer : Node2D
{
    public Actor Actor;

    private PackedScene _snakeBodyScene;
    
    public readonly List<SnakeBody> SnakeBodies = new List<SnakeBody>();
    public static readonly Vector2 SnakeBodySize = new Vector2(-70f, 0);
    
    public override void _Ready()
    {
        _snakeBodyScene = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/SnakeBody.tscn");
    }
    
    public void AddPart()
    {
        var snakeBody = _snakeBodyScene.Instantiate<SnakeBody>();

        if (SnakeBodies.Count == 0)
        {
            snakeBody.IsHead = true;
        }
        else
        {
            SnakeBodies.Last().Next = snakeBody;
            snakeBody.Previous = SnakeBodies.Last();
        }

        SnakeBodies.Add(snakeBody);
        AddChild(snakeBody);
        snakeBody.GlobalPosition = ToGlobal(SnakeBodySize * (SnakeBodies.Count + 1));
    }

    public override void _PhysicsProcess(double delta)
    {
        if (SnakeBodies.Count <= 1) return;

        foreach (var snakeBody in SnakeBodies)
        {
            var manager = snakeBody.MarkerManager;
            
        }
        
        // for (int i = 1; i < SnakeBodies.Count; i++)
        // {
        //     var manager = SnakeBodies[i - 1].MarkerManager;
        //     SnakeBodies[i].GlobalPosition = manager.Markers[0].Position;
        //     SnakeBodies[i].Rotation = manager.Markers[0].Rotation;
        //     manager.Markers.RemoveAt(0);
        // }
    }
}

public partial class MarkerManager : Node2D
{
    public class Marker(Vector2 position, float rotation)
    {
        public Vector2 Position = position;
        public float Rotation = rotation;
    }

    public List<Marker> Markers = new ();

    public override void _Ready()
    {
        UpdateMarkers();
    }

    public void UpdateMarkers()
    {
        Markers.Add(new Marker(GlobalPosition, Rotation));
    }

    public void ClearMarkers()
    {
        Markers.Clear();
        Markers.Add(new Marker(GlobalPosition, Rotation));
    }
}