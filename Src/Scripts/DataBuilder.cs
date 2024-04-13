using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using cfg;
using Godot;
using Game = NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts;

public class DataBuilder
{
    public static Tables Tables;

    public static int GetRandomAbilityId()
    {
        int id = Random.Shared.Next(
            Tables.TbAbility.DataMap.Keys.First(),
            Tables.TbAbility.DataMap.Keys.Last() + 1
            );
        return id;
    }

    public static int GetRandomWeaponId()
    {
        int id = Random.Shared.Next(
            Tables.TbWeapon.DataMap.Keys.First(),
            Tables.TbWeapon.DataMap.Keys.Last() + 1
        );
        return id;
    }
    
    public static int GetRandomBodyId()
    {
        int id = Random.Shared.Next(
            Tables.TbBody.DataMap.Keys.First(),
            Tables.TbBody.DataMap.Keys.Last() + 1
        );
        return id;
    }

    public static Game.Body BuildBodyById(int id)
    {
        cfg.Body tbBody = Tables.TbBody.Get(id);
        Game.Body body = new Game.Body();

        body.SetName(tbBody.Name)
            .SetDesc(tbBody.Desc)
            .SetIconPath(tbBody.IconName)
            .SetAcceleration(tbBody.Acceleration)
            .SetDeceleration(tbBody.Deceleration);

        return body;
    }

    public static Game.Weapon BuildWeaponById(int id)
    {
        cfg.Weapon tbWeapon = Tables.TbWeapon.Get(id);
        Game.Weapon weapon = new Game.Weapon();
        
        weapon.Name = tbWeapon.Name;
        weapon.Desc = tbWeapon.Desc;
        weapon.SceneName = tbWeapon.SceneName;
        
        return weapon;
    }

    public static Game.Ability BuildAbilityById(int id)
    {
        cfg.Ability tbAbility = Tables.TbAbility.Get(id);
        Game.Ability ability = new Game.Ability();

        ability.Name = tbAbility.Name;
        ability.Desc = tbAbility.Desc;
        ability.ClassName = tbAbility.ClassName;
        ability.Effect = BuildEffectByName(ability.ClassName);

        return ability;
    }

    public static Game.Effect BuildEffectByName(string name)
    {
        Type classType = Type.GetType("NovaDrift.Scripts.Systems.Effects." + name);
        if (classType == null)
        {
            throw new Exception("无法找到类：" + name);
        }
        
        Game.Effect effect = (Game.Effect) Activator.CreateInstance(classType);
        return effect;
    }

    public static void Init()
    {
        Tables = new cfg.Tables(file => JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText($"Assets/DataBase/{file}.json")));
    }
}