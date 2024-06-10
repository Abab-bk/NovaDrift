using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("R"))
        {
            var node = GD.Load<PackedScene>("res://Scenes/Vfx/IncineratorBeam.tscn").Instantiate() as IncineratorBeam;
            if (node == null) return;
            node.GlobalPosition = Wizard.GetScreenCenter();
            AddChild(node);
        }
    }
}

