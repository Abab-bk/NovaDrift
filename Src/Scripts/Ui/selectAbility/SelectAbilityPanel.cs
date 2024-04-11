using DsUi;
using Godot;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.AbilityItem;
using NovaDrift.Scripts.Ui.AbilityPanel;

namespace NovaDrift.Scripts.Ui.SelectAbility;

public partial class SelectAbilityPanel : SelectAbility
{
    private AbilityPanelPanel _abilityPanel;
    
    public override void OnCreateUi()
    {
        _abilityPanel = L_Content.L_Content.L_AbilityPanel.Instance;
    }
    
    private void GenerateAbilityPanel(AbilityGenerateConfig config)
    {
        // 生成 Abilities Item
        for (int i = 0; i < config.Count; i++)
        {
            Ability ability = DataBuilder.BuildAbilityById(DataBuilder.GetRandomAbilityId());
            S_Abilities.OpenNestedUi<AbilityItemPanel>(UiManager.UiName.AbilityItem);
        }
    }
    
    public override void OnDestroyUi()
    {
        
    }

}
