using System.Collections.Generic;
using System.Linq;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Systems.Formations;

public class Formation
{
    public MobBase Leader;
    public List<MobBase> Units = new List<MobBase>();
    public List<Vector2> UnitPoints = new List<Vector2>();

    private FormationPainter _painter;
    private float _averageSpeed;
    private float _averageAcceleration;

    public void Move(Vector2 dir, float delta)
    {
        foreach (var unit in Units)
        {
            var targetVelocity = _averageSpeed * dir;
            unit.Velocity = unit.Velocity.MoveToward(targetVelocity, _averageAcceleration * delta);
            
            unit.MoveAndSlide();
        }
    }

    public Vector2 GetPoint(MobBase unit)
    {
        if (Units.Contains(unit))
        {
            return UnitPoints[Units.IndexOf(unit)];
        }
        
        Logger.LogError("[Formation] GetPoint: Unit not in Formation");
        return Vector2.Zero;
    }

    public void GenerateLeader()
    {
        Leader = Units[Units.Count / 2];

        // _painter = new FormationPainter() { UnitPoints = UnitPoints};
        // Leader.AddChild(_painter);

        _averageSpeed = Units
            .SelectMany(mob => Enumerable.Repeat(mob.Stats.Speed.Value, 1))
            .Average();
        _averageAcceleration = Units
            .SelectMany(mob => Enumerable.Repeat(mob.Stats.Acceleration.Value, 1))
            .Average();
        
        Logger.Log($"""
                    [Formation] Leader: {Leader.Name}
                                Average Speed: {_averageSpeed}
                                Average Acceleration: {_averageAcceleration}
                    """);
    }
}