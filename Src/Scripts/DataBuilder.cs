using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AcidWallStudio.AcidUtilities;
using cfg;
using Godot;
using Game = NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts;

public class DataBuilder
{
    private static Tables _tables;

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
        cfg.Body tbBody = _tables.TbBody.Get(id);

        string name = tbBody.ClassName;
        Type classType = Type.GetType("NovaDrift.Scripts.Systems.Bodies." + name);
        if (classType == null)
        {
            throw new Exception("无法找到类：" + name);
        }
        
        Game.Body body = (Game.Body) Activator.CreateInstance(classType);

        body?.SetName(tbBody.Name)
            .SetDesc(tbBody.Desc)
            .SetIconPath(tbBody.IconName)
            .SetAcceleration(tbBody.Acceleration)
            .SetDeceleration(tbBody.Deceleration)
            .SetHealth(tbBody.Health);

        return body;
    }

    public static Game.Weapon BuildWeaponById(int id)
    {
        cfg.Weapon tbWeapon = _tables.TbWeapon.Get(id);
        Game.Weapon weapon = new Game.Weapon();
        
        weapon.Name = tbWeapon.Name;
        weapon.Desc = tbWeapon.Desc;
        weapon.SceneName = tbWeapon.SceneName;
        
        return weapon;
    }

    public static Game.Ability BuildAbilityById(int id)
    {
        cfg.Ability tbAbility = _tables.TbAbility.Get(id);
        Game.Ability ability = new Game.Ability();

        ability.Name = tbAbility.Name;
        ability.Desc = tbAbility.Desc;
        ability.ClassName = tbAbility.ClassName;
        ability.Effect = BuildEffectByName(ability.ClassName, tbAbility.Values);

        return ability;
    }

    public static Game.Effect BuildEffectByName(string name, List<float> values)
    {
        Type classType = Type.GetType("NovaDrift.Scripts.Systems.Effects." + name);
        if (classType == null)
        {
            throw new Exception("无法找到类：" + name);
        }
        
        Game.Effect effect = (Game.Effect) Activator.CreateInstance(classType);
        effect.Values = values;
        return effect;
    }
    
    public static Game.MobInfo BuildMobInfoById(int id)
    {
        cfg.MobInfo tbMobInfo = _tables.TbMobInfo.Get(id);
        Game.MobInfo mobInfo = new Game.MobInfo();

        mobInfo.
            SetName(tbMobInfo.IconName).
            SetIconPath(tbMobInfo.IconName);
        
        return mobInfo;
    }

    public static void Init()
    {
        _tables = new cfg.Tables(file => JsonSerializer.Deserialize<JsonElement>(
            Wizard.ReadAllText($"Assets/DataBase/{file}.json")));
    }
}