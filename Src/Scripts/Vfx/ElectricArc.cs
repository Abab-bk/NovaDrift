using Godot;
using System;
using Godot.Collections;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Vfx;

public partial class ElectricArc : BaseVfx
{
    public event Action<Node2D> OnBodyEntered;
    
    public float Radius
    {
        set => _circleLine2D.Radius = value;
    }

    [Export] private CircleLine2D _circleLine2D;
    [Export] private FastNoiseLite _noise;
    
    public override void _Ready()
    {
        base._Ready();
        _circleLine2D.Area2D.SetIsPlayer(IsPlayer);
        _circleLine2D.Area2D.BodyEntered += (body) => OnBodyEntered?.Invoke(body);
    }

    public Array<Node2D> GetOverLappingBodies()
    {
        return _circleLine2D.Area2D.GetOverlappingBodies();
    }

    // public override void _Process(double delta)
    // {
    //     for (int i = 0; i < _circleLine2D.GetPointCount(); i++)
    //     {
    //         var noiseOffsetX = _noise.GetNoise2D(i, 0f);
    //         var noiseOffsetY = _noise.GetNoise2D(0f, i);
    //         var noiseValue = new Vector2(noiseOffsetX, noiseOffsetY);
    //
    //         Vector2 finalPoint;
    //         
    //         if (Random.Shared.Next(0, 2) == 0)
    //         {
    //             finalPoint = _circleLine2D.GetPointPosition(i) + noiseValue;
    //         }
    //         else
    //         {
    //             finalPoint = _circleLine2D.GetPointPosition(i) - noiseValue;
    //         }
    //
    //         _circleLine2D.SetPointPosition(i, finalPoint);
    //     }
    // }
}
