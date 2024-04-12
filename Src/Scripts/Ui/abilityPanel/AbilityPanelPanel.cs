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
    
    public void UpdateUi(IItemInfo item)
    {
        _title.Text = item.Name;
        _desc.Text = item.Desc;
    }
    
    public override void OnDestroyUi()
    {
        
    }

}
