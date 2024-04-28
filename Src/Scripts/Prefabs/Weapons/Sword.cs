using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Sword : BaseShooter
{
    private Node2D _sword1;
    private Node2D _sword2;

    public override void Init()
    {
        // _sword1 = GetNode<Node2D>("%Sword1");
        // _sword1 = GetNode<Node2D>("%Sword2");
        //
        // GetNode<HitBox>("%HitBox1").SetIsPlayer(IsPlayer);
        // GetNode<HitBox>("%HitBox2").SetIsPlayer(IsPlayer);
        //
        // ShootTimer.Timeout += Run;
        // Run();
    }

    private async void Run()
    {
        // if (!ShootTimer.IsStopped())
        // {
        //     return;
        // }
        //
        // Tween tw = CreateTween();
        // tw.TweenProperty(this, "rotation_degrees", Rotation == 0 ? 360 : 0, 0.5f);
        // await ToSignal(tw, Tween.SignalName.Finished);
        // ShootTimer.Start();
    }

    public override void Shoot()
    {
        
    }

    public override void Destroy()
    {
    }

    public override void SetShootCd(float value)
    {
    }
}
