using System;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.ObjectPool;
using Godot;
using NovaDrift.Scripts.Systems.Pool;

namespace NovaDrift.Scripts.Vfx;

public partial class ExpBall : Node2D
{
    [GetNode("Area2D")] private Area2D _area;

    public bool IsActive;
    
    public override void _Ready()
    {
        AddToGroup("ExpBalls");
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += GlobalPosition.DirectionTo(Global.Player.GlobalPosition) * 10f;
        if (GlobalPosition.DistanceTo(Global.Player.GlobalPosition) > 20f) return;
        Global.Player.Stats.Exp.Increase(1);
        Release();
    }

    public void Active()
    {
        SetPhysicsProcess(true);
    }

    public void Release()
    {
        if (!IsActive) return;
        if (Pool.ExpBallPool == null)
        {
            QueueFree();
            return;
        }

        SetPhysicsProcess(false);
        Pool.ExpBallPool.Release(this);
    }
}
