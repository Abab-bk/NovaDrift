using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class SpawnPoint : Marker2D
{
    private static Dictionary<string, List<Vector2>> _points = new ();
    
    [Export] private string _category;

    public static Vector2 GetPoint(string category)
    {
        if (_points.TryGetValue(category, out var value))
        {
            return value.PickRandom();
        }
        return Vector2.Zero;
    }

    public override void _Ready()
    {
        AddToGroup("SpawnPoints");
        if (_category == "") return;

        if (_points.TryGetValue(_category, out var value))
        {
            value.Add(GlobalPosition);
        }
        else
        {
            _points.Add(_category, new List<Vector2>(){ GlobalPosition });
        }

        QueueFree();
    }
}