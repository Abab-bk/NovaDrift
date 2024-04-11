using System;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityItem;

public partial class AbilityItemPanel : AbilityItem
{
    private Ability _ability;
    public event Action<Ability> OnAbilitySelected;
    
    public override void OnCreateUi()
    {
        S_Button.Instance.Pressed += () =>
        {
            OnAbilitySelected?.Invoke(_ability);
        };
    }

    public override void OnDestroyUi()
    {
        
    }

}
