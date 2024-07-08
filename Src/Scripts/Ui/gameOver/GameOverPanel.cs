using DsUi;
using NovaDrift.Scripts.Ui.ScoreItem;

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
        
        AddScoreItem("得分", Global.GameContext.Score);

        S_AcidCoinsLabel.Instance.Text = Global.GameContext.Score.ToString();
        Global.AcidCoins += Global.GameContext.Score;
    }

    private void AddScoreItem(string text, int score)
    {
        var labelPanel = S_Items.OpenNestedUi<ScoreItemPanel>(UiManager.UiName.ScoreItem);
        labelPanel.SetContext(text, score);
        labelPanel.Show();
        labelPanel.PlayAnimation();
    }

    public override void OnDestroyUi()
    {
        
    }
}
