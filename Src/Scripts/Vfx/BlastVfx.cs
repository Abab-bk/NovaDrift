using System;
using AcidWallStudio.Fmod;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Vfx;

public partial class BlastVfx : Node2D
{
    public event Action OnBlastDone;
    
    [GetNode("GPUParticles2D")] private GpuParticles2D _gpuParticles;
    
    private CircleSprite2D _circleSprite2D;

    public bool PlaySound = true;
    
    public void SetBlastRadius(float value)
    {
        _circleSprite2D.UpdateRadius(value);
    }
    
    public override void _Ready()
    {
        _circleSprite2D = GetNode<CircleSprite2D>("%CircleSprite2D");

        _gpuParticles.Finished += () =>
        {
            OnBlastDone?.Invoke();
        };
        
        _gpuParticles.Restart();
        
        if (PlaySound) SoundManager.PlayOneShotById("event:/Blast");
    }
}
