using Godot;

namespace NovaDrift.Scripts;

public static class SoundPaths
{
    public const string ZeroGravity = "res://Assets/Audios/Musics/ZeroGravity.ogg";
    public static readonly AudioStream Ping = GD.Load<AudioStream>("res://Assets/Audios/SoundEffects/Pings/Ping1.ogg");
    public static readonly AudioStream Blast = GD.Load<AudioStream>("res://Assets/Audios/SoundEffects/Blast.ogg");
    public static readonly AudioStream BulletHit = GD.Load<AudioStream>("res://Assets/Audios/SoundEffects/BulletHit.ogg");
}