using DsUi;
using Godot;

namespace NovaDrift.Scripts.Ui.Relife;

public partial class RelifePanel : Relife
{
    private int _count = 5;

    private bool _flag;
    private bool _reliveFlag;
    
    public override void OnCreateUi()
    {
        Global.OnAdRewardGet += () =>
        {
            Global.GameContext.ReliveCount += 1;
            Global.Player.IsDead = false;
            Global.Player.Stats.Health.Replenish();
            Global.ResumeGame();
            QueueFree();
        };

        Global.OnAdVideoFailed += () =>
        {
            UiManager.Open_Popup()
                .SetConfig(
                    "广告",
                    "广告加载失败"
                );
        };

        S_ContinueBtn.Instance.Pressed += Continue;
        S_RelifeBtn.Instance.Pressed += () =>
        {
            _reliveFlag = true;
            Global.ShowRewardVideoAd();
        };
        
        S_Label.Instance.Text = _count.ToString();
        
        L_Timer.Instance.Timeout += () =>
        {
            if (_count <= 0)
            {
                Continue();
                return;
            }
            
            if (!_reliveFlag) _count -= 1;
            S_Label.Instance.Text = _count.ToString();
            if (!_reliveFlag) L_Timer.Instance.Start();
        };
        L_Timer.Instance.Start();
    }

    private void Continue()
    {
        if (_reliveFlag) return;
        if (_flag) return;
        _flag = true;
        Global.ResumeGame();
        EventBus.OnPlayerDead?.Invoke();
        EventBus.OnGameOver?.Invoke();
        QueueFree();
    }

    public override void OnDestroyUi()
    {
        
    }

}
