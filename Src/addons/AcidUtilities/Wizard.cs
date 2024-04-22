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
}