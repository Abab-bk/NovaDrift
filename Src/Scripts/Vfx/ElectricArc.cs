using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Vfx;

public partial class ElectricArc : BaseVfx
{
    public event Action<Node2D> OnBodyEntered;

    public float Radius
    {
        set => _circleLine2D.Radius = value;
    }

    [Export] private float _animationFactor;
    [Export] private CircleLine2D _circleLine2D;
    [Export] private FastNoiseLite _noise;
    [Export] private Curve _curve;

    private float _time;
    
    public override void _Ready()
    {
        base._Ready();
        _circleLine2D.Area2D.SetIsPlayer(IsPlayer);
        _circleLine2D.Area2D.BodyEntered += (body) => OnBodyEntered?.Invoke(body);
    }

    // public override void _Process(double delta)
    // {
    //     _time += (float)delta;
    //     for (int i = 0; i < _circleLine2D.GetPointCount(); i++)
    //     {
    //         var deviationFactor = _curve.Sample((i + 1) / 100f);
    //         var noiseValue = _noise.GetNoise2D(i + 1, _time);
    //         var finalPoint = _circleLine2D.GetPointPosition(i) * (1f + noiseValue) * deviationFactor;
    //         _circleLine2D.SetPointPosition(i, finalPoint);
    //     }
    // }
}
