using System;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.AbilityItem;

public partial class AbilityItemPanel : AbilityItem
{
    public IItemInfo Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateUi();
        }
    }
    public event Action<IItemInfo> OnAbilitySelected;
    
    private IItemInfo _item;
    
    public override void OnCreateUi()
    {
        S_Button.Instance.Pressed += () =>
        {
            OnAbilitySelected?.Invoke(Item);
        };
        ShowUi();
        UpdateUi();
    }

    private void UpdateUi()
    {
        if (Item == null) return;
        if (!Wizard.FileExists(Item.IconPath)) return;
        S_IconTexture.Instance.Texture = GD.Load<Texture2D>(Item.IconPath);
        
        if (!Wizard.FileExists(Item.IconPath2)) return;
        S_IconTexture.Instance.Texture = GD.Load<Texture2D>(Item.IconPath2);
    }

    public override void OnDestroyUi()
    {
        
    }

}
