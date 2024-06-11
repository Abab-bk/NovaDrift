using AcidWallStudio.AcidUtilities;
using cfg.DataBase;
using Godot;

namespace NovaDrift.Scripts.Ui.GoodsItem;

public partial class GoodsItemPanel : GoodsItem
{
    [Export] private int _id;

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
        if (Wizard.FileExists($"res://Assets/Ui/StoreImages/{info.IconName}.png"))
        {
            S_Image.Instance.Texture = GD.Load<Texture2D>($"res://Assets/Ui/StoreImages/{info.IconName}.png");
        }
    }

    public override void OnCreateUi()
    {
    }

    public override void OnDestroyUi()
    {
    }

}
