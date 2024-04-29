using Godot;

namespace NovaDrift.Scripts.Systems;

public static class VfxFactory
{
    public static Node2D GetALightBall() { return GD.Load<PackedScene>("res://Scenes/Vfx/LightBall.tscn").Instantiate<Node2D>(); }
    public static Blast GetBlast() { return GD.Load<PackedScene>("res://Scenes/Vfx/Blast.tscn").Instantiate<Blast>(); }
}