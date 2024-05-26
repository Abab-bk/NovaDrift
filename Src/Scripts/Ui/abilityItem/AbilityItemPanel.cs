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
    private Color _pressedColor = new Color("9c9c9c");
    
    public override void OnCreateUi()
    {
        S_Button.Instance.Pressed += () =>
        {
            OnAbilitySelected?.Invoke(Item);
        };

        S_Button.Instance.ButtonDown += () => { S_IconTexture.Instance.Modulate = _pressedColor; };
        S_Button.Instance.ButtonUp += () => { S_IconTexture.Instance.Modulate = Colors.White; };
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

    public void UpdateUiById(int id)
    {
        S_IconTexture.Instance.Texture = GD.Load<Texture2D>(
            ResourceLoader.Exists($"res://Assets/Ui/Icons/AbilityIcons/{DataBuilder.Tables.TbAbility.Get(id).ClassName}.tres")
                ? $"res://Assets/Ui/Icons/AbilityIcons/{DataBuilder.Tables.TbAbility.Get(id).ClassName}.tres"
                : "res://Assets/Ui/Icons/AbilityIcons/TestIcon.tres"
            );
    }

    public override void OnDestroyUi()
    {
        
    }

}
