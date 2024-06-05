using Godot;
using System;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class DamageAreaIndicator : BaseVfx
{
    [GetNode("%Line2D")] private Line2D _line;
    
    public float PreparationTime = 0.5f;
    public float Width = 10f;

    public override void _Ready()
    {
        _line.Modulate = new Color("ffffff00");
        _line.Width = Width;
        GTweenSequenceBuilder.New()
            .Append(_line.TweenModulateAlpha(0.5f, PreparationTime))
            .AppendCallback(() =>
            {
                OnAnimationEnd?.Invoke();
                QueueFree();
            })
            .Build()
            .Play();
    }
}
