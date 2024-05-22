using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class CircleBlast : BaseVfx
{
    public override void _Ready()
    {
        base._Ready();
        Scale = Vector2.Zero;
        GTweenSequenceBuilder.New()
            .Join(this.TweenScale(Vector2.One, 0.5f))
            .Append(this.TweenModulate(new Color("ffffff00"), 0.5f))
            .AppendCallback(() => { OnAnimationEnd?.Invoke(); })
            .Build()
            .Play();
    }
}
