using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityPanel;

public partial class AbilityPanelPanel : AbilityPanel
{
    private Label _title;
    private Label _desc;
    
    public override void OnCreateUi()
    {
        _title = L_Content.L_AbilityTitle.Instance;
        _desc = L_Content.L_AbilityDesc.Instance;
    }

    public void UpdateUi(Ability ability)
    {
        _title.Text = ability.Name;
        _desc.Text = ability.Desc;
    }
    
    public override void OnDestroyUi()
    {
        
    }

}
