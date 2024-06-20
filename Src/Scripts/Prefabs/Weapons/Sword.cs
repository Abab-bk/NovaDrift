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
    
    // Animation
    private Easing _waveEasing = Easing.OutCubic;
    
    private const float WaveDuration = 0.3f;
    private const float WaveOffsetTime = 0.2f;
    private readonly Vector2 _sword1Offset = new Vector2(-60f, -60f);
    private readonly Vector2 _sword2Offset = new Vector2(-60f, 60f);
    private readonly Vector2 _sword1StartPos = new Vector2(-140f, -120f);
    private readonly Vector2 _sword2StartPos = new Vector2(-140f, 120f);
    private readonly Vector2 _sword1EndPos = new Vector2(192f, 0f);
    private readonly Vector2 _sword2EndPos = new Vector2(192f, 0f);
    // 全是角度
    private const float Sword1FinalRotation = 180f;
    private const float Sword2FinalRotation = -180f;
    private const float Sword1StartRotation = 55f;
    private const float Sword2StartRotation = -55f;
    
    public override void Init()
    {
        _sword1 = GetNode<Node2D>("%Sword1");
        _sword2 = GetNode<Node2D>("%Sword2");

        GetNode<HitBox>("%HitBox1")
            .SetIsPlayer(IsPlayer)
            .CallDeferred("set_collision_mask_value", (int)Layer.MobBullet, true);
        GetNode<HitBox>("%HitBox2")
            .SetIsPlayer(IsPlayer)
            .CallDeferred("set_collision_mask_value", (int)Layer.MobBullet, true);
        
        GetNode<HitBox>("%HitBox1").OnHitSomething += HandleHit;
        GetNode<HitBox>("%HitBox2").OnHitSomething += HandleHit;
        
        Wave();
    }

    private void HandleHit(Node2D body)
    {
        if (body is not BulletBase bullet) return;
        bullet.Destroy();
    }

    private void MakeAnimation()
    {
        // 先舒展，然后挥舞，然后回来
        
        _waveAnimation = GTweenSequenceBuilder
            .New()
            
            .Append(_sword1.TweenPosition(_sword1StartPos + _sword1Offset, WaveOffsetTime))
                .Join(_sword2.TweenPosition(_sword2StartPos + _sword2Offset, WaveOffsetTime))
            
            .Append(_sword1.TweenPosition(_sword1EndPos, WaveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenPosition(_sword2EndPos, WaveDuration).SetEasing(_waveEasing))
                
                .Join(_sword1.TweenRotationDegrees(Sword1FinalRotation, WaveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenRotationDegrees(Sword2FinalRotation, WaveDuration).SetEasing(_waveEasing))
            
            .Append(_sword1.TweenPosition(_sword1StartPos, WaveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenPosition(_sword2StartPos, WaveDuration).SetEasing(_waveEasing))
                
                .Join(_sword1.TweenRotationDegrees(Sword1StartRotation, WaveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenRotationDegrees(Sword2StartRotation, WaveDuration).SetEasing(_waveEasing))
            
            .AppendCallback(() =>
            {
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
