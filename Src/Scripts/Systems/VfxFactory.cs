using Godot;

namespace NovaDrift.Scripts.Systems;

public class VfxFactory
{
    public Node2D GetALightBall() { return GD.Load<Node2D>("res://Scenes/Vfx/LightBall.tscn"); }
}