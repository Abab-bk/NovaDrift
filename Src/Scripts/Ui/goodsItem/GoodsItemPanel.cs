using System.Globalization;
using AcidWallStudio.AcidUtilities;
using cfg;
using cfg.DataBase;
using DsUi;
using Godot;

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
            var panel = UiManager.Open_GoodsInfoPopup();
            panel.ShowUi();
            panel.SetGoods(info);
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
