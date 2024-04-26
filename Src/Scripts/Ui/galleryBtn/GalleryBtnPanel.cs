using System;
using Godot;

namespace NovaDrift.Scripts.Ui.GalleryBtn;

public partial class GalleryBtnPanel : GalleryBtn
{
    [Export] string _labelText = "GalleryBtnPanel";
    
    public Action OnClick;
    
    public override void _Ready()
    {
        S_Label.Instance.Text = _labelText;
        ChangeOverrideToNormal();
        
        MouseEntered += ChangeOverrideToSelected;
        MouseExited += ChangeOverrideToNormal;
        S_Button.Instance.ButtonDown += ChangeOverrideToSelected;
        S_Button.Instance.ButtonUp += ChangeOverrideToNormal;
        S_Button.Instance.Pressed += () => { OnClick?.Invoke(); };
    }

    public override void OnCreateUi()
    {
    }

    private void ChangeOverrideToSelected()
    {
        S_Background.Instance.RemoveThemeStyleboxOverride("panel");
        S_Background.Instance.AddThemeStyleboxOverride("panel", GD.Load<StyleBox>("res://Assets/StyleBoxes/GalleryBtnPressed.tres"));
    }

    private void ChangeOverrideToNormal()
    {
        S_Background.Instance.RemoveThemeStyleboxOverride("panel");
        S_Background.Instance.AddThemeStyleboxOverride("panel", GD.Load<StyleBox>("res://Assets/StyleBoxes/GalleryBtn.tres"));
    }

    public override void OnDestroyUi()
    {
        
    }

}
