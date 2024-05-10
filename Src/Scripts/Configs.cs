using KaimiraGames;

namespace NovaDrift.Scripts;

public class AbilityGenerateConfig
{
    public enum ItemType
    {
        Ability,
        Weapon,
        Body,
        Shield,
    }
    
    public int Count = 3;

    public WeightedList<ItemType> ItemTypes = new()
    {
        {ItemType.Ability, 1},
        {ItemType.Weapon, 1},
        {ItemType.Body, 1},
        {ItemType.Shield, 1},
    };
    
    public AbilityGenerateConfig(int count)
    {
        Count = count;
    }
}