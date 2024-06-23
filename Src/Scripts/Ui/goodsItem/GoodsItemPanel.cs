using System.Globalization;
using AcidWallStudio.AcidUtilities;
using cfg;
using cfg.DataBase;
using DsUi;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.GoodsItem;

public partial class GoodsItemPanel : GoodsItem
{
    [Export] private int _id;
    [Export] private bool _showPrice = true;

    public override void _Ready()
    {
        var info = DataBuilder.Tables.TbStoreInfo.Get(_id);
        if (info == null) return;
        S_TypeLabel.Instance.Text = info.Type switch
        {
            GoodsType.SpawnAnimation => "出生动画",
            GoodsType.DieAnimation => "死亡动画",
            GoodsType.WeaponSkin => "武器皮肤",
            GoodsType.ShieldSkin => "护盾皮肤",
            GoodsType.BodySkin => "飞船皮肤",
            GoodsType.UiSkin => "UI 皮肤",
            GoodsType.Upgrade => "升级模块",
            _ => "其他"
        };
        S_NameLabel.Instance.Text = info.Name;
        S_PriceLabel.Instance.Text = info.Price.ToString();
        
        S_DiscountLabel.Instance.Hide();
        S_PriceContainer.Instance.Visible = _showPrice;

        if (DataBuilder.StoreModifiers.TryGetValue(_id, out var modifier))  SetModifier(modifier, info);

        if (Wizard.FileExists($"res://Assets/Ui/StoreImages/{info.IconName}.png"))
        {
            S_Image.Instance.Texture = GD.Load<Texture2D>($"res://Assets/Ui/StoreImages/{info.IconName}.png");
        }

        S_Button.Instance.Pressed += () =>
        {
            // var panel = UiManager.Open_GoodsInfoPopup();
            // panel.ShowUi();
            // panel.SetGoods(info);

            var price = info.Price;
            
            if (DataBuilder.StoreModifiers.TryGetValue(info.Id, out var value))
            {
                price = (int)(info.Price * value.Discount);
            }
            
            UiManager.Open_Popup()
                .SetConfig(
                    "购买物品",
                    $"""
                     是否购买 {info.Name} ?
                     这将花费 {price} 酸酸币
                     """,
                    true,
                    () => { },
                    () =>
                    {
                        if (Global.AcidCoins < price)
                        {
                            UiManager
                                .Open_Popup()
                                .SetConfig(
                                    "购买失败",
                                    "酸酸币不足，无法购买"
                                    );
                            return;
                        }
                        Global.AcidCoins -= price;
                        GoodsHandle.GetReward(info);
                        
                        UiManager
                            .Open_Popup()
                            .SetConfig(
                                "购买成功",
                                $"{info.Name} 购买成功",
                                false,
                                null,
                                () =>
                                {
                                    var vfx = GD.Load<PackedScene>("res://Scenes/Vfx/GetNewItemVfx.tscn")
                                        .Instantiate<Node2D>();
                                    UiManager.GetUiLayer(UiLayer.Pop).AddChild(vfx);
                                }
                            );
                    }
                    );
            
        };
    }

    public void SetModifier(StoreModifier modifier, StoreInfo info)
    {
        if (modifier.Discount <= 0) return;
        S_PriceContainer.Instance.Show();
        S_DiscountLabel.Instance.Show();
        S_DiscountLabel.Instance.Text = info.Price.ToString();
        S_PriceLabel.Instance.Text = (info.Price * modifier.Discount).ToString(CultureInfo.CurrentCulture);
    }

    public override void OnCreateUi()
    {
    }

    public override void OnDestroyUi()
    {
    }

}
