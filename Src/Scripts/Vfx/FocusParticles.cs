using Godot;
using System;
using NovaDrift.Scripts.Systems.Pool;

namespace NovaDrift.Scripts.Vfx;

public partial class FocusParticles : Node2D
{
    [GetNode("GPUParticles2D")] private GpuParticles2D _gpuParticles2D;
    
    public event Action OnAnimationEnd;

    public bool OneShot
    {
        set => _gpuParticles2D.OneShot = value;
    }

    public override void _Ready()
    {
        _gpuParticles2D.Finished += () =>
        {
            OnAnimationEnd?.Invoke();
            Pool.FocusVfxPool.Release(this);
        };
    }

    public void Play()
    {
        _gpuParticles2D.Emitting = true;
    }
}
