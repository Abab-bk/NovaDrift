using AcidWallStudio.ObjectPool;
using Godot;
using NovaDrift.Scripts.Systems.Pool;

namespace NovaDrift.Scripts.Vfx;

public partial class DieVfx : GpuParticles2D
{
    public void Emit()
    {
        Finished += () => Pool.DieVfxPool.Release(this);
        Emitting = true;
    }
}
