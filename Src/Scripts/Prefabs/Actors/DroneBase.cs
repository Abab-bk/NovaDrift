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
        Velocity = targetVelocity;
    }

    public void SetTargetPosAndMove(Vector2 pos, float delta)
    {
        // LookAt(pos);
        TryMoveTo(GlobalPosition.DirectionTo(pos), delta);
    }
    
    public void TryMoveToPlayer(float delta)
    {
        var player = Global.Player;
        if (player == null) return;
        TryMoveTo(GlobalPosition.DirectionTo(player.GlobalPosition), delta);
    }

    public void TryStop(double delta)
    {
        Velocity = Vector2.Zero;
    }
    
    public BulletBase GetBullet()
    {
        return new BulletBuilder().
            SetIsPlayer(true).
            SetDamage(DroneInfo.Damage).
            SetSpeed(DroneInfo.BulletSpeed).
            SetSize(1f).
            SetDegeneration(10f).
            SetSteering(DroneInfo.Targeting).
            Build();
    }
    
    public void Shoot()
    {
        if (!_shootTimer.IsStopped()) return;
        _shootTimer.Start();

        for (int i = 0; i < DroneInfo.BulletCount; i++)
        {
            var bullet = GetBullet();
                
            bullet.GlobalPosition = FrontMarker.GlobalPosition;
            if (DroneInfo.BulletCount == 1)
            {
                bullet.Direction = bullet.Direction.Rotated(GlobalRotation);
            }
            else
            {
                float arcRad = Mathf.DegToRad(Global.Player.Stats.ShootSpread.Value);
                float increment = arcRad / (DroneInfo.BulletCount - 1);
                bullet.Direction = bullet.Direction.Rotated(GlobalRotation + increment * i - arcRad / 2);
            }

            Global.GameWorld.AddChild(bullet);
        }
    }
}
