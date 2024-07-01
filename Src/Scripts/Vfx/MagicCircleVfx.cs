using System;
using Godot;
using Godot.Collections;
using GTweens.Builders;
using GTweens.Easings;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

[NoAutoGetNodes]
public partial class MagicCircleVfx : BaseVfx
{
    [GetNode("Part1")] private Sprite2D _part1;
    [GetNode("Part2")] private Sprite2D _part2;
    [GetNode("Part3")] private Sprite2D _part3;
    [GetNode("Area2D")] private Area2D _area;

    public float Radius = 470f;
    public float Duration = 0.5f;
    
    public event Action OnAppearEnd;
    public event Action OnDisappearEnd;

    public override void _Ready()
    {
        GetNodes();
        
        _area.SetIsPlayer(IsPlayer);
        
        Scale = new Vector2(Radius / 470f, Radius / 470f);
        
        _part1.Scale = Vector2.Zero;
        _part2.Scale = Vector2.Zero;
        _part3.Scale = Vector2.Zero;
    }

    public Array<Node2D> GetOverlayBodies()
    {
        return _area.GetOverlappingBodies();
    }

    public void Appear()
    {
        float InnerGetRotation(float degree)
        {
            return MathF.Max(180f, degree);
        }

        GTweenSequenceBuilder.New()
            .Append(_part1.TweenRotationDegrees(InnerGetRotation(_part1.RotationDegrees), 1.5f).SetLoops(100))
            .Join(_part2.TweenRotationDegrees(InnerGetRotation(_part2.RotationDegrees), 1f).SetLoops(100))
            .Join(_part3.TweenRotationDegrees(InnerGetRotation(_part3.RotationDegrees), 1f).SetLoops(100))
            .Build()
            .Play();
        
        GTweenSequenceBuilder.New()
            .Append(_part1.TweenScale(Vector2.One, 0.2f).SetEasing(Easing.InOutQuart))
            .Append(_part2.TweenScale(Vector2.One, 0.2f).SetEasing(Easing.InOutQuart))
            .Append(_part3.TweenScale(Vector2.One, 0.3f).SetEasing(Easing.InOutQuart))
            .AppendTime(Duration)
            .AppendCallback(() => { OnAppearEnd?.Invoke(); })
            .Build()
            .Play();
    }

    public void Flash(Color color, float duration = 0.5f, Action callback = null)
    {
        GTweenSequenceBuilder.New()
            .Append(this.TweenModulate(color, duration))
            .AppendTime(0.2f)
            .AppendCallback(() =>
            {
                if (callback == null) return;
                callback?.Invoke();
            })
            .Build()
            .Play();
        
        // this.TweenModulate(color, duration)
        //     .OnComplete(() => { 
        //         if (callback == null) return;
        //         callback?.Invoke();
        //     })
        //     .Play();
    }

    public void Disappear()
    {
        GTweenSequenceBuilder.New()
            .AppendTime(0.5f)
            .Append(this.TweenModulateAlpha(0f, 0.3f))
            .AppendCallback(() =>
            {
                OnDisappearEnd?.Invoke();
                QueueFree();
            })
            .Build()
            .Play();
    }
}
