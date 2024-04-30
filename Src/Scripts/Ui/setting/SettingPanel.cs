using Godot;

namespace NovaDrift.Scripts.Ui.Setting;

public partial class SettingPanel : Setting
{
    public override void _Ready()
    {
        base._Ready();
        S_CloseBtn.Instance.Pressed += OpenPrevUi;
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
