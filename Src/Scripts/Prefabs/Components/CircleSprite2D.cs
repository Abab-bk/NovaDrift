using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class CircleSprite2D : Sprite2D
{
    public void UpdateRadius(float radius)
    {
        Scale = new Vector2(radius / 100f, radius / 100f);
    }
}