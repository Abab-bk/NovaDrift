using DsUi;
using Godot;

namespace NovaDrift.Scripts.Ui.StartMenu;

public partial class StartMenuPanel : StartMenu
{
    public override void _Ready()
    {
        S_StartGameBtn.Instance.OnClick += () =>
        {
            Global.OnGameInit?.Invoke();
        };

        Global.OnGameStart += () =>
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