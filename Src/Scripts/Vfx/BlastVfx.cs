using System;
using AcidWallStudio.Fmod;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Vfx;

public partial class BlastVfx : Node2D
{
    public event Action OnBlastDone;
    private CircleSprite2D _circleSprite2D;
    private AnimationPlayer _animationPlayer;
    
    public void SetBlastRadius(float value)
    {
        _circleSprite2D.UpdateRadius(value);
    }
    
    public override void _Ready()
    {
        _circleSprite2D = GetNode<CircleSprite2D>("%CircleSprite2D");
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _animationPlayer.AnimationFinished += name =>
        {
            OnBlastDone?.Invoke();
        };
        
        SoundManager.PlayOneShotById("event:/Blast");
    }
}
