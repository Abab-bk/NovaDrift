using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class ChargeBall : BaseVfx
{
    public float Duration = 1f;
    
    public override void _Ready()
    {
        base._Ready();

        Scale = Vector2.Zero;
        
        GTweenSequenceBuilder.New()
            .Append(this.TweenScale(Vector2.One, 0.5f))
            .AppendTime(Duration)
            .Append(this.TweenScale(Vector2.Zero, 0.5f))
            .AppendCallback(() =>
            {
                OnAnimationEnd?.Invoke();
            })
            .Build()
            .Play();
    }
}
