using Godot;
using System;
using GTweens.Easings;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class SpawnVfx : Node2D
{
    public event Action OnAnimationEnd;
    
    [GetNode("Sprite")] private Sprite2D _sprite;

    public override void _Ready()
    {
        _sprite.Scale = new Vector2(0.5f, 0.5f);
        _sprite
            .TweenScale(new Vector2(0.7f, 0.7f), 0.5f)
            .OnComplete(() =>
            {
                OnAnimationEnd?.Invoke();
                QueueFree();
            })
            .SetEasing(Easing.OutCubic)
            .Play();
    }
}
