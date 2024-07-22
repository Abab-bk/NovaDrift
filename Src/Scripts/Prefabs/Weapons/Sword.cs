using Godot;
using GTweens.Builders;
using GTweens.Easings;
using GTweens.Tweens;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.BulletPatterns;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Sword : BaseShooter
{
    private Node2D _sword1;
    private Node2D _sword2;
    
    private bool _isShooting;

    private GTween _waveAnimation;
    
    // Animation
    private Easing _waveEasing = Easing.OutCubic;
    
    private float _waveDuration = 0.3f;
    private float _waveOffsetTime = 0.2f;
    private readonly Vector2 _sword1Offset = new Vector2(-60f, -60f);
    private readonly Vector2 _sword2Offset = new Vector2(-60f, 60f);
    private readonly Vector2 _sword1StartPos = new Vector2(-140f, -150f);
    private readonly Vector2 _sword2StartPos = new Vector2(-140f, 150f);
    private readonly Vector2 _sword1EndPos = new Vector2(192f, 0f);
    private readonly Vector2 _sword2EndPos = new Vector2(192f, 0f);
    // 全是角度
    private const float Sword1FinalRotation = 180f;
    private const float Sword2FinalRotation = -180f;
    private const float Sword1StartRotation = 50f;
    private const float Sword2StartRotation = -50f;

    private HitBox _hitBox1;
    private HitBox _hitBox2;

    private readonly BulletPattern _pattern = new ShotGunPattern();
    
    public override void Init()
    {
        GetBulletFunc = _ => new BulletBuilder().
            SetOwner(Actor).
            SetIsPlayer(IsPlayer).
            SetDamage(Actor.Stats.Damage.Value * 0.5f).
            SetSpeed(Actor.Stats.BulletSpeed.Value).
            SetSize(Actor.Stats.BulletSize.Value).
            SetDegeneration(Actor.Stats.BulletDegeneration.Value).
            SetSteering(Actor.Stats.Targeting.Value).
            Build();
        
        _sword1 = GetNode<Node2D>("%Sword1");
        _sword2 = GetNode<Node2D>("%Sword2");
        _hitBox1 = GetNode<HitBox>("%HitBox1");
        _hitBox2 = GetNode<HitBox>("%HitBox2");

        _hitBox1.SetIsPlayer(IsPlayer);
        _hitBox1.SetIsPlayer(IsPlayer);
        Logger.Log("[Weapon] Init Sword");

        EventBus.OnMobDied += _ =>
        {
            ShootWithConfig(_pattern, (int)Actor.Stats.BulletCount.Value);
        };
        
        SetModifier();
        
        Wave();
    }

    private void SetModifier()
    {
        var damage = Actor.Stats.Damage.Value;

        _hitBox1.Damage = damage;
        _hitBox2.Damage = damage;

        // 超过 100% 的修正 +伤害 而非速度
        if (Actor.Stats.ShootSpeed.Value >= 0.25f)
        {
            _waveDuration = 0.25f;
            var damageModifier = (Actor.Stats.ShootSpeed.Value - 0.25f) / 0.75f;
            _hitBox1.Damage = damage * damageModifier;
            _hitBox2.Damage = damage * damageModifier;
            return;
        }

        _waveDuration = 0.15f + Actor.Stats.ShootSpeed.Value;
    }

    private void MakeAnimation()
    {
        // 先舒展，然后挥舞，然后回来
        
        _waveAnimation = GTweenSequenceBuilder
            .New()
            
            .Append(_sword1.TweenPosition(_sword1StartPos + _sword1Offset, _waveOffsetTime))
                .Join(_sword2.TweenPosition(_sword2StartPos + _sword2Offset, _waveOffsetTime))
            
            .Append(_sword1.TweenPosition(_sword1EndPos, _waveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenPosition(_sword2EndPos, _waveDuration).SetEasing(_waveEasing))
                
                .Join(_sword1.TweenRotationDegrees(Sword1FinalRotation, _waveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenRotationDegrees(Sword2FinalRotation, _waveDuration).SetEasing(_waveEasing))
            
            .Append(_sword1.TweenPosition(_sword1StartPos, _waveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenPosition(_sword2StartPos, _waveDuration).SetEasing(_waveEasing))
                
                .Join(_sword1.TweenRotationDegrees(Sword1StartRotation, _waveDuration).SetEasing(_waveEasing))
                .Join(_sword2.TweenRotationDegrees(Sword2StartRotation, _waveDuration).SetEasing(_waveEasing))
            
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
        SetModifier();
    }
}
