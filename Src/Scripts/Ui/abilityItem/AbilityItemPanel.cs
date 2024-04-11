using System;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityItem;

public partial class AbilityItemPanel : AbilityItem
{
    public Ability Ability;
    public event Action<Ability> OnAbilitySelected;
    
    public override void OnCreateUi()
    {
        S_Button.Instance.Pressed += () =>
        {
            OnAbilitySelected?.Invoke(Ability);
        };
        ShowUi();
    }

    public override void OnDestroyUi()
    {
        
    }

}
