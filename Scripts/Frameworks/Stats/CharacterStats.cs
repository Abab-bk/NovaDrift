using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Frameworks.Stats;

public class CharacterStats
{
    public readonly Stat Health = new Stat(100);
    public readonly Stat Speed = new Stat(100);
    
    public CharacterStats(float health, float speed)
    {
        Health = new Stat(health);
        Speed = new Stat(speed);
    }

    public CharacterStats()
    {
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
}