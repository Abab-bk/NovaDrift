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
        S_YesBtn.Instance.Pressed += () =>
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
            S_Gears.Instance.Visible = true;
            for (int i = 0; i < 3; i++)
            {
                var abilityItem = S_Gears.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
                abilityItem.Item = DataBuilder.BuildBodyById(DataBuilder.GetRandomBodyId());
                
                abilityItem.OnAbilitySelected += (IItemInfo item) =>
                {
                    _abilityPanel.UpdateUi(item);
                    _currentItem = item;
                };
            }
            return;
        }
        
        if (Global.Player.Shooter.Weapon.Id == 1000)
        {
            S_Gears.Instance.Visible = true;
            for (int i = 0; i < 3; i++)
            {
                var abilityItem = S_Gears.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
                abilityItem.Item = DataBuilder.BuildWeaponById(DataBuilder.GetRandomWeaponId());
                
                abilityItem.OnAbilitySelected += (IItemInfo item) =>
                {
                    _abilityPanel.UpdateUi(item);
                    _currentItem = item;
                };
            }
            return;
        }
        
        // 生成 Items
        for (int i = 0; i < config.Count; i++)
        {
            var abilityItem = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);

            abilityItem.Item = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
            
            abilityItem.OnAbilitySelected += (IItemInfo item) =>
            {
                _abilityPanel.UpdateUi(item);
                _currentItem = item;
            };
        }
        
        for (int i = 0; i < 3; i++)
        {
            var abilityItem = S_Gears.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);

            switch (i)
            {
                case 0:
                    abilityItem.Item = DataBuilder.BuildBodyById(DataBuilder.GetRandomBodyId());
                    break;
                case 1:
                    abilityItem.Item = DataBuilder.BuildWeaponById(DataBuilder.GetRandomWeaponId());
                    break;
                case 2:
                    abilityItem.Item = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
                    break;
            }
            
            abilityItem.OnAbilitySelected += (IItemInfo item) =>
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
