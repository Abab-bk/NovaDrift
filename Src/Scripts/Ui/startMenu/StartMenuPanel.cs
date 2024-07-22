using AcidWallStudio.AcidUtilities;
using DsUi;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.StartMenu;

public partial class StartMenuPanel : StartMenu
{
    private bool _isClicked;
    
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

        S_DailyQuestsBtn.Instance.OnClick += () =>
        {
            this.ChangeTo(UiManager.Create_DailyQuests());
        };
        
        S_CreditBtn.Instance.OnClick += () =>
        {
            this.ChangeTo(UiManager.Create_Credit());
        };

        EventBus.OnGameInit += Destroy;

        S_GameLogoTouch.Instance.Pressed += CheckLogin;
        
        var tapNode = new TapTapNode();
        AddChild(tapNode);
        Global.TapTapNode = tapNode;
        Global.TapTapNode.Awake();
        Global.TapTapNode.Init();
        
        if (Global.ShowLogo)
        {
            L_Content.Instance.Hide();
            L_GameLogo.Instance.Show();
            Global.ShowLogo = false;
            return;
        }
        L_Content.Instance.Show();
        L_GameLogo.Instance.Hide();
        _isClicked = true;
    }

    private void CheckLogin()
    {
        if (Global.CurrentPlatform == GamePlatform.Desktop)
        {
            Enter();
            return;
        }
        
        Global.TapTapNode.OnAntiPass += Enter;
        Global.TapTapNode.OnLogged += () =>
        {
            Global.TapTapNode.StartupAntiAddiction();
        };
        Global.TapTapNode.OnLoginNot += () =>
        {
            Global.TapTapNode.Login();
        };
        
        Global.TapTapNode.IsLogged();
    }

    private void Enter()
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
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
