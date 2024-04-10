using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Frameworks.Stats;

public class CharacterStats
{
    public readonly Attribute Health = new Attribute(0, 100);
    public readonly Stat Speed = new Stat(100);
    public readonly Stat Damage = new Stat(30);
    public readonly Attribute Exp = new Attribute(0, 100);
    
    public CharacterStats SetExp(float value)
    {
        Exp.BaseValue = value;
        return this;
    }

    public CharacterStats SetHealth(float value)
    {
        Health.BaseValue = value;
        return this;
    }

    public CharacterStats SetSpeed(float value)
    {
        Speed.BaseValue = value;
        return this;
    }

    public CharacterStats SetDamage(float value)
    {
        Damage.BaseValue = value;
        return this;
    }
    
    
    public CharacterStats(float health, float speed)
    {
        Health = new Attribute(0, health);
        Speed = new Stat(speed);
    }
    
    public CharacterStats()
    {
    }
}