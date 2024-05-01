using System;
using Godot;
using Godot.Collections;
using NathanHoad;
using NovaDrift.Scripts;

public partial class Blast : Node2D
{
    public event Action OnBlastDone;
    private AnimationPlayer _animationPlayer;
    
    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _animationPlayer.AnimationFinished += name =>
        {
            OnBlastDone?.Invoke();
        };

        SoundManager.PlaySound(SoundPaths.Blast);
    }
}
