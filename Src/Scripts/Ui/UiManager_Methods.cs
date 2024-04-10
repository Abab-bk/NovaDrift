namespace DsUi;

// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失
public static partial class UiManager
{

    public static class UiName
    {
        public const string Hud = "Hud";
        public const string SelectAbility = "SelectAbility";
    }

    /// <summary>
    /// 创建 Hud, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Hud.HudPanel Create_Hud()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Hud.HudPanel>(UiName.Hud);
    }

    /// <summary>
    /// 打开 Hud, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Hud.HudPanel Open_Hud()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Hud.HudPanel>(UiName.Hud);
    }

    /// <summary>
    /// 隐藏 Hud 的所有实例
    /// </summary>
    public static void Hide_Hud()
    {
        var uiInstance = Get_Hud_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Hud 的所有实例
    /// </summary>
    public static void Destroy_Hud()
    {
        var uiInstance = Get_Hud_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Hud 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Hud.HudPanel[] Get_Hud_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Hud.HudPanel>(nameof(NovaDrift.Scripts.Ui.Hud.Hud));
    }

    /// <summary>
    /// 创建 SelectAbility, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.SelectAbility.SelectAbilityPanel Create_SelectAbility()
    {
        return CreateUi<NovaDrift.Scripts.Ui.SelectAbility.SelectAbilityPanel>(UiName.SelectAbility);
    }

    /// <summary>
    /// 打开 SelectAbility, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.SelectAbility.SelectAbilityPanel Open_SelectAbility()
    {
        return OpenUi<NovaDrift.Scripts.Ui.SelectAbility.SelectAbilityPanel>(UiName.SelectAbility);
    }

    /// <summary>
    /// 隐藏 SelectAbility 的所有实例
    /// </summary>
    public static void Hide_SelectAbility()
    {
        var uiInstance = Get_SelectAbility_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 SelectAbility 的所有实例
    /// </summary>
    public static void Destroy_SelectAbility()
    {
        var uiInstance = Get_SelectAbility_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 SelectAbility 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.SelectAbility.SelectAbilityPanel[] Get_SelectAbility_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.SelectAbility.SelectAbilityPanel>(nameof(NovaDrift.Scripts.Ui.SelectAbility.SelectAbility));
    }

}
