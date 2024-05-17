namespace AcidWallStudio.Fmod;

public static class FmodConfig
{
    public static readonly int MaxChannels = 10;
 
    public static readonly string[] BankPaths = new[]
    {
        "Assets/Audios/Banks/Master.strings.bank",
        "Assets/Audios/Banks/Master.bank",
        "Assets/Audios/Banks/SFX.bank",
        "Assets/Audios/Banks/Music.bank",
        "Assets/Audios/Banks/UI.bank",
    };
}