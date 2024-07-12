using Godot;
using System;

namespace NovaDrift.Scripts.Vfx;

public partial class FocusParticles : Node2D
{
    [GetNode("GPUParticles2D")] private GpuParticles2D _gpuParticles2D;
    
    public event Action OnAnimationEnd;
    
    public bool OneShot;

    public override void _Ready()
    {
        _gpuParticles2D.OneShot = OneShot;
        _gpuParticles2D.Finished += () =>
        {
            OnAnimationEnd?.Invoke();
            QueueFree();
        };
        _gpuParticles2D.Restart();
    }
}
