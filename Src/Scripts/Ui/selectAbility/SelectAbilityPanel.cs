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
    
    private Ability _currentAbility;
    private Weapon _currentWeapon;
    
    public override void OnCreateUi()
    {
        _abilityPanel = S_AbilityPanel.Instance;
        S_YesBtn.Instance.Pressed += () =>
        {
            if (_currentAbility == null)
            {
                _currentWeapon.Use();
                Destroy();
                return;
            }
            
            _currentAbility.Use();
            Destroy();
        };
        
        GenerateAbilityPanel(new AbilityGenerateConfig(5));
    }
    
    private void GenerateAbilityPanel(AbilityGenerateConfig config)
    {
        // 生成 Abilities Item
        for (int i = 0; i < config.Count; i++)
        {
            Ability ability;
            Weapon weapon;
            
            var abilityItem = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
            
            if (Random.Shared.NextDouble() > 0.5)
            {
                ability = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
                abilityItem.Item = ability;
            }
            else
            {
                weapon = DataBuilder.BuildWeaponById(DataBuilder.GetRandomWeaponId());
                abilityItem.Item = weapon;
            }
            
            abilityItem.OnAbilitySelected += item =>
            {
                _abilityPanel.UpdateUi(item);
                if (item is Ability ability1)
                {
                    _currentAbility = ability1;
                    _currentWeapon = null;
                }

                if (item is Weapon weapon)
                {
                    _currentWeapon = weapon;
                    _currentAbility = null;
                }
            };
        }
    }
    
    public override void OnDestroyUi()
    {
        Global.ResumeGame();
    }

}
