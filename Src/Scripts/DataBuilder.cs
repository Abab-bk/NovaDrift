using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using cfg;
using Game = NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts;

public class DataBuilder
{
    public static Tables Tables;

    public static int GetRandomAbilityId()
    {
        Random random = new Random();
        int id = random.Next(
            Tables.TbAbility.DataMap.Keys.First(),
            Tables.TbAbility.DataMap.Keys.Last()
            );
        
        return id;
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