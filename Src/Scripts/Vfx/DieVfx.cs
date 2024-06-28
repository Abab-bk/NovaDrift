using Godot;

namespace NovaDrift.Scripts.Vfx;

public partial class DieVfx : GpuParticles2D
{
    public override void _Ready()
    {
        // Global.OnGamePaused += () =>
        // {
        //     Logger.Log("[DieVfx] Paused");
        //     SpeedScale = 0;
        //     Interpolate = false;
        // };
        //
        // Global.OnGameResumed += () =>
        // {
        //     SpeedScale = 1;
        //     Interpolate = true;
        // };
        
        Finished += QueueFree;
        Emitting = true;
    }
}
