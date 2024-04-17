using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems;

public class Body : IItemInfo
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath = "res://Assets/Textures/Bodies/Default.png";
    
    
    // TODO: 护盾
    
    public float Health = 100;
    public Stat Acceleration = new Stat(1000f);
    public Stat Deceleration = new Stat(300f);
    public Stat RotationSpeed = new Stat(4.5f); // 越高越灵敏
    public Stat ShootingDeceleration = new Stat(500f);
    
    public Body SetName(string name)
    {
        Name = name;
        return this;
    }
    
    public Body SetDesc(string desc)
    {
        Desc = desc;
        return this;
    }
    
    public Body SetIconPath(string iconName)
    {
        IconPath = $"res://Assets/Textures/Bodies/{iconName}.png";
        return this;
    }

    public Body SetHealth(float health)
    {
        Health = health;
        return this;
    }
    
    public Body SetShootingDeceleration(float shootingDeceleration)
    {
        ShootingDeceleration.BaseValue = shootingDeceleration;
        return this;
    }
    
    public Body SetAcceleration(float acceleration)
    {
        Acceleration.BaseValue = acceleration;
        return this;
    }
    
    public Body SetDeceleration(float deceleration)
    {
        Deceleration.BaseValue = deceleration;
        return this;
    }
    
    public Body SetRotationSpeed(float rotationSpeed)
    {
        RotationSpeed.BaseValue = rotationSpeed;
        return this;
    }

    public void Use()
    {
        Global.Player.Stats.SetBody(this);
    }
}