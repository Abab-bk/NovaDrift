using Godot;

namespace NovaDrift.Scripts.Ui.Relife;

public partial class RelifePanel : Relife
{
    private int _count = 5;

    public override void OnCreateUi()
    {
        S_ContinueBtn.Instance.Pressed += Continue;
        S_RelifeBtn.Instance.Pressed += () =>
        {
            Global.GameContext.ReliveCount += 1;
            Global.Player.Stats.Health.Replenish();
            Global.ResumeGame();
            QueueFree();
        };
        S_Label.Instance.Text = _count.ToString();
        
        L_Timer.Instance.Timeout += () =>
        {
            if (_count <= 0)
            {
                Continue();
                return;
            }
            
            _count -= 1;
            S_Label.Instance.Text = _count.ToString();
            L_Timer.Instance.Start();
        };
        L_Timer.Instance.Start();
    }

    private void Continue()
    {
        Global.ResumeGame();
        EventBus.OnPlayerDead?.Invoke();
        EventBus.OnGameOver?.Invoke();
        QueueFree();
    }

    public override void OnDestroyUi()
    {
        
    }

}
