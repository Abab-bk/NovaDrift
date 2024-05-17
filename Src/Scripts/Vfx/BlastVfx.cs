using System;
using AcidWallStudio.Fmod;
using Godot;
using Godot.Collections;
using NovaDrift.Scripts;
using NovaDrift.Scripts.Prefabs.Components;

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
        
        Fmod.PlayOneShotById("event:/Blast");
    }
}
