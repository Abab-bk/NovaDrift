using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityTree;

public partial class AbilityTreePanel : AbilityTree
{
    private Color _lockedColor = new Color("3d3d3d");
    
    public override void OnCreateUi()
    {
        
    }

    public void UpdateUi(Ability ability)
    {
        if (ability == null) return;
        ShowUi();
        
        Systems.AbilityTree abilityTree = ability.Tree;
        
        S_StartAbility.Instance.UpdateUiById(abilityTree.StartAbilityId);
        S_MiddleAbility1.Instance.UpdateUiById(abilityTree.MiddleAbilityIds[0]);
        S_MiddleAbility2.Instance.UpdateUiById(abilityTree.MiddleAbilityIds[1]);
        S_EndAbility.Instance.UpdateUiById(abilityTree.EndAbilityId);

        S_StartAbility.Instance.Modulate = Colors.White;
        S_MiddleAbility1.Instance.Modulate = Colors.White;
        S_MiddleAbility2.Instance.Modulate = Colors.White;
        S_EndAbility.Instance.Modulate = Colors.White;
        
        if (ability.Id == abilityTree.StartAbilityId)
        {
            S_MiddleAbility1.Instance.Modulate = _lockedColor;
            S_MiddleAbility2.Instance.Modulate = _lockedColor;
            S_EndAbility.Instance.Modulate = _lockedColor;
        } else if (ability.Id == abilityTree.MiddleAbilityIds[0])
        {
            S_EndAbility.Instance.Modulate = _lockedColor;
        } else if (ability.Id == abilityTree.MiddleAbilityIds[1])
        {
            S_EndAbility.Instance.Modulate = _lockedColor;
        }
    }

    public override void OnDestroyUi()
    {
        
    }

}
