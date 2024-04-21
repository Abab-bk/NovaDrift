using Godot;
using KaimiraGames;

namespace AcidWallStudio.AcidUtilities;

public class Wizard
{
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

    // 用于得到子弹在圆弧上的位置
    public static Vector2 GetPosOnArcByIndex(int num, int currentIndex)
    {
        float startAngle = -Mathf.Pi / 2;
        float endAngle = Mathf.Pi / 2;
        float arcAngle = endAngle - startAngle;
        float t = (float)currentIndex / (num - 1);
        
        float angle = Mathf.Lerp(startAngle, endAngle, t * t);
        
        return new Vector2(Mathf.Cos(angle),  Mathf.Sin(angle));
    }
}