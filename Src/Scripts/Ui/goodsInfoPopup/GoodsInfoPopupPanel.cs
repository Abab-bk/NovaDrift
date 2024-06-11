using AcidWallStudio.AcidUtilities;
using cfg;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.GoodsInfoPopup;

public partial class GoodsInfoPopupPanel : GoodsInfoPopup
{
    public override void _Ready()
    {
        S_Content.Instance.Modulate = S_Content.Instance.Modulate with { A = 0f };
        L_PanelContainer.Instance.Scale = new Vector2(0, 1);
        
        GTweenSequenceBuilder.New()
            .Append(L_PanelContainer.Instance.TweenScale(Vector2.One, 0.2f))
                .Join(S_Content.Instance.TweenModulateAlpha(1f, 0.2f))
            .Build()
            .Play();

        S_CloseBtn.Instance.Pressed += () =>
        {
            GTweenSequenceBuilder.New()
                .Append(L_PanelContainer.Instance.TweenScale(new Vector2(0, 1), 0.2f))
                    .Join(S_Content.Instance.TweenModulateAlpha(0f, 0.2f))
                .AppendCallback(QueueFree)
                .Build()
                .Play();
        };
    }

    public void SetGoods(StoreInfo storeInfo)
    {
        S_NameLabel.Instance.Text = storeInfo.Name;
        if (Wizard.FileExists($"res://Assets/Ui/StoreImages/{storeInfo.IconName}.png"))
        {
            S_Icon.Instance.Texture = GD.Load<Texture2D>($"res://Assets/Ui/StoreImages/{storeInfo.IconName}.png");
        }
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
