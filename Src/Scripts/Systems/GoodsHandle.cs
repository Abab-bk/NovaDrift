using cfg;
using cfg.DataBase;

namespace NovaDrift.Scripts.Systems;

public static class GoodsHandle
{
    public static void GetReward(StoreInfo storeInfo)
    {
        switch (storeInfo.Type)
        {
            case GoodsType.SpawnAnimation:
                break;
            case GoodsType.DieAnimation:
                break;
            case GoodsType.WeaponSkin:
                break;
            case GoodsType.ShieldSkin:
                break;
            case GoodsType.BodySkin:
                break;
            case GoodsType.Upgrade:
                DataBuilder.UnlockAbilityTreeId(storeInfo.Value);
                break;
            case GoodsType.UiSkin:
                break;
        }
    }
}