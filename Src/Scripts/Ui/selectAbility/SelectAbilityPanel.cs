using DsUi;
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
        
        GenerateAbilityPanel(new AbilityGenerateConfig());
        OnAbilitySelected(S_ItemRow2.Instance.GetChild(0) as AbilityItemPanel);
        S_Indicator.Instance.Hide();
    }

    private void GenerateAbilityPanel(AbilityGenerateConfig config)
    {
        void GenerateAbility(IItemInfo itemInfo, AbilityItemPanel abilityItem)
        {
            abilityItem.Item = itemInfo;
            abilityItem.OnAbilitySelected += _ => { OnAbilitySelected(abilityItem); };
        }

        if (Global.Player.Stats.Body.Id == 1000)
        {
            for (int i = 0; i < 3; i++)
            {
                GenerateAbility(
                    DataBuilder.BuildBodyById(config.SelectBodyId()),
                    S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem));
            }
            return;
        }
        
        if (Global.Player.Shooter.Weapon.Id == 1000)
        {
            for (int i = 0; i < 3; i++)
            {
                GenerateAbility(
                    DataBuilder.BuildWeaponById(config.SelectWeaponId()),
                    S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem));
            }
            return;
        }
        
        if (Global.Player.Shield.Shield.Id == 1000)
        {
            for (int i = 0; i < 3; i++)
            {
                GenerateAbility(
                    DataBuilder.BuildShieldById(config.SelectShieldId()),
                    S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem));
            }
            return;
        }

        // 生成 Items
        for (int i = 0; i < 2; i++)
        {
            GenerateAbility(
                DataBuilder.BuildAbilityById(config.SelectAbilityId()),
                S_ItemRow1.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem));
        }

        for (int i = 0; i < 3; i++)
        {
            GenerateAbility(
                DataBuilder.BuildAbilityById(config.SelectAbilityId()),
                S_ItemRow2.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem));   
        }
        
        for (int i = 0; i < 2; i++)
        {
            var abilityItem = S_ItemRow3.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);

            switch (config.ItemTypes.Next())
            {
                case AbilityGenerateConfig.ItemType.Body:
                    abilityItem.Item = DataBuilder.BuildBodyById(config.SelectBodyId());
                    break;
                case AbilityGenerateConfig.ItemType.Weapon:
                    abilityItem.Item = DataBuilder.BuildWeaponById(config.SelectWeaponId());
                    break;
                case AbilityGenerateConfig.ItemType.Ability:
                    abilityItem.Item = DataBuilder.BuildAbilityById(config.SelectAbilityId());
                    break;
                case AbilityGenerateConfig.ItemType.Shield:
                    abilityItem.Item = DataBuilder.BuildShieldById(config.SelectShieldId());
                    break;
            }

            abilityItem.OnAbilitySelected += _ => { OnAbilitySelected(abilityItem); };
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
        
        if (item is Ability ability)
        {
            S_AbilityTree.Instance.ShowUi();
            S_AbilityTree.Instance.UpdateUi(ability);
        }
        else
        {
            S_AbilityTree.Instance.HideUi();
        }
    }

    public override void OnDestroyUi()
    {
        Global.ResumeGame();
    }

}
