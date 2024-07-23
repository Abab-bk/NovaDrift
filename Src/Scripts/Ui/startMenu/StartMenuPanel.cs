using AcidWallStudio.AcidUtilities;
using DsUi;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.StartMenu;

public partial class StartMenuPanel : StartMenu
{
    private bool _isClicked;

    private bool _shouldLogin;
    
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

        S_GameLogoTouch.Instance.Pressed += Enter;
        
        var tapNode = new TapTapNode();
        AddChild(tapNode);
        Global.TapTapNode = tapNode;

        Global.TapTapNode.OnAntiPass += Enter;
        Global.TapTapNode.OnLogged += () =>
        {
            Global.TapTapNode.StartupAntiAddiction();
        };
        Global.TapTapNode.OnLoginNot += () =>
        {
            S_LoginBtn.Instance.Show();
            if (!_shouldLogin)
            {
                _shouldLogin = true;
            }
            Global.TapTapNode.Login();
        };
        
        Global.TapTapNode.Awake();
        Global.TapTapNode.Init();
        
        S_LoginBtn.Instance.Pressed += CheckLogin;
        S_LoginBtn.Instance.Hide();
        
        if (Global.ShowLogo)
        {
            if (Global.CurrentPlatform == GamePlatform.Desktop)
            {
                L_Content.Instance.Hide();
                S_LoginBtn.Instance.Hide();
                S_GameLogoTouch.Instance.Disabled = false;
                Global.ShowLogo = false;
                return;
            }
            
            S_LoginBtn.Instance.Show();
            S_GameLogoTouch.Instance.Disabled = true;
            L_Content.Instance.Hide();
            Global.ShowLogo = false;
            _shouldLogin = false;
            CheckLogin();
            return;
        }
        L_Content.Instance.Show();
        L_GameLogo.Instance.Hide();
        S_GameLogoTouch.Instance.Disabled = false;
        _isClicked = true;
    }

    private void CheckLogin()
    {
        if (Global.CurrentPlatform == GamePlatform.Desktop) return;
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
