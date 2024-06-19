using Godot;
using System;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class SacredSword : Node2D
{
    [Export] private Sprite2D _circle1;
    [Export] private Sprite2D _circle2;
    [Export] private Sprite2D _circle3;
    [Export] private Sprite2D _sword;
    
    public override void _Ready()
    {
        _circle1.Modulate = _circle1.Modulate with { A = 0.2f };
        _circle2.Modulate = _circle2.Modulate with { A = 0.2f };
        _circle3.Modulate = _circle3.Modulate with { A = 0f };
        
        _circle2.Hide();
        _circle3.Hide();
        _sword.Hide();

        _circle3.Scale = new Vector2(0.3f, 0.3f);

        _sword.GlobalPosition = _sword.GlobalPosition with { Y = -500f };
        
        // 扩散动画
        var circle3Animation = GTweenSequenceBuilder.New()
            .Append(_circle3.TweenModulateAlpha(1f, 1f)
                .OnComplete(() =>
                {
                    _circle3.Modulate = _circle3.Modulate with { A = 0f };
                }))
            .Join(_circle3.TweenScale(new Vector2(0.7f, 0.7f), 1f)
                .OnComplete(() =>
                {
                    _circle3.Scale = new Vector2(0.3f, 0.3f);
                }))
            .Build();
        
        // 剑动画
        var swordAnimation = GTweenSequenceBuilder.New()
            .Append(_sword.TweenPositionY(-90f, 0.5f))
            .AppendTime(0.5f)
            .AppendCallback(() =>
            {
                _circle3.Show();
                circle3Animation.Play();
            })
            .Build();
        
        // 大圈动画
        var circleAnimation = GTweenSequenceBuilder.New()
            .Append(_circle2.TweenScale(new Vector2(0.6f ,0.6f), 0.2f))
                .Join(_circle2.TweenModulateAlpha(1f, 0.5f))
            .AppendTime(1f)
            .AppendCallback(() =>
            {
                _circle1.TweenModulateAlpha(0f, 0.5f).Play();
                _circle2.TweenModulateAlpha(0f, 0.5f).Play();
                _sword.Show();
                swordAnimation.Play();
            })
            .Build();
        
        // 小圈动画
        GTweenSequenceBuilder.New()
            .Append(_circle1.TweenScale(new Vector2(0.2f, 0.2f), 0.4f))
            .AppendTime(0.1f)
            .Append(_circle1.TweenModulateAlpha(0.8f, 0.5f))
            .Append(GTweenSequenceBuilder.New()
                .Append(_circle1.TweenModulateAlpha(1f, 0.2f))
                .AppendTime(0.2f)
                .Append(_circle1.TweenModulateAlpha(0.8f, 0.2f))
                .Build()
            )
            .AppendCallback(() =>
            {
                _circle2.Show();
                circleAnimation.Play();
            })
            .Build()
            .Play();
        
        // 旋转动画
        _circle1
            .TweenRotationDegrees(GetRotation(_circle1.RotationDegrees), 4f)
            .SetLoops(100)
            .Play();
        _circle3
            .TweenRotationDegrees(GetRotation(_circle1.RotationDegrees), 4f)
            .SetLoops(100)
            .Play();
        _circle2
            .TweenRotationDegrees(GetRotation(_circle1.RotationDegrees), 4f)
            .SetLoops(100)
            .Play();
    }
    
    private float GetRotation(float degree)
    {
        return MathF.Max(180f, degree);
    }
}
