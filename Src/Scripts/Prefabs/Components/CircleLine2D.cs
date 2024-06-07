using Godot;
using NovaDrift.addons.AcidUtilities;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class CircleLine2D : Line2D, ICollisionLine2D
{
    public float Radius
    {
        set => UpdateScale(value);
    }

    private const float DefaultRadius = 100f;
    private const int DefaultCuts = 128;
    
    public Area2D Area2D;
    
    public override void _Ready()
    {
        Area2D = new Area2D();
        AddChild(Area2D);
        GenerateCircle();
    }

    private void UpdateScale(float radius)
    {
        Scale = new Vector2(radius / DefaultRadius, radius / DefaultRadius);
    }

    private void GenerateCircle()
    {
        ClearPoints();
        var step = 2 * Mathf.Pi / DefaultCuts;
        for (int i = 0; i < DefaultCuts; i++)
        {
            var radian = step * i;
            var radianPos = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * DefaultRadius;
            AddPoint(radianPos);
        }
        
        ((ICollisionLine2D)this).GenerateCollision(this, Area2D);
    }
}