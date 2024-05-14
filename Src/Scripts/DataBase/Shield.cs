
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Text.Json;


namespace cfg
{
public sealed partial class Shield : Luban.BeanBase
{
    public Shield(JsonElement _buf) 
    {
        Id = _buf.GetProperty("id").GetInt32();
        Name = _buf.GetProperty("name").GetString();
        Desc = _buf.GetProperty("desc").GetString();
        { var __json0 = _buf.GetProperty("values"); Values = new System.Collections.Generic.List<float>(__json0.GetArrayLength()); foreach(JsonElement __e0 in __json0.EnumerateArray()) { float __v0;  __v0 = __e0.GetSingle();  Values.Add(__v0); }   }
        Health = _buf.GetProperty("health").GetSingle();
        CoolDown = _buf.GetProperty("cool_down").GetSingle();
        SceneName = _buf.GetProperty("scene_name").GetString();
    }

    public static Shield DeserializeShield(JsonElement _buf)
    {
        return new Shield(_buf);
    }

    /// <summary>
    /// 这是id
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 名称
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 描述
    /// </summary>
    public readonly string Desc;
    public readonly System.Collections.Generic.List<float> Values;
    /// <summary>
    /// 护盾值
    /// </summary>
    public readonly float Health;
    /// <summary>
    /// 冷却
    /// </summary>
    public readonly float CoolDown;
    /// <summary>
    /// 场景名
    /// </summary>
    public readonly string SceneName;
   
    public const int __ID__ = -1819473015;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "name:" + Name + ","
        + "desc:" + Desc + ","
        + "values:" + Luban.StringUtil.CollectionToString(Values) + ","
        + "health:" + Health + ","
        + "coolDown:" + CoolDown + ","
        + "sceneName:" + SceneName + ","
        + "}";
    }
}

}