using System;
using Godot;
using KaimiraGames;

namespace AcidWallStudio.AcidUtilities;

public static class Wizard
{
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
    
    public static float FloatRange(this Random random, float min = 0.0f, float max = 1.0f) {
        return (float) (random.NextDouble() * (max - min) + min);
    }
}