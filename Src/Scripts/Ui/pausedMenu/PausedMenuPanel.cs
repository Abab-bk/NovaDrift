using DsUi;
using Godot;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.AbilityItem;

namespace NovaDrift.Scripts.Ui.PausedMenu;

public partial class PausedMenuPanel : PausedMenu
{
    private GridContainer _abilities;
    
    public override void OnCreateUi()
    {
        _abilities = S_Abilities.Instance;

        S_ReStartBtn.Instance.Pressed += UiManager.Hide_PausedMenu;

        OnShowUiEvent += Global.StopGame;
        OnHideUiEvent += Global.ResumeGame;

        Global.Player.Stats.EffectSystem.OnAbilityAdded += AddAbility;
        Global.Player.Stats.EffectSystem.OnAbilityRemoved += _ => UpdateUi();
    }
    
    private void AddAbility(Ability ability)
    {
        var itemPanel = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
        itemPanel.Item = ability;
        itemPanel.ShowUi();
    }
    
    private void UpdateUi()
    {
        foreach (var node in _abilities.GetChildren()) { node.QueueFree(); }
        
        foreach (var ability in Global.Player.Stats.EffectSystem.Abilities)
        {
            var itemPanel = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
            itemPanel.Item = ability;
        }
    }

    public override void OnDestroyUi()
    {
        
    }

}
