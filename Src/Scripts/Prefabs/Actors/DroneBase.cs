using Godot;
using System;
using cfg;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class DroneBase : CharacterBody2D
{
    public event Action OnDied;
    
    [GetNode("FrontMarker")] public Marker2D FrontMarker;
    [GetNode("ShootTimer")] private Timer _shootTimer;
    
    public DroneInfo DroneInfo;
    
    private PureHurtBox _pureHurtBox;

    public override void _Ready()
    {
        _shootTimer.WaitTime = DroneInfo.ShootCd;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }
    
    public void TryMoveTo(Vector2 dir, double delta)
    {
        var targetVelocity = dir * DroneInfo.Speed;
        Velocity = Velocity.MoveToward(targetVelocity, (float)delta);
    }

    public void TryMoveToPlayer(float delta)
    {
        var player = Global.Player;
        if (player == null) return;
        TryMoveTo(GlobalPosition.DirectionTo(player.GlobalPosition), delta);
    }

    public void TryStop(double delta)
    {
        Velocity = Velocity.MoveToward(Vector2.Zero, (float)delta);
    }
    
    public BulletBase GetBullet()
    {
        return new BulletBuilder().
            SetIsPlayer(true).
            SetDamage(DroneInfo.Damage).
            SetSpeed(DroneInfo.BulletSpeed).
            SetSize(1f).
            SetDegeneration(4f).
            SetSteering(DroneInfo.Targeting).
            Build();
    }
    
    public void Shoot()
    {
        // TODO: 无人机多发子弹
        if (!_shootTimer.IsStopped()) return;
        var bullet = GetBullet();
        bullet.GlobalPosition = FrontMarker.GlobalPosition;
        bullet.GlobalRotation = FrontMarker.GlobalRotation;
        _shootTimer.Start();
    }
}
