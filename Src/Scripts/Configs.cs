using System;
using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
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

    public readonly WeightedList<ItemType> ItemTypes = new()
    {
        {ItemType.Ability, 1},
        {ItemType.Weapon, 1},
        {ItemType.Body, 1},
        {ItemType.Shield, 1},
    };
    
    public AbilityGenerateConfig()
    {
        GenerateRandomAbilityIds(6);
        GenerateRandomGearIds();
        GenerateRandomShieldIds();
        GenerateRandomBodyIds();
        GenerateRandomWeaponIds();
    }

    private List<int> _abilityIds = [];
    private List<int> _gearIds = [];
    private List<int> _weaponIds = [];
    private List<int> _bodyIds = [];
    private List<int> _shieldIds = [];

    private void GenerateRandomWeaponIds()
    {
        Logger.Log($"[AbilityGenerate] Generating Random Weapon Ids");
        var list = new List<int>();
            
        for (int i = 0; i < 3; i++)
        {
            while (true)
            {
                var id = DataBuilder.GetRandomWeaponId();
                if (list.Contains(id)) continue;
                list.Add(id);
                break;
            }
        }
        
        _weaponIds = list;
        Logger.Log($"[AbilityGenerate] Generated Random Weapon Ids");
    }
    
    private void GenerateRandomBodyIds()
    {
        Logger.Log($"[AbilityGenerate] Generating Random Body Ids");
        var list = new List<int>();
            
        for (int i = 0; i < 3; i++)
        {
            while (true)
            {
                var id = DataBuilder.GetRandomBodyId();
                if (list.Contains(id)) continue;
                list.Add(id);
                break;
            }
        }
        
        _bodyIds = list;
        Logger.Log($"[AbilityGenerate] Generated Random Body Ids");
    }
    
    private void GenerateRandomShieldIds()
    {
        Logger.Log($"[AbilityGenerate] Generating Random Shield Ids");
        var list = new List<int>();
            
        for (int i = 0; i < 3; i++)
        {
            while (true)
            {
                var id = DataBuilder.GetRandomShieldId();
                if (list.Contains(id)) continue;
                list.Add(id);
                break;
            }
        }
        
        _shieldIds = list;
        Logger.Log($"[AbilityGenerate] Generated Random Shield Ids");
    }

    private void GenerateRandomAbilityIds(int size)
    {
        Logger.Log($"[AbilityGenerate] Generating Random Ability Ids");
        var list = new List<int>();
            
        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                var id = DataBuilder.AbilityIdPool.PickRandom();
                if (list.Contains(id)) continue;
                list.Add(id);
                break;
            }
        }

        _abilityIds = list;
        Logger.Log($"[AbilityGenerate] Generated Random Ability Ids");
    }

    private void GenerateRandomGearIds()
    {
        Logger.Log($"[AbilityGenerate] Generating Random Gear Ids");
        var list = new List<int>();
            
        for (int i = 0; i < 3; i++)
        {
            var id = i switch
            {
                0 => DataBuilder.GetRandomBodyId(),
                1 => DataBuilder.GetRandomWeaponId(),
                2 => DataBuilder.GetRandomShieldId(),
                _ => throw new ArgumentOutOfRangeException(nameof(i), $"Invalid value: {i}")
            };
            
            if (list.Contains(id)) continue;
            list.Add(id);
            break;
        }

        _gearIds = list;
        Logger.Log($"[AbilityGenerate] Generated Random Gear Ids");
    }


    public int SelectMutationAbilityId()
    {
        return DataBuilder.MutationAbilityIdPool.PickRandom();
    }

    public int SelectAbilityId()
    {
        var id = _abilityIds.PickRandom();
        _abilityIds.Remove(id);
        return id;
    }
    
    public int SelectGearId()
    {
        var id = _gearIds.PickRandom();
        _gearIds.Remove(id);
        return id;
    }
    
    public int SelectWeaponId()
    {
        var id = _weaponIds.PickRandom();
        _weaponIds.Remove(id);
        return id;
    }
    
    public int SelectBodyId()
    {
        var id = _bodyIds.PickRandom();
        _bodyIds.Remove(id);
        return id;
    }
    
    public int SelectShieldId()
    {
        var id = _shieldIds.PickRandom();
        _shieldIds.Remove(id);
        return id;
    }
}