using DsUi;
using Godot;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.AbilityItem;
using NovaDrift.Scripts.Ui.StatMonitorLabel;

namespace NovaDrift.Scripts.Ui.PausedMenu;

public partial class PausedMenuPanel : PausedMenu
{
    public override void OnCreateUi()
    {
        S_ReStartBtn.Instance.Pressed += UiManager.Hide_PausedMenu;

        OnShowUiEvent += () =>
        {
            Global.StopGame();
            S_Indicator.Instance.Hide();
            S_AbilityPanel.Instance.Hide();
        };
        OnHideUiEvent += Global.ResumeGame;

        Global.Player.Stats.EffectSystem.OnAbilityAdded += AddAbility;
        // Global.Player.Stats.EffectSystem.OnAbilityRemoved += _ => UpdateUi();
        
        S_AbilityPanel.Instance.HideYesBtn();
        S_BackToMainBtn.Instance.Pressed += () =>
        {
            UiManager.Hide_PausedMenu();
            Global.ResumeGame();
            EventBus.OnPlayerDead?.Invoke();
            EventBus.OnGameOver?.Invoke();
        };

        EventBus.OnGameOver += () =>
        {
            foreach (var node in S_Abilities.Instance.GetChildren())
            {
                node.QueueFree();
            }
        };
        
        GenerateStats();
    }

    private void GenerateStats()
    {
        var count = 0;
        HBoxContainer lastBox = null;
        foreach (var statContainer in Global.Player.Stats.GetAllStats())
        {
            if (count >= 4) count = 0;
            
            if (count == 0)
            {
                var hBox = new HBoxContainer();
                S_Stats.AddChild(hBox);
                lastBox = hBox;
            }

            var panel = UiManager.Create_StatMonitorLabel();
            panel.Reparent(lastBox);
            panel.StatName = statContainer.Item2;
            panel.Stat = statContainer.Item1;
            panel.Show();
            count++;
        }
    }

    private void AddAbility(Ability ability)
    {
        var itemPanel = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
        itemPanel.Item = ability;
        itemPanel.ShowUi();
        itemPanel.OnAbilitySelected += info =>
        {
            S_AbilityPanel.Instance.Show();
            S_AbilityPanel.Instance.UpdateUi(info);
            MoveIndicator(itemPanel.GlobalPosition);
        };
    }
    
    private void MoveIndicator(Vector2 pos)
    {
        S_Indicator.Instance.Show();
        var tw = CreateTween();
        tw.TweenProperty(S_Indicator.Instance, "global_position", pos, 0.1f);
    }

    public override void OnDestroyUi()
    {
        
    }

}
