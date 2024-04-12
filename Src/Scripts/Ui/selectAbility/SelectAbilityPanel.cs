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
    
    public override void OnCreateUi()
    {
        _abilityPanel = S_AbilityPanel.Instance;
        S_YesBtn.Instance.Pressed += () =>
        {
            if (_currentAbility == null) return;
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
            Ability ability = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
            var abilityItem = S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
            abilityItem.Ability = ability;
            abilityItem.OnAbilitySelected += ability1 =>
            {
                _abilityPanel.UpdateUi(ability1);
                _currentAbility = ability1;
            };
        }
    }
    
    public override void OnDestroyUi()
    {
        Global.ResumeGame();
    }

}
