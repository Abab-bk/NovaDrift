using Godot;

namespace NovaDrift.Scripts;

[GlobalClass]
public partial class TracyNode : Node
{
    public override void _Ready()
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        // var zone = TracyProfiler.ZoneBegin("TracyNode physical process begin");
        // TracyProfiler.ZoneEnd(zone);
    }
}