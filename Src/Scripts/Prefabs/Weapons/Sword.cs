using System;
using Godot;
using GTweens.Builders;
using GTweens.Easings;
using GTweens.Tweens;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Sword : BaseShooter
{
    private Node2D _sword1;
    private Node2D _sword2;
    
    private bool _isShooting;

    private GTween _waveAnimation;
    private GTween _waveAnimation2;
    
    private bool _shouldWave2 = false;
    
    private const float WaveDuration = 0.5f;
    
    public override void Init()
    {
        _sword1 = GetNode<Node2D>("%Sword1");
        _sword2 = GetNode<Node2D>("%Sword2");
        
        GetNode<HitBox>("%HitBox1").SetIsPlayer(IsPlayer);
        GetNode<HitBox>("%HitBox2").SetIsPlayer(IsPlayer);
        
        // MakeAnimation();
        Wave();
    }

    private void MakeAnimation()
    {
        _waveAnimation = GTweenSequenceBuilder
            .New()
            // 到达中间
            .Append(_sword1.TweenPosition(new Vector2(192f, 0f), WaveDuration))
                .Join(_sword2.TweenPosition(new Vector2(192f, 0f), WaveDuration))
                
                .Join(_sword1.TweenRotationDegrees(180f, WaveDuration))
                .Join(_sword2.TweenRotationDegrees(-180f, WaveDuration))
            
            .Append(_sword1.TweenPosition(new Vector2(-140f, 120f), WaveDuration).SetEasing(Easing.InOutBack))
                .Join(_sword2.TweenPosition(new Vector2(-140f, -120f), WaveDuration).SetEasing(Easing.InOutBack))
            
                .Join(_sword1.TweenRotationDegrees(-55f, WaveDuration))
                .Join(_sword2.TweenRotationDegrees(55f, WaveDuration))
            
            .AppendCallback(() =>
            {
                _shouldWave2 = true;
                _isShooting = false;
            })
            .Build();
        
        _waveAnimation2 = GTweenSequenceBuilder
            .New()
            .Append(_sword2.TweenPosition(new Vector2(192f, 0f), WaveDuration))
                .Join(_sword1.TweenPosition(new Vector2(192f, 0f), WaveDuration))
            
                .Join(_sword1.TweenRotationDegrees(-180f, WaveDuration))
                .Join(_sword2.TweenRotationDegrees(180f, WaveDuration))
            
            .Append(_sword2.TweenPosition(new Vector2(-140f, 120f), WaveDuration).SetEasing(Easing.InOutBack))
                .Join(_sword1.TweenPosition(new Vector2(-140f, -120f), WaveDuration).SetEasing(Easing.InOutBack))
            
                .Join(_sword1.TweenRotationDegrees(55f, WaveDuration))
                .Join(_sword2.TweenRotationDegrees(-55f, WaveDuration))
            
            .AppendCallback(() =>
            {
                _shouldWave2 = false;
                _isShooting = false;
            })
            .Build();
    }

    private void Wave()
    {
        if (_isShooting) return;

        MakeAnimation();
        Logger.Log("[Weapon: Sword] Wave");
        _isShooting = true;

        if (_shouldWave2)
        {
            _waveAnimation2.Play();
            return;
        }
        _waveAnimation.Play();
    }

    public override void Shoot()
    {
        Wave();
    }

    public override void Destroy()
    {
    }

    public override void SetShootCd(float value)
    {
    }
}
