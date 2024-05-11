using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class CircleSprite2D : Sprite2D
{
    [Export] public float Radius = 100f;
    public void UpdateRadius(float radius)
    {
        Scale = new Vector2(radius / Radius, radius / Radius);
    }
}