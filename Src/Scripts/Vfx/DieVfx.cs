using Godot;

namespace NovaDrift.Scripts.Vfx;

public partial class DieVfx : GpuParticles2D
{
    public void Emit()
    {
        Emitting = true;
    }
}
