using Godot;

namespace AcidWallStudio.AcidUtilities;

public class Wizard
{
    public static string ReadAllText(string path)
    {
        return FileAccess.Open(path, FileAccess.ModeFlags.Read).GetAsText();
    }
}