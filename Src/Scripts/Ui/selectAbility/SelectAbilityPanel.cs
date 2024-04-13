using System;
using DsUi;
using Godot;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.AbilityItem;
using NovaDrift.Scripts.Ui.AbilityPanel;

namespace NovaDrift.Scripts.Ui.SelectAbility;

public partial class SelectAbilityPanel : SelectAbility
{
    private AbilityPanelPanel _abilityPanel;
    
    private IItemInfo _currentItem;
    
    public override void OnCreateUi()
    {
        _abilityPanel = S_AbilityPanel.Instance;
        S_YesBtn.Instance.Pressed += () =>
        {
            if (_currentItem == null) return;
            _currentItem.Use();
            Destroy();
        };
        
        GenerateAbilityPanel(new AbilityGenerateConfig(5));
    }
    
    private void GenerateAbilityPanel(AbilityGenerateConfig config)
    {
        // 生成 Items
        for (int i = 0; i < config.Count; i++)
        {
            var abilityItem = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
            
            if (Random.Shared.NextDouble() > 0.5)
            {
                abilityItem.Item = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
            }
            else
            {
                abilityItem.Item = DataBuilder.BuildWeaponById(DataBuilder.GetRandomWeaponId());
            }
            
            abilityItem.OnAbilitySelected += item =>
            {
                _abilityPanel.UpdateUi(item);
                _currentItem = item;
            };
        }
    }
    
    public override void OnDestroyUi()
    {
        Global.ResumeGame();
    }

}
