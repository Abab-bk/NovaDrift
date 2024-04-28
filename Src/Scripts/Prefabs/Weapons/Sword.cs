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
    private AnimationPlayer _animationPlayer;
    
    private bool _isShooting = false;
    
    public override void Init()
    {
        _sword1 = GetNode<Node2D>("%Sword1");
        _sword1 = GetNode<Node2D>("%Sword2");
        _animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");
        
        GetNode<HitBox>("%HitBox1").SetIsPlayer(IsPlayer);
        GetNode<HitBox>("%HitBox2").SetIsPlayer(IsPlayer);
        
        Run();
    }

    private async void Run()
    {
        if (_isShooting) return;

        _isShooting = true;

        Tween tw = CreateTween();
        tw.TweenProperty(this, "rotation_degrees", Rotation == 0 ? 360 : 0, 0.5f);
        await ToSignal(tw, Tween.SignalName.Finished);
        
        _isShooting = false;
    }

    public override void Shoot()
    {
        Run();
    }

    public override void Destroy()
    {
    }

    public override void SetShootCd(float value)
    {
    }
}
