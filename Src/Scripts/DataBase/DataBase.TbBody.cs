
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Text.Json;


namespace cfg.DataBase
{
public partial class TbBody
{
    private readonly System.Collections.Generic.Dictionary<int, Body> _dataMap;
    private readonly System.Collections.Generic.List<Body> _dataList;
    
    public TbBody(JsonElement _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Body>();
        _dataList = new System.Collections.Generic.List<Body>();
        
        foreach(JsonElement _ele in _buf.EnumerateArray())
        {
            Body _v;
            _v = Body.DeserializeBody(_ele);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Body> DataMap => _dataMap;
    public System.Collections.Generic.List<Body> DataList => _dataList;

    public Body GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Body Get(int key) => _dataMap[key];
    public Body this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

