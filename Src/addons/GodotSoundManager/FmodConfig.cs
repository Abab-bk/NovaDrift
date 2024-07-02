using Godot;
using NovaDrift.Scripts;

namespace AcidWallStudio.Fmod;

public static class FmodConfig
{
    public static readonly int MaxChannels = 32;
 
    public static readonly string[] BankPaths = new[]
    {
        "res://Assets/Audios/Desktop/Master.strings.bank",
        "res://Assets/Audios/Desktop/Master.bank",
        "res://Assets/Audios/Desktop/SFX.bank",
        "res://Assets/Audios/Desktop/Music.bank",
        "res://Assets/Audios/Desktop/UI.bank",
    };
    public const string RootPath = "res://Assets/Audios/Desktop/";

    public static Node2D Listener = Global.Player;

    // public static void GenerateBankPaths()
    // {
    //     var banksDir = DirAccess.Open(RootPath);
    //     
    // }
}