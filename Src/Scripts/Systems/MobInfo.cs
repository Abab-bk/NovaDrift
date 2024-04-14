namespace NovaDrift.Scripts.Systems;

public class MobInfo
{
    public string Name;
    public string IconPath;

    public MobInfo SetName(string name)
    {
        Name = name;
        return this;
    }

    public MobInfo SetIconPath(string iconName)
    {
        IconPath = $"res://Assets/Textures/Mobs/{iconName}.png";
        return this;
    }
}