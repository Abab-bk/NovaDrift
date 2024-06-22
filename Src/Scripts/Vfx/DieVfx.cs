using Godot;

namespace NovaDrift.Scripts.Vfx;

public partial class DieVfx : GpuParticles2D
{
    public override void _Ready()
    {
        Finished += QueueFree;
        Emitting = true;
    }
}
