using System;
using AcidWallStudio.Fmod;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems.Pool;

namespace NovaDrift.Scripts.Vfx;

public partial class BlastVfx : Node2D
{
    public event Action OnBlastDone;
    
    [GetNode("GPUParticles2D")] private GpuParticles2D _gpuParticles;

    public bool PlaySound = true;
    
    public float Radius = 100f;
    
    public void SetBlastRadius(float value)
    {
        Radius = value;
        Scale = new Vector2(Radius / 100f, Radius / 100f);
    }
    
    public override void _Ready()
    {
        _gpuParticles.OneShot = true;
        _gpuParticles.Finished += () =>
        {
            OnBlastDone?.Invoke();
            Pool.BlastVfxPool.Release(this);
        };
    }

    public void Play()
    {
        _gpuParticles.Emitting = true;
        if (PlaySound) SoundManager.PlayOneShotById("event:/Blast");
    }
}
