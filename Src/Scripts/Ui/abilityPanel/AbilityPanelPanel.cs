using System;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityPanel;

public partial class AbilityPanelPanel : AbilityPanel
{
    public event Action OnClickYesBtn;
    
    public override void OnCreateUi()
    {
    }

    public override void _Ready()
    {
        S_YesBtn.Instance.Pressed += () => OnClickYesBtn?.Invoke();
    }

    public void UpdateUi(IItemInfo item)
    {
        S_AbilityTitle.Instance.Text = item.Name;
        S_AbilityDesc.Instance.Text = item.Desc;
    }
    
    public override void OnDestroyUi()
    {
        
    }

}
