using DsUi;
using GTweens.Builders;
using GTweensGodot.Extensions;

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
            this.ChangeTo(UiManager.Create_Setting());
        };
        S_GearBtn.Instance.OnClick += () =>
        {
            this.ChangeTo(UiManager.Create_GearLibrary());
        };

        EventBus.OnGameStart += () =>
        {
            this.TweenModulateAlpha(0f, 0.2f)
                .OnComplete(UiManager.Destroy_StartMenu)
                .Play();
        };
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
