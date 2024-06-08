using System;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class CircleBlast : BaseVfx
{
    public event Action<Node2D> OnSomeThingHit;
    public float Radius;
    private Area2D _area2D;

    public void SetRadius(float value)
    {
        Scale = new Vector2(value / 256f, value / 256f);
    }

    public override void _Ready()
    {
        base._Ready();
        
        SetRadius(Radius);

        _area2D = GetNode<Area2D>("Area2D");
        _area2D.BodyEntered += body => OnSomeThingHit?.Invoke(body);
        _area2D.SetIsPlayer(IsPlayer);
        
        Scale = Vector2.Zero;
        GTweenSequenceBuilder.New()
            .Join(this.TweenScale(Scale + new Vector2(3, 3), 0.2f))
            .Append(this.TweenModulate(new Color("ffffff00"), 0.5f))
            .AppendCallback(() => { OnAnimationEnd?.Invoke(); })
            .Build()
            .Play();
    }
}
