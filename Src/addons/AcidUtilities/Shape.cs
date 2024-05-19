using System;
using System.Collections.Generic;
using Godot;

namespace NovaDrift.addons.AcidUtilities;

public enum ShapeType
{
    Circle,
    Rectangle,
    Triangle,
}

public interface IShape
{
    public List<Vector2> Points { set; get; }

    public Vector2 GetPosByIndex(int pointIndex)
    {
        return Points[pointIndex];
    }

    public static IShape GetShapeInstanceByType(ShapeType shapeType, int pointCount, float width, float height)
    {
        switch (shapeType)
        {
            case ShapeType.Circle:
                return new CircleShape(pointCount, width);
            case ShapeType.Rectangle:
                return new RectangleShape(pointCount, width, height);
            case ShapeType.Triangle:
                return new TriangleShape(pointCount, width, height);
            default:
                throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, null);
        }
    }
}

public class CircleShape : IShape
{
    public List<Vector2> Points { set; get; }

    public CircleShape(int pointCount, float radius)
    {
        Points = new List<Vector2>();
        
        double goldenRatio = (1 + Math.Sqrt(5)) / 2; // 黄金比例
        double angleIncrement = 2 * Math.PI / (goldenRatio * goldenRatio); // 角度增量
        
        for (int i = 0; i < pointCount; i++)
        {
            double angle = i * angleIncrement;
            double x = radius * Math.Cos(angle);
            double y = radius * Math.Sin(angle);
            Points.Add(new Vector2((float)x, (float)y));
        }
    }

    public Vector2 GetPosByIndex(int index)
    {
        return Points[index];
    }
}

// 矩形
public class RectangleShape : IShape
{
    public List<Vector2> Points { set; get; }

    public RectangleShape(int pointCount, float width, float height)
    {
        Points = new List<Vector2>();

        for (int i = 0; i < pointCount; i++)
        {
            float x = width / 2 * (float)Math.Cos(2 * Math.PI * i / pointCount);
            float y = height / 2 * (float)Math.Sin(2 * Math.PI * i / pointCount);
            Points.Add(new Vector2(x, y));
        }
    }

    public Vector2 GetPosByIndex(int index)
    {
        return Points[index];
    }
}

// 三角形
public class TriangleShape : IShape
{
    public List<Vector2> Points { set; get; }

    public TriangleShape(int pointCount, float width, float height)
    {
        Points = new List<Vector2>();

        for (int i = 0; i < pointCount; i++)
        {
            float x = width / 2 * (float)Math.Cos(2 * Math.PI * i / pointCount);
            float y = height / 2 * (float)Math.Sin(2 * Math.PI * i / pointCount);
            Points.Add(new Vector2(x, y));
        }
    }

    public Vector2 GetPosByIndex(int index)
    {
        return Points[index];
    }
}

// 双螺旋型
public class SpiralShape : IShape
{
    public List<Vector2> Points { set; get; }

    public SpiralShape(int pointCount, float width, float height)
    {
        Points = new List<Vector2>();

        for (int i = 0; i < pointCount; i++)
        {
            float x = width / 2 * (float)Math.Cos(2 * Math.PI * i / pointCount);
            float y = height / 2 * (float)Math.Sin(2 * Math.PI * i / pointCount);
            Points.Add(new Vector2(x, y));
        }
    }

    public Vector2 GetPosByIndex(int index)
    {
        return Points[index];
    }
}
