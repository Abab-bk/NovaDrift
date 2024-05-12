using Godot;

namespace NovaDrift.Scripts.Systems;

public static class VfxFactory
{
    public static Node2D GetALightBall() { return GD.Load<PackedScene>("res://Scenes/Vfx/LightBall.tscn").Instantiate<Node2D>(); }
    public static BlastVfx GetBlast() { return GD.Load<PackedScene>("res://Scenes/Vfx/Blast.tscn").Instantiate<BlastVfx>(); }
}