using DsUi;

namespace NovaDrift.Scripts.Ui.GameOver;

public partial class GameOverPanel : GameOver
{
    public override void OnCreateUi()
    {
    }

    public override void _Ready()
    {
        base._Ready();
        Logger.Log($"[UI: GameOver] Ready | RestartBtn: {S_ReStartBtn.Instance} | BackToMainBtn: {S_BackToMainBtn.Instance}");
        S_ReStartBtn.Instance.Pressed += () =>
        {
            Logger.Log("[UI: GameOver] ReStartBtn Pressed");
            EventBus.OnGameInit?.Invoke();
            Destroy();
        };
        S_BackToMainBtn.Instance.Pressed += () =>
        {
            Logger.Log("[UI: GameOver] BackToMainBtn Pressed");
            Destroy();
            UiManager.Open_StartMenu();
        };
    }

    public override void OnDestroyUi()
    {
        
    }
}
