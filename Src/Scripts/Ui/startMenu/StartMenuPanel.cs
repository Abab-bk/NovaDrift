using DsUi;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.StartMenu;

public partial class StartMenuPanel : StartMenu
{
    private bool _isClicked = false;
    
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
        
        L_Content.Instance.Hide();
        L_GameLogo.Instance.Show();

        S_GameLogoTouch.Instance.Pressed += () =>
        {
            if (_isClicked) return;
            _isClicked = true;
            GTweenSequenceBuilder.New()
                .Append(L_GameLogo.Instance
                    .TweenModulateAlpha(0f, 0.5f)
                    .OnComplete(() =>
                    {
                        L_Content.Instance.Modulate = L_Content.Instance.Modulate with { A = 0f };
                        L_Content.Instance.Show();
                    })
                )
                .Append(L_Content.Instance.TweenModulateAlpha(1f, 0.5f))
                .AppendCallback(() =>
                {
                    L_GameLogo.Instance.QueueFree();
                })
                .Build()
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
