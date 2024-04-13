
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
public sealed partial class Body : Luban.BeanBase
{
    public Body(JsonElement _buf) 
    {
        Id = _buf.GetProperty("id").GetInt32();
        Name = _buf.GetProperty("name").GetString();
        Desc = _buf.GetProperty("desc").GetString();
        IconName = _buf.GetProperty("icon_name").GetString();
        Acceleration = _buf.GetProperty("acceleration").GetSingle();
        Deceleration = _buf.GetProperty("deceleration").GetSingle();
        RotationSpeed = _buf.GetProperty("rotation_speed").GetSingle();
    }

    public static Body DeserializeBody(JsonElement _buf)
    {
        return new Body(_buf);
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
    /// <summary>
    /// 图片
    /// </summary>
    public readonly string IconName;
    /// <summary>
    /// 加速度
    /// </summary>
    public readonly float Acceleration;
    /// <summary>
    /// 减速度
    /// </summary>
    public readonly float Deceleration;
    /// <summary>
    /// 旋转速度
    /// </summary>
    public readonly float RotationSpeed;
   
    public const int __ID__ = 2076098;
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
        + "iconName:" + IconName + ","
        + "acceleration:" + Acceleration + ","
        + "deceleration:" + Deceleration + ","
        + "rotationSpeed:" + RotationSpeed + ","
        + "}";
    }
}

}
