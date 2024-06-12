using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AcidWallStudio.AcidUtilities;
using cfg;
using cfg.DataBase;
using Godot;
using NovaDrift.addons.AcidStats;
using Game = NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts;

public class StoreModifier(float discount)
{
    public float Discount = discount;
}

public static class DataBuilder
{
    public static Tables Tables;
    public static TbConstants Constants => Tables.TbConstants;
    public static readonly List<int> AbilityIdPool = new List<int>();

    private static readonly Curve FuncUpLevelCurveBefore20 = GD.Load<Curve>("res://Assets/Curves/UpLevelCurveBefore20.tres");
    private static readonly Curve FuncUpLevelCurveAfter20 = GD.Load<Curve>("res://Assets/Curves/UpLevelCurveAfter20.tres");

    public static Dictionary<int, StoreModifier> StoreModifiers = new()
    {
        { 1001, new StoreModifier(0.5f) }
    };
    public static float GetNextLevelExp(int level)
    {
         // float nextLevelExp = level < 20
         //    ? FuncUpLevelCurveBefore20.Sample(level / 20f) * 100
         //    : FuncUpLevelCurveAfter20.Sample((level - 20) / Constants.MaxLevel - 20f) * 100;

        float nextLevelExp = 0;
        
        if (level == 1)
        {
            nextLevelExp = 5f;
        }
        else if (level <= 20)
        {
            nextLevelExp = level * 10;
        }
        else if (level <= 40)
        {
            nextLevelExp = level * 13;
        }
        else
        {
            nextLevelExp = level * 16;
        }

        return nextLevelExp;
    }


    public static void BuildAbilityIdPool()
    {
        AbilityIdPool.Clear();
        foreach (var map in Tables.TbAbilityTree.DataMap)
        {
            AbilityIdPool.Add(map.Value.StartAbilityId);
        }
    }
    
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
            Tables.TbAbility.DataMap.Keys.ElementAt(1),
            Tables.TbAbility.DataMap.Keys.Last() + 1
            );
        return id;
    }

    public static int GetRandomWeaponId()
    {
        int id = Random.Shared.Next(
            Tables.TbWeapon.DataMap.Keys.ElementAt(1),
            Tables.TbWeapon.DataMap.Keys.Last() + 1
        );
        return id;
    }
    
    public static int GetRandomBodyId()
    {
        int id = Random.Shared.Next(
            Tables.TbBody.DataMap.Keys.ElementAt(1),
            Tables.TbBody.DataMap.Keys.Last() + 1
        );
        return id;
    }

    public static int GetRandomShieldId()
    {
        int id = Random.Shared.Next(
            Tables.TbShield.DataMap.Keys.ElementAt(1),
            Tables.TbShield.DataMap.Keys.Last() + 1
        );
        return id;
    }

    public static int GetRandomMobId()
    {
        int id = Random.Shared.Next(
            Tables.TbMobInfo.DataMap.Keys.ElementAt(1),
            Tables.TbMobInfo.DataMap.Keys.Last() + 1
        );
        return id;
    }

    public static Game.Body BuildBodyById(int id)
    {
        Body tbBody = Tables.TbBody.Get(id);

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
        body.IconPath2 = $"res://Assets/Ui/Icons/BodyIcons/{tbBody.IconName}Icon.png";
        body.Acceleration = tbBody.Acceleration;
        body.Deceleration = tbBody.Deceleration;
        body.Health = tbBody.Health;
        body.Values = tbBody.Values;
        
        return body;
    }

    public static Game.Weapon BuildWeaponById(int id)
    {
        Weapon tbWeapon = Tables.TbWeapon.Get(id);
        Game.Weapon weapon = new Game.Weapon
        {
            Id = tbWeapon.Id,
            Name = tbWeapon.Name,
            Desc = tbWeapon.Desc,
            SceneName = tbWeapon.SceneName,
        };
        
        return weapon;
    }
    
    public static Game.Shield BuildShieldById(int id)
    {
        Shield tbShield = Tables.TbShield.Get(id);
        Game.Shield shield = new Game.Shield
        {
            Id = tbShield.Id,
            Name = tbShield.Name,
            Desc = tbShield.Desc,
            SceneName = tbShield.SceneName,
            Values = tbShield.Values,
            Health = tbShield.Health,
            CoolDown = tbShield.CoolDown,
        };
        
        return shield;
    }

    public static Game.Ability BuildAbilityById(int id)
    {
        Ability tbAbility = Tables.TbAbility.Get(id);
        Game.Ability ability = new Game.Ability
        {
            Id = tbAbility.Id,
            Name = tbAbility.Name,
            Desc = tbAbility.Desc,
            ClassName = tbAbility.ClassName,
            IconPath = $"res://Assets/Ui/Icons/AbilityIcons/{tbAbility.ClassName}.tres",
            Effect = BuildEffectByName(tbAbility.ClassName, tbAbility.Values, tbAbility.Name),
            Tree = BuildAbilityTreeById(tbAbility.TreeId),
        };
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
        Buff tbBuff = Tables.TbBuff.Get(id);
        
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
            buff.IconPath = $"res://Assets/Ui/Icons/Statuses/{tbBuff.ClassName}.tres";
        }
        
        return buff;
    }
    
    public static Game.MobInfo BuildMobInfoById(int id)
    {
        MobInfo tbMobInfo = Tables.TbMobInfo.Get(id);
        Game.MobInfo mobInfo = new Game.MobInfo
        {
            Name = tbMobInfo.Name,
            Id = tbMobInfo.Id,
            Health = tbMobInfo.Health,
            Speed = tbMobInfo.Speed,
            Damage = tbMobInfo.Damage,
            ShootCd = tbMobInfo.ShootCd,
            Targeting = tbMobInfo.Targeting,
            BulletCount = tbMobInfo.BulletCount,
            Size = tbMobInfo.Size,
            DangerFactor = tbMobInfo.DangerFactor,
            GetExp = tbMobInfo.GetExp,
            ScenePath = $"res://Scenes/Prefabs/Actors/Mobs/{tbMobInfo.SceneName}.tscn".Trim(),
        };
        
        return mobInfo;
    }
    
    
    public static Game.MobInfo BuildBossMobInfoById(int id)
    {
        BossMobInfo tbMobInfo = Tables.TbBossMobInfo.Get(id);
        Game.MobInfo mobInfo = new Game.MobInfo
        {
            Name = tbMobInfo.Name,
            Id = tbMobInfo.Id,
            Health = tbMobInfo.Health,
            Speed = tbMobInfo.Speed,
            Damage = tbMobInfo.Damage,
            ShootCd = tbMobInfo.ShootCd,
            Targeting = tbMobInfo.Targeting,
            BulletCount = tbMobInfo.BulletCount,
            Size = tbMobInfo.Size,
            DangerFactor = tbMobInfo.DangerFactor,
            GetExp = tbMobInfo.GetExp,
            ScenePath = $"res://Scenes/Prefabs/Actors/Mobs/{tbMobInfo.SceneName}.tscn".Trim(),
        };
        
        return mobInfo;
    }
    
    
    private static Game.AbilityTree BuildAbilityTreeById(int id)
    {
        AbilityTree tbAbilityTree = Tables.TbAbilityTree.Get(id);
        Game.AbilityTree abilityTree = new Game.AbilityTree
        {
            Id = tbAbilityTree.Id,
            StartAbilityId = tbAbilityTree.StartAbilityId,
            MiddleAbilityIds = tbAbilityTree.MiddleAbilityIds,
            EndAbilityId = tbAbilityTree.EndAbilityId,
        };
        
        return abilityTree;
    }

    static DataBuilder()
    {
        Tables = new Tables(file => JsonSerializer.Deserialize<JsonElement>(
            Wizard.ReadAllText($"res://Assets/DataBase/{file}.json")));
    }
}