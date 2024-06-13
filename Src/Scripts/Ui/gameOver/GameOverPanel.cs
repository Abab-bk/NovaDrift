using DsUi;
using NovaDrift.Scripts.Ui.ScoreLabel;

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
        
        for (int i = 0; i < 1; i++)
        {
            var scoreLabel = S_Items.OpenNestedUi<ScoreLabelPanel>(UiManager.UiName.ScoreLabel);
            scoreLabel.SetContent("得分", Global.GameContext.Score.ToString());
        }

        S_AcidCoinsLabel.Instance.Text = Global.GameContext.Score.ToString();
        Global.AcidCoins += Global.GameContext.Score;
    }

    public override void OnDestroyUi()
    {
        
    }
}
