using System.Collections.Generic;
using Godot;
using Saveable;

namespace NovaDrift.Scripts.Systems.Saver;

[GlobalClass]
public partial class CdKeySaveNode : Node, ISaveable
{
    StringName ISaveable.UniqueID => "CdKeys";
    
    private List<string> _cdKeys = new List<string>();

    public override void _Ready()
    {
        base._Ready();
        Global.CdKeySaveNode = this;
    }

    public bool HasCdKey(string key) => _cdKeys.Contains(key);
    
    public void AddCdKey(string key)
    {
        _cdKeys.Add(key);
        SaveSystem.SaveFile(Constants.SavePath, GetTree().Root, FileAccess.CompressionMode.Fastlz);
    }

    public void Load(NodeSave save)
    {
        _cdKeys = save.GetProperty<List<string>>("CdKeys");
    }

    public void Save(NodeSave save)
    {
        save.AddProperty("CdKeys", _cdKeys);
    }
}