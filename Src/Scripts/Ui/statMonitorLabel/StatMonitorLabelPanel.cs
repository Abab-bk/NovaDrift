using System.Globalization;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Ui.StatMonitorLabel;

public partial class StatMonitorLabelPanel : StatMonitorLabel
{
    public string StatName
    {
        set => S_StatNameLabel.Instance.Text = value;
    }

    public Stat Stat
    {
        set
        {
            _stat = value;
            UpdateUi(_stat.Value);
            _stat.ValueChanged += UpdateUi;
        }
        get => _stat;
    }

    private Stat _stat;

    private void UpdateUi(float value)
    {
        if (_stat == null) return;
        S_StatNumLabel.Instance.Text = value.ToString(CultureInfo.CurrentCulture);
    }

    public override void OnCreateUi()
    {
    }

    public override void OnDestroyUi()
    {
        
    }

}
