using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class Lightning : BaseVfx
{
    public Vector2 Size = Vector2.Zero;
    public float Life = 1.0f;
    
    public override void _Ready()
    {
        base._Ready();
        Scale = Size / 512f;
        
        Modulate = new Color("ffffff0c");
        GTweenSequenceBuilder.New()
            .Append(this.TweenModulate(Colors.White, 0.2f))
            .AppendTime(Life)
            .Append(this.TweenModulateAlpha(0f, 0.2f))
            .AppendCallback(() => { OnAnimationEnd?.Invoke(); })
            .Build()
            .Play();
    }
}
