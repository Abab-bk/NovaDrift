using Godot;
using NovaDrift.Scripts;

namespace AcidWallStudio.Fmod;

public static class FmodConfig
{
    public static readonly int MaxChannels = 32;
 
    public static readonly string[] BankPaths = new[]
    {
        "Assets/Audios/Banks/Master.strings.bank",
        "Assets/Audios/Banks/Master.bank",
        "Assets/Audios/Banks/SFX.bank",
        "Assets/Audios/Banks/Music.bank",
        "Assets/Audios/Banks/UI.bank",
    };
    public const string RootPath = "Assets/Audios/Banks/";

    public static Node2D Listener = Global.Player;
}