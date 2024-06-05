using Godot;
using NovaDrift.Scripts;

namespace AcidWallStudio.Fmod;

public static class FmodConfig
{
    public static readonly int MaxChannels = 32;
 
    public static readonly string[] BankPaths = new[]
    {
        "Assets/Audios/Desktop/Master.strings.bank",
        "Assets/Audios/Desktop/Master.bank",
        "Assets/Audios/Desktop/SFX.bank",
        "Assets/Audios/Desktop/Music.bank",
        "Assets/Audios/Desktop/UI.bank",
    };
    public const string RootPath = "Assets/Audios/Desktop/";

    public static Node2D Listener = Global.Player;
}