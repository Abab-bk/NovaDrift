using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using KaimiraGames;
using Array = Godot.Collections.Array;

namespace AcidWallStudio.AcidUtilities;

public static class Wizard
{
    const float MapPadding = 100f;
    
    public static List<Vector2> EightDirs = new List<Vector2>();
    private static readonly Vector2[] MapCorners = new []
    {
        // 右下
        new Vector2((float)ProjectSettings.GetSetting("display/window/size/viewport_width") - MapPadding, (float)ProjectSettings.GetSetting("display/window/size/viewport_height") - MapPadding),
        // 左下
        new Vector2(MapPadding, (float)ProjectSettings.GetSetting("display/window/size/viewport_height") - MapPadding),
        // 左上
        new Vector2(MapPadding, MapPadding),
        // 右上
        new Vector2((float)ProjectSettings.GetSetting("display/window/size/viewport_width") - MapPadding, MapPadding)
    };

    static Wizard()
    {
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45; // 计算每个方向的角度（0, 45, 90, ...）
            Vector2 direction = Vector2.Right.Rotated(Mathf.DegToRad(angle)); // 使用向量旋转计算方向
            EightDirs.Add(direction);
        }
    }

    public static bool FileExists(string path)
    {
        // return FileAccess.FileExists(path);
        return ResourceLoader.Exists(path);
    }
    
    public static string ReadAllText(string path)
    {
        return FileAccess.Open(path, FileAccess.ModeFlags.Read).GetAsText();
    }

    public static Vector2 GetRandom8Dir()
    {
        return EightDirs.PickRandom();
    }
    
    public static Vector2 Bezier(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        var q0 = p0.Lerp(p1, t);
        var q1 = p1.Lerp(p2, t);
        var r = q0.Lerp(q1, t);
        return r;
    }


    public static string GetRandomTexturePath(string path)
    {
        List<string> list = new List<string>();

        var dir = DirAccess.Open(path);

        dir.ListDirBegin();
        var fileName = dir.GetNext();

        while (fileName != "")
        {
            if (fileName.EndsWith(".png") || fileName.EndsWith(".tres"))
            {
                list.Add(fileName);
            }
            fileName = dir.GetNext();
        }

        return path + list.PickRandom();
    }

    public static bool ChanceOverThreshold(int chance)
    {
        WeightedList<bool> list = new WeightedList<bool>();
        list.Add(true, chance);
        list.Add(false, 100 - chance);
        return list.Next();
    }

    public static Timer CreateTimer(float time)
    {
        Timer timer = new Timer();
        timer.WaitTime = time;
        return timer;
    }

    public static float GetTriangularSample(float max, float min, float mode)
    {
        float u = (float)Random.Shared.NextDouble();
        float f = (mode - min) / (max - min);

        if (u <= f)
            return min + (float)Math.Sqrt(u * (max - min) * (mode - min));
        
        return max - (float)Math.Sqrt((1 - u) * (max - min) * (max - mode));
    }

    public static Vector2 ReverseVectorX(Vector2 vector)
    {
        return new Vector2(-vector.X, vector.Y);
    }
    
    public static Vector2 ReverseVectorY(Vector2 vector)
    {
        return new Vector2(vector.X, -vector.Y);
    }

    public static Vector2 ReverseVector(Vector2 vector)
    {
        return new Vector2(-vector.X, -vector.Y);
    }
    
    public static Vector2 Reverse(this Vector2 vector)
    {
        return new Vector2(-vector.X, -vector.Y);
    }

    public static float FloatRange(this Random random, float min = 0.0f, float max = 1.0f) {
        return (float) (random.NextDouble() * (max - min) + min);
    }

    public static Vector2 GetClosestMapCorner(Vector2 pos)
    {
        var minDistance = float.MaxValue;
        var result = Vector2.Zero;

        foreach (var corner in MapCorners)
        {
            var distance = pos.DistanceTo(corner);
            if (distance > minDistance) break;
            minDistance = distance;
            result = corner;
        }
        
        return result;
    }

    public static Vector2 GetClosestMapCornerExcept(Vector2 pos, Vector2 except)
    {
        var minDistance = float.MaxValue;
        var result = Vector2.Zero;

        foreach (var corner in MapCorners)
        {
            if (corner == except) continue;
            var distance = pos.DistanceTo(corner);
            if (distance > minDistance) break;
            minDistance = distance;
            result = corner;
        }
        
        return result;
    }

    public static Vector2 GetRandomMapCorner()
    {
        return MapCorners[Random.Shared.NextInt64(0, MapCorners.Length)];
    }

    public static Vector2 GetMapCornerByIndex(int index)
    {
        return MapCorners[Mathf.Min(index, MapCorners.Length - 1)];
    }

    public static float GetScreenCenterX()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2;
    }
    
    public static float GetScreenCenterY()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_height") / 2;
    }

    public static Vector2 GetScreenCenter()
    {
        return new Vector2(
            (float)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2,
            (float)ProjectSettings.GetSetting("display/window/size/viewport_height") / 2
            );
    }

    public static Vector2 GetRandomScreenPosition()
    {
        return new Vector2(
            Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_width")),
            Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_height"))
        );
    }

    public static float GetRandomScreenX()
    {
        return Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_width"));
    }
    
    public static float GetRandomScreenY()
    {
        return Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_height"));
    }

    public static float GetMaxScreenX()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_width");
    }
    
    public static float GetMaxScreenY()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_height");
    }

    public static T GetRandomEnum<T>(this Random random)
        where T : struct, Enum
    {
        var values = Enum.GetValues<T>();

        return values[random.Next(values.Length)];
    }

    public static Vector2 GetForwardVector2(this Node2D source, float step)
    {
        return source.GlobalPosition + Vector2.Right.Rotated(source.Rotation) * step;
    }

    public static T PickRandom<T>(this IEnumerable<T> source)
    {
        return source.PickRandom(1).Single();
    }

    public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
    {
        return source.Shuffle().Take(count);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(x => Guid.NewGuid());
    }

    public static Node2D GetClosestTarget(Node2D node, string groupName)
    {
        List<Node2D> targets = new List<Node2D>();

        foreach (var targetNode in node.GetTree().GetNodesInGroup(groupName))
        {
            if (targetNode is Node2D target) targets.Add(target);
        }
        
        if (targets.Count <= 0) return null;
        
        return targets.
            OrderBy(orderNode => orderNode.GlobalPosition.DistanceTo(orderNode.GlobalPosition)).First();
    }
}