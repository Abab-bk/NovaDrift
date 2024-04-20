namespace NovaDrift.Scripts.Systems;

public class MobInfo
{
    public string Name;
    public string IconPath;
    public float Health;
    public float Speed;
    public float Damage;
    public float ShootCd;
    
    public MobInfo SetShootCd(float value)
    {
        ShootCd = value;
        return this;
    }

    public MobInfo SetHealth(float value)
    {
        Health = value;
        return this;
    }
    
    public MobInfo SetSpeed(float value)
    {
        Speed = value;
        return this;
    }
    
    public MobInfo SetDamage(float value)
    {
        Damage = value;
        return this;
    }
    
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