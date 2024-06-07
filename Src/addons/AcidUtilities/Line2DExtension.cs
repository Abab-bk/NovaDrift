using Godot;

namespace NovaDrift.addons.AcidUtilities;

public interface ICollisionLine2D
{ 
    void GenerateCollision(Line2D line2D, Area2D area2D)
    {
        if (area2D == null) return;
        for (int i = 0; i < line2D.GetPoints().Length - 1; i++)
        {
            var newShape = new CollisionShape2D();
            
            area2D.AddChild(newShape);
            var currentPos = line2D.GetPointPosition(i);
            var nextPos = line2D.GetPointPosition(i + 1);
            
            newShape.Position = (currentPos + nextPos) / 2f;
            newShape.Rotation = currentPos.DirectionTo(nextPos).Angle();
            var distance = currentPos.DistanceTo(nextPos);
            
            newShape.Shape = new RectangleShape2D()
            {
                Size = new Vector2(distance, line2D.Width)
            };
        }
    }
}

public static class Line2DExtension
{

}