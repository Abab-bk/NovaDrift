using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AcidWallStudio.AcidUtilities;
using cfg;
using cfg.DataBase;
using NovaDrift.addons.AcidStats;
using Game = NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts;

public static class DataBuilder
{
    private static Tables _tables;
    public static TbConstants Constants => _tables.TbConstants;

    public static StatModifier BuildFlatModifier(float value)
    {
        return new StatModifier(value, StatModType.Flat);
    }
    
    public static StatModifier BuildPercentAddModifier(float value)
    {
        return new StatModifier(value, StatModType.PercentAdd);
    }
    
    public static StatModifier BuildPercentMultModifier(float value)
    {
        return new StatModifier(value, StatModType.PercentMult);
    }
    
    
    public static int GetRandomAbilityId()
    {
        int id = Random.Shared.Next(
            _tables.TbAbility.DataMap.Keys.ElementAt(1),
            _tables.TbAbility.DataMap.Keys.Last() + 1
            );
        return id;
    }

    public static int GetRandomWeaponId()
    {
        int id = Random.Shared.Next(
            _tables.TbWeapon.DataMap.Keys.ElementAt(1),
            _tables.TbWeapon.DataMap.Keys.Last() + 1
        );
        return id;
    }
    
    public static int GetRandomBodyId()
    {
        int id = Random.Shared.Next(
            _tables.TbBody.DataMap.Keys.ElementAt(1),
            _tables.TbBody.DataMap.Keys.Last() + 1
        );
        return id;
    }
    
    public static int GetRandomMobId()
    {
        int id = Random.Shared.Next(
            _tables.TbMobInfo.DataMap.Keys.ElementAt(1),
            _tables.TbMobInfo.DataMap.Keys.Last() + 1
        );
        return id;
    }

    public static Game.Body BuildBodyById(int id)
    {
        Body tbBody = _tables.TbBody.Get(id);

        string name = tbBody.ClassName;
        Type classType = Type.GetType("NovaDrift.Scripts.Systems.Bodies." + name);
        if (classType == null)
        {
            throw new Exception("无法找到类：" + name);
        }
        
        Game.Body body = (Game.Body) Activator.CreateInstance(classType);

        if (body == null) return null;
        
        body.Id = tbBody.Id;
        body.Name = tbBody.Name;
        body.Desc = tbBody.Desc;
        body.IconPath = $"res://Assets/Textures/Bodies/{tbBody.IconName}.png";
        body.Acceleration = tbBody.Acceleration;
        body.Deceleration = tbBody.Deceleration;
        body.Health = tbBody.Health;
        body.Values = tbBody.Values;
        
        return body;
    }

    public static Game.Weapon BuildWeaponById(int id)
    {
        Weapon tbWeapon = _tables.TbWeapon.Get(id);
        Game.Weapon weapon = new Game.Weapon();
        
        weapon.Id = tbWeapon.Id;
        weapon.Name = tbWeapon.Name;
        weapon.Desc = tbWeapon.Desc;
        weapon.SceneName = tbWeapon.SceneName;
        
        return weapon;
    }

    public static Game.Ability BuildAbilityById(int id)
    {
        Ability tbAbility = _tables.TbAbility.Get(id);
        Game.Ability ability = new Game.Ability();

        ability.Name = tbAbility.Name;
        ability.Desc = tbAbility.Desc;
        ability.ClassName = tbAbility.ClassName;
        ability.IconPath = $"res://Assets/Ui/Icons/AbilityIcons/{tbAbility.ClassName}.tres";
        ability.Effect = BuildEffectByName(ability.ClassName, tbAbility.Values, tbAbility.Name);

        return ability;
    }

    private static Game.Effect BuildEffectByName(string name, List<float> values, string showName)
    {
        Type classType = Type.GetType("NovaDrift.Scripts.Systems.Effects." + name);
        if (classType == null)
        {
            throw new Exception("无法找到类：" + name);
        }
        
        Game.Effect effect = (Game.Effect) Activator.CreateInstance(classType);

        if (effect != null)
        {
            effect.Values = values;
            effect.Name = showName;
        }

        return effect;
    }
    
    public static Game.Buff BuildBuffById(int id)
    {
        Buff tbBuff = _tables.TbBuff.Get(id);
        
        string name = tbBuff.ClassName;
        Type classType = Type.GetType("NovaDrift.Scripts.Systems.Buffs." + name);
        if (classType == null)
        {
            throw new Exception("无法找到类：" + name);
        }
        
        Game.Buff buff = (Game.Buff) Activator.CreateInstance(classType);

        if (buff != null)
        {
            buff.Id = tbBuff.Id;
            buff.Name = tbBuff.Name;
            buff.Duration = tbBuff.Duration;
            buff.RepeatTime = tbBuff.RepeatTime;
            buff.Values = tbBuff.Values;
        }
        
        return buff;
    }
    
    public static Game.MobInfo BuildMobInfoById(int id)
    {
        MobInfo tbMobInfo = _tables.TbMobInfo.Get(id);
        Game.MobInfo mobInfo = new Game.MobInfo
        {
            Name = tbMobInfo.Name,
            Id = tbMobInfo.Id,
            Health = tbMobInfo.Health,
            Speed = tbMobInfo.Speed,
            Damage = tbMobInfo.Damage,
            ShootCd = tbMobInfo.ShootCd,
            ScenePath = $"res://Scenes/Prefabs/Actors/Mobs/{tbMobInfo.SceneName}.tscn".Trim(),
        };
        
        return mobInfo;
    }

    public static void Init()
    {
        _tables = new Tables(file => JsonSerializer.Deserialize<JsonElement>(
            Wizard.ReadAllText($"Assets/DataBase/{file}.json")));
    }
}