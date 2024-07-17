using Godot;

namespace NovaDrift.Scripts;

public static class AudioEvents
{
    public static string ButtonClicked = "event:/ButtonClicked";
    public static string BackgroundMusic = "event:/BackgroundMusic";
}

public static class AudioParams
{
    public static string Stage = "Stage";
}

public enum BackgroundMusicStage
{
    Stage1,
    Stage2,
    Stage3,
    BossBattle,
}