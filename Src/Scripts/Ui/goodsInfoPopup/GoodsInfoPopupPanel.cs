using System.Globalization;
using AcidWallStudio.AcidUtilities;
using cfg;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.GoodsInfoPopup;

public partial class GoodsInfoPopupPanel : GoodsInfoPopup
{
    private StoreInfo _storeInfo;
    
    public override void _Ready()
    {
        S_Content.Instance.Modulate = S_Content.Instance.Modulate with { A = 0f };
        L_PanelContainer.Instance.Scale = new Vector2(0, 1);

        var cancelAnimation = GTweenSequenceBuilder.New()
            .Append(L_PanelContainer.Instance.TweenScale(new Vector2(0, 1), 0.5f))
            .Join(S_Content.Instance.TweenModulateAlpha(0f, 0.2f))
            .AppendCallback(QueueFree)
            .Build();
        
        GTweenSequenceBuilder.New()
            .Append(L_PanelContainer.Instance.TweenScale(Vector2.One, 0.2f))
                .Join(S_Content.Instance.TweenModulateAlpha(1f, 0.2f))
            .Build()
            .Play();

        S_CloseBtn.Instance.Pressed += () =>
        {
            cancelAnimation.Play();
        };

        S_BuyBtn.Instance.Pressed += () =>
        {
            var price = _storeInfo.Price;
            
            if (DataBuilder.StoreModifiers.TryGetValue(_storeInfo.Id, out var value))
            {
                price = (int)(_storeInfo.Price * value.Discount);
            }

            if (Global.AcidCoins < price) return;
            Global.AcidCoins -= price;
            
            GoodsHandle.GetReward(_storeInfo);
            
            cancelAnimation.Play();
        };
    }

    public void SetGoods(StoreInfo storeInfo)
    {
        _storeInfo = storeInfo;
        S_NameLabel.Instance.Text = storeInfo.Name;

        S_PriceLabel.Instance.Text = storeInfo.Price.ToString();
        if (DataBuilder.StoreModifiers.TryGetValue(storeInfo.Id, out var modifier))
        {
            S_PriceLabel.Instance.Text = (storeInfo.Price * modifier.Discount).ToString(CultureInfo.CurrentCulture);
        }

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
