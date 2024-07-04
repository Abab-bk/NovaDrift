
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
public sealed partial class PowerUpInfo : Luban.BeanBase
{
    public PowerUpInfo(JsonElement _buf) 
    {
        Id = _buf.GetProperty("id").GetInt32();
        Name = _buf.GetProperty("name").GetString();
        ClassName = _buf.GetProperty("class_name").GetString();
        Desc = _buf.GetProperty("desc").GetString();
        IconName = _buf.GetProperty("icon_name").GetString();
    }

    public static PowerUpInfo DeserializePowerUpInfo(JsonElement _buf)
    {
        return new PowerUpInfo(_buf);
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
    /// 类名
    /// </summary>
    public readonly string ClassName;
    /// <summary>
    /// 描述
    /// </summary>
    public readonly string Desc;
    /// <summary>
    /// 图标名
    /// </summary>
    public readonly string IconName;
   
    public const int __ID__ = -2133481682;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "name:" + Name + ","
        + "className:" + ClassName + ","
        + "desc:" + Desc + ","
        + "iconName:" + IconName + ","
        + "}";
    }
}

}
