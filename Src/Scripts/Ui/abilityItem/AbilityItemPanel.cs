using System;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityItem;

public partial class AbilityItemPanel : AbilityItem
{
    public IItemInfo Item;
    public event Action<IItemInfo> OnAbilitySelected;
    
    public override void OnCreateUi()
    {
        S_Button.Instance.Pressed += () =>
        {
            OnAbilitySelected?.Invoke(Item);
        };
        ShowUi();
    }

    public override void OnDestroyUi()
    {
        
    }

}
