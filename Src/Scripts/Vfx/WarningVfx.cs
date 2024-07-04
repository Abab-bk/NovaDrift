using Godot;
using System;

namespace NovaDrift.Scripts.Vfx;

public partial class WarningVfx : Node2D
{
    public event Action OnAnimationEnd;
    public float WarningTime;
    
    [GetNode("Timer")] private Timer _timer;
    
    public override void _Ready()
    {
        _timer.WaitTime = WarningTime;
        _timer.Timeout += () =>
        {
            OnAnimationEnd?.Invoke();
            QueueFree();
        };
        _timer.Start();
    }
}
