namespace NovaDrift.Scripts.Systems;

public class Body : IItemInfo
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath = "res://Assets/Textures/Bodies/Default.png";
    
    public float Health = 100;
    public float Acceleration = 1000f;
    public float Deceleration = 300f;
    public float RotationSpeed = 4.5f; // 越高越灵敏

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
    
    public Body SetAcceleration(float acceleration)
    {
        Acceleration = acceleration;
        return this;
    }
    
    public Body SetDeceleration(float deceleration)
    {
        Deceleration = deceleration;
        return this;
    }
    
    public Body SetRotationSpeed(float rotationSpeed)
    {
        RotationSpeed = rotationSpeed;
        return this;
    }

    public void Use()
    {
        Global.Player.Stats.SetBody(this);
    }
}