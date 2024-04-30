using System;
using AcidWallStudio.AcidUtilities;
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
        _abilityPanel.OnClickYesBtn += () =>
        {
            if (_currentItem == null) return;
            _currentItem.Use();
            Destroy();
        };

        S_CloseBtn.Instance.Pressed += Destroy;
        
        GenerateAbilityPanel(new AbilityGenerateConfig(5));
    }
    
    private void GenerateAbilityPanel(AbilityGenerateConfig config)
    {
        if (Global.Player.Stats.Body.Id == 1000)
        {
            for (int i = 0; i < 3; i++)
            {
                var abilityItem = S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
                abilityItem.Item = DataBuilder.BuildBodyById(DataBuilder.GetRandomBodyId());
                
                abilityItem.OnAbilitySelected += (IItemInfo item) => { OnAbilitySelected(abilityItem); };
            }
            return;
        }
        
        if (Global.Player.Shooter.Weapon.Id == 1000)
        {
            for (int i = 0; i < 3; i++)
            {
                var abilityItem = S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
                abilityItem.Item = DataBuilder.BuildWeaponById(DataBuilder.GetRandomWeaponId());
                
                abilityItem.OnAbilitySelected += (IItemInfo item) => { OnAbilitySelected(abilityItem); };
            }
            return;
        }
        
        // 生成 Items
        for (int i = 0; i < 2; i++)
        {
            var abilityItem = S_ItemRow1.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);

            abilityItem.Item = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
            
            abilityItem.OnAbilitySelected += (IItemInfo item) => { OnAbilitySelected(abilityItem); };
        }
        
        for (int i = 0; i < 3; i++)
        {
            var abilityItem = S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);

            abilityItem.Item = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
            
            abilityItem.OnAbilitySelected += (IItemInfo item) => { OnAbilitySelected(abilityItem); };
        }
        
        for (int i = 0; i < 2; i++)
        {
            var abilityItem = S_ItemRow3.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);

            switch (config.ItemTypes.Next())
            {
                case AbilityGenerateConfig.ItemType.Body:
                    abilityItem.Item = DataBuilder.BuildBodyById(DataBuilder.GetRandomBodyId());
                    break;
                case AbilityGenerateConfig.ItemType.Weapon:
                    abilityItem.Item = DataBuilder.BuildWeaponById(DataBuilder.GetRandomWeaponId());
                    break;
                case AbilityGenerateConfig.ItemType.Ability:
                    abilityItem.Item = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
                    break;
            }

            abilityItem.OnAbilitySelected += (IItemInfo item) => { OnAbilitySelected(abilityItem); };
        }
    }

    private void OnAbilitySelected(AbilityItemPanel abilityItem)
    {
        S_Indicator.Instance.Show();
        var item = abilityItem.Item;
        _abilityPanel.UpdateUi(item);
        _currentItem = item;
        var tw = CreateTween();
        tw.TweenProperty(S_Indicator.Instance, "global_position", abilityItem.GlobalPosition, 0.1f);
    }

    public override void OnDestroyUi()
    {
        Global.ResumeGame();
    }

}
