using System;
using System.Reflection;
using Godot;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Ui.StatsMonitorItem;

public partial class StatsMonitorItemPanel : StatsMonitorItem
{
    [Export] public string MonitorName;
    
    public override void OnCreateUi()
    {
        S_PropertyLabel.Instance.Text = MonitorName;
        
        Type type = Global.Player.Stats.GetType();
        FieldInfo fieldInfo = type.GetField(MonitorName);
        
        if (fieldInfo == null)
        {
            GD.Print("没有找到属性 " + MonitorName);
            return;
        }
        
        Stat stat = fieldInfo.GetValue(Global.Player.Stats) as Stat;
        stat.ValueChanged += f =>
        {
            S_ValueLabel.Instance.Text = f.ToString();
        };
        S_ValueLabel.Instance.Text = stat.Value.ToString();
    }

    public override void OnDestroyUi()
    {
        
    }

}
