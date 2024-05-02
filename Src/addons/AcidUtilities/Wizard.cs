using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using KaimiraGames;

namespace AcidWallStudio.AcidUtilities;

public static class Wizard
{
    const float MapPadding = 100f;
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
    
    public static bool FileExists(string path)
    {
        return FileAccess.FileExists(path);
    }
    
    public static string ReadAllText(string path)
    {
        return FileAccess.Open(path, FileAccess.ModeFlags.Read).GetAsText();
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

    public static float FloatRange(this Random random, float min = 0.0f, float max = 1.0f) {
        return (float) (random.NextDouble() * (max - min) + min);
    }

    public static Vector2 GetClosestMapCorner(Vector2 pos)
    {
        float minDistance = float.MaxValue;
        Vector2 result = Vector2.Zero;

        foreach (Vector2 corner in MapCorners)
        {
            var distance = pos.DistanceTo(corner);
            if (distance > minDistance) break;
            minDistance = distance;
            result = corner;
        }
        
        return result;
    }

    public static Vector2 GetMapCornerByIndex(int index)
    {
        return MapCorners[Mathf.Min(index, MapCorners.Length - 1)];
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

    public static T GetRandomEnum<T>(this Random random)
        where T : struct, Enum
    {
        var values = Enum.GetValues<T>();

        return values[random.Next(values.Length)];
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
}