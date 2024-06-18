using Godot;

namespace NovaDrift.Scripts.Prefabs.Actors.Mobs;

public partial class CloneMob : MobBase
{
    public string IconPath;

    public override void _Ready()
    {
        base._Ready();
        Sprite.Texture = GD.Load<Texture2D>(IconPath);
    }
}
