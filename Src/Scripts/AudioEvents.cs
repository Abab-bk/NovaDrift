using Godot;

namespace NovaDrift.Scripts;

public static class AudioParams
{
    public static readonly string Stage = "Stage";
}

public enum BackgroundMusicStage
{
    Stage1,
    Stage2,
    Stage3,
    BossBattle,
}