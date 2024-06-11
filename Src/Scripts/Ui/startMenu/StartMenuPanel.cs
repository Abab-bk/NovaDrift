using DsUi;
using Godot;
using NovaDrift.Scripts.Ui.Setting;

namespace NovaDrift.Scripts.Ui.StartMenu;

public partial class StartMenuPanel : StartMenu
{
    public override void _Ready()
    {
        S_StartGameBtn.Instance.OnClick += () =>
        {
            EventBus.OnGameInit?.Invoke();
        };
        S_ExitBtn.Instance.OnClick += () =>
        {
            GetTree().Quit();
        };
        S_SettingBtn.Instance.OnClick += () =>
        {
            OpenNextUi(UiManager.UiName.Setting);
        };
        S_GearBtn.Instance.OnClick += () =>
        {
            OpenNextUi(UiManager.UiName.GearLibrary);
        };

        EventBus.OnGameStart += () =>
        {
            UiManager.Destroy_StartMenu();
        };
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
