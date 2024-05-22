using System;
using Godot;

namespace NovaDrift.Scripts.Vfx;

public abstract partial class BaseVfx : Node2D
{
    public Action OnAnimationEnd;

    public override void _Ready()
    {
        OnAnimationEnd += QueueFree;
    }
}