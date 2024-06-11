using DsUi;
using Godot;
using GTweens.Easings;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.GearLibrary;

public partial class GearLibraryPanel : GearLibrary
{
    private enum Page
    {
        Home,
        UpGrade,
        UiSkin,
        Animation,
        Gear,
    }

    public override void _Ready()
    {
        S_HomeBtn.Instance.Pressed += () => ChangePageTo(Page.Home);
        S_UpgradeBtn.Instance.Pressed += () => ChangePageTo(Page.UpGrade);
        S_UiSkinBtn.Instance.Pressed += () => ChangePageTo(Page.UiSkin);
        S_AnimationBtn.Instance.Pressed += () => ChangePageTo(Page.Animation);
        S_GearBtn.Instance.Pressed += () => ChangePageTo(Page.Gear);

        S_CloseBtn.Instance.Pressed += OpenPrevUi;
    }

    private void ChangePageTo(Page page)
    {
        var instance = L_VBoxContainer.L_Content.L_Content.Instance;
        
        instance.TweenModulateAlpha(0f, 0.1f)
            .SetEasing(Easing.OutCubic)
            .OnComplete(() =>
            {
                instance.CurrentTab = (int)page;
                instance
                    .TweenModulateAlpha(1f, 0.1f)
                    .SetEasing(Easing.OutCubic)
                    .Play();
            })
            .Play();
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
