namespace DsUi;

// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失
public static partial class UiManager
{

    public static class UiName
    {
        public const string AbilityItem = "AbilityItem";
        public const string AbilityPanel = "AbilityPanel";
        public const string AbilityTree = "AbilityTree";
        public const string ActionBtn = "ActionBtn";
        public const string AnimationProgressBar = "AnimationProgressBar";
        public const string BuffIcon = "BuffIcon";
        public const string ColorBlindMode1 = "ColorBlindMode1";
        public const string ColorBlindMode2 = "ColorBlindMode2";
        public const string ColorBlindMode3 = "ColorBlindMode3";
        public const string Credit = "Credit";
        public const string DailyQuests = "DailyQuests";
        public const string DamageLabel = "DamageLabel";
        public const string GalleryBtn = "GalleryBtn";
        public const string GameOver = "GameOver";
        public const string GearLibrary = "GearLibrary";
        public const string GoodsDetails = "GoodsDetails";
        public const string GoodsInfoPopup = "GoodsInfoPopup";
        public const string GoodsItem = "GoodsItem";
        public const string Hud = "Hud";
        public const string Loading = "Loading";
        public const string PausedMenu = "PausedMenu";
        public const string Popup = "Popup";
        public const string PowerUpBtn = "PowerUpBtn";
        public const string QuestItem = "QuestItem";
        public const string Relife = "Relife";
        public const string SalvoBulletCount = "SalvoBulletCount";
        public const string ScoreItem = "ScoreItem";
        public const string ScoreLabel = "ScoreLabel";
        public const string SelectAbility = "SelectAbility";
        public const string Setting = "Setting";
        public const string Slogan = "Slogan";
        public const string StartMenu = "StartMenu";
        public const string StatMonitorLabel = "StatMonitorLabel";
        public const string StatsMonitor = "StatsMonitor";
        public const string StatsMonitorItem = "StatsMonitorItem";
        public const string Tip = "Tip";
    }

    /// <summary>
    /// 创建 AbilityItem, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel Create_AbilityItem()
    {
        return CreateUi<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>(UiName.AbilityItem);
    }

    /// <summary>
    /// 打开 AbilityItem, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel Open_AbilityItem()
    {
        return OpenUi<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>(UiName.AbilityItem);
    }

    /// <summary>
    /// 隐藏 AbilityItem 的所有实例
    /// </summary>
    public static void Hide_AbilityItem()
    {
        var uiInstance = Get_AbilityItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 AbilityItem 的所有实例
    /// </summary>
    public static void Destroy_AbilityItem()
    {
        var uiInstance = Get_AbilityItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 AbilityItem 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel[] Get_AbilityItem_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>(nameof(NovaDrift.Scripts.Ui.AbilityItem.AbilityItem));
    }

    /// <summary>
    /// 创建 AbilityPanel, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel Create_AbilityPanel()
    {
        return CreateUi<NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel>(UiName.AbilityPanel);
    }

    /// <summary>
    /// 打开 AbilityPanel, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel Open_AbilityPanel()
    {
        return OpenUi<NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel>(UiName.AbilityPanel);
    }

    /// <summary>
    /// 隐藏 AbilityPanel 的所有实例
    /// </summary>
    public static void Hide_AbilityPanel()
    {
        var uiInstance = Get_AbilityPanel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 AbilityPanel 的所有实例
    /// </summary>
    public static void Destroy_AbilityPanel()
    {
        var uiInstance = Get_AbilityPanel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 AbilityPanel 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel[] Get_AbilityPanel_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel>(nameof(NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanel));
    }

    /// <summary>
    /// 创建 AbilityTree, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel Create_AbilityTree()
    {
        return CreateUi<NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel>(UiName.AbilityTree);
    }

    /// <summary>
    /// 打开 AbilityTree, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel Open_AbilityTree()
    {
        return OpenUi<NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel>(UiName.AbilityTree);
    }

    /// <summary>
    /// 隐藏 AbilityTree 的所有实例
    /// </summary>
    public static void Hide_AbilityTree()
    {
        var uiInstance = Get_AbilityTree_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 AbilityTree 的所有实例
    /// </summary>
    public static void Destroy_AbilityTree()
    {
        var uiInstance = Get_AbilityTree_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 AbilityTree 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel[] Get_AbilityTree_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel>(nameof(NovaDrift.Scripts.Ui.AbilityTree.AbilityTree));
    }

    /// <summary>
    /// 创建 ActionBtn, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.ActionBtn.ActionBtnPanel Create_ActionBtn()
    {
        return CreateUi<NovaDrift.Scripts.Ui.ActionBtn.ActionBtnPanel>(UiName.ActionBtn);
    }

    /// <summary>
    /// 打开 ActionBtn, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.ActionBtn.ActionBtnPanel Open_ActionBtn()
    {
        return OpenUi<NovaDrift.Scripts.Ui.ActionBtn.ActionBtnPanel>(UiName.ActionBtn);
    }

    /// <summary>
    /// 隐藏 ActionBtn 的所有实例
    /// </summary>
    public static void Hide_ActionBtn()
    {
        var uiInstance = Get_ActionBtn_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 ActionBtn 的所有实例
    /// </summary>
    public static void Destroy_ActionBtn()
    {
        var uiInstance = Get_ActionBtn_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 ActionBtn 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.ActionBtn.ActionBtnPanel[] Get_ActionBtn_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.ActionBtn.ActionBtnPanel>(nameof(NovaDrift.Scripts.Ui.ActionBtn.ActionBtn));
    }

    /// <summary>
    /// 创建 AnimationProgressBar, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel Create_AnimationProgressBar()
    {
        return CreateUi<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>(UiName.AnimationProgressBar);
    }

    /// <summary>
    /// 打开 AnimationProgressBar, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel Open_AnimationProgressBar()
    {
        return OpenUi<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>(UiName.AnimationProgressBar);
    }

    /// <summary>
    /// 隐藏 AnimationProgressBar 的所有实例
    /// </summary>
    public static void Hide_AnimationProgressBar()
    {
        var uiInstance = Get_AnimationProgressBar_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 AnimationProgressBar 的所有实例
    /// </summary>
    public static void Destroy_AnimationProgressBar()
    {
        var uiInstance = Get_AnimationProgressBar_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 AnimationProgressBar 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel[] Get_AnimationProgressBar_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>(nameof(NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBar));
    }

    /// <summary>
    /// 创建 BuffIcon, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.BuffIcon.BuffIconPanel Create_BuffIcon()
    {
        return CreateUi<NovaDrift.Scripts.Ui.BuffIcon.BuffIconPanel>(UiName.BuffIcon);
    }

    /// <summary>
    /// 打开 BuffIcon, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.BuffIcon.BuffIconPanel Open_BuffIcon()
    {
        return OpenUi<NovaDrift.Scripts.Ui.BuffIcon.BuffIconPanel>(UiName.BuffIcon);
    }

    /// <summary>
    /// 隐藏 BuffIcon 的所有实例
    /// </summary>
    public static void Hide_BuffIcon()
    {
        var uiInstance = Get_BuffIcon_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 BuffIcon 的所有实例
    /// </summary>
    public static void Destroy_BuffIcon()
    {
        var uiInstance = Get_BuffIcon_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 BuffIcon 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.BuffIcon.BuffIconPanel[] Get_BuffIcon_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.BuffIcon.BuffIconPanel>(nameof(NovaDrift.Scripts.Ui.BuffIcon.BuffIcon));
    }

    /// <summary>
    /// 创建 ColorBlindMode1, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1Panel Create_ColorBlindMode1()
    {
        return CreateUi<NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1Panel>(UiName.ColorBlindMode1);
    }

    /// <summary>
    /// 打开 ColorBlindMode1, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1Panel Open_ColorBlindMode1()
    {
        return OpenUi<NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1Panel>(UiName.ColorBlindMode1);
    }

    /// <summary>
    /// 隐藏 ColorBlindMode1 的所有实例
    /// </summary>
    public static void Hide_ColorBlindMode1()
    {
        var uiInstance = Get_ColorBlindMode1_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 ColorBlindMode1 的所有实例
    /// </summary>
    public static void Destroy_ColorBlindMode1()
    {
        var uiInstance = Get_ColorBlindMode1_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 ColorBlindMode1 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1Panel[] Get_ColorBlindMode1_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1Panel>(nameof(NovaDrift.Scripts.Ui.ColorBlindMode1.ColorBlindMode1));
    }

    /// <summary>
    /// 创建 ColorBlindMode2, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2Panel Create_ColorBlindMode2()
    {
        return CreateUi<NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2Panel>(UiName.ColorBlindMode2);
    }

    /// <summary>
    /// 打开 ColorBlindMode2, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2Panel Open_ColorBlindMode2()
    {
        return OpenUi<NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2Panel>(UiName.ColorBlindMode2);
    }

    /// <summary>
    /// 隐藏 ColorBlindMode2 的所有实例
    /// </summary>
    public static void Hide_ColorBlindMode2()
    {
        var uiInstance = Get_ColorBlindMode2_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 ColorBlindMode2 的所有实例
    /// </summary>
    public static void Destroy_ColorBlindMode2()
    {
        var uiInstance = Get_ColorBlindMode2_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 ColorBlindMode2 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2Panel[] Get_ColorBlindMode2_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2Panel>(nameof(NovaDrift.Scripts.Ui.ColorBlindMode2.ColorBlindMode2));
    }

    /// <summary>
    /// 创建 ColorBlindMode3, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3Panel Create_ColorBlindMode3()
    {
        return CreateUi<NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3Panel>(UiName.ColorBlindMode3);
    }

    /// <summary>
    /// 打开 ColorBlindMode3, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3Panel Open_ColorBlindMode3()
    {
        return OpenUi<NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3Panel>(UiName.ColorBlindMode3);
    }

    /// <summary>
    /// 隐藏 ColorBlindMode3 的所有实例
    /// </summary>
    public static void Hide_ColorBlindMode3()
    {
        var uiInstance = Get_ColorBlindMode3_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 ColorBlindMode3 的所有实例
    /// </summary>
    public static void Destroy_ColorBlindMode3()
    {
        var uiInstance = Get_ColorBlindMode3_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 ColorBlindMode3 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3Panel[] Get_ColorBlindMode3_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3Panel>(nameof(NovaDrift.Scripts.Ui.ColorBlindMode3.ColorBlindMode3));
    }

    /// <summary>
    /// 创建 Credit, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Credit.CreditPanel Create_Credit()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Credit.CreditPanel>(UiName.Credit);
    }

    /// <summary>
    /// 打开 Credit, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Credit.CreditPanel Open_Credit()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Credit.CreditPanel>(UiName.Credit);
    }

    /// <summary>
    /// 隐藏 Credit 的所有实例
    /// </summary>
    public static void Hide_Credit()
    {
        var uiInstance = Get_Credit_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Credit 的所有实例
    /// </summary>
    public static void Destroy_Credit()
    {
        var uiInstance = Get_Credit_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Credit 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Credit.CreditPanel[] Get_Credit_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Credit.CreditPanel>(nameof(NovaDrift.Scripts.Ui.Credit.Credit));
    }

    /// <summary>
    /// 创建 DailyQuests, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.DailyQuests.DailyQuestsPanel Create_DailyQuests()
    {
        return CreateUi<NovaDrift.Scripts.Ui.DailyQuests.DailyQuestsPanel>(UiName.DailyQuests);
    }

    /// <summary>
    /// 打开 DailyQuests, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.DailyQuests.DailyQuestsPanel Open_DailyQuests()
    {
        return OpenUi<NovaDrift.Scripts.Ui.DailyQuests.DailyQuestsPanel>(UiName.DailyQuests);
    }

    /// <summary>
    /// 隐藏 DailyQuests 的所有实例
    /// </summary>
    public static void Hide_DailyQuests()
    {
        var uiInstance = Get_DailyQuests_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 DailyQuests 的所有实例
    /// </summary>
    public static void Destroy_DailyQuests()
    {
        var uiInstance = Get_DailyQuests_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 DailyQuests 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.DailyQuests.DailyQuestsPanel[] Get_DailyQuests_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.DailyQuests.DailyQuestsPanel>(nameof(NovaDrift.Scripts.Ui.DailyQuests.DailyQuests));
    }

    /// <summary>
    /// 创建 DamageLabel, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.DamageLabel.DamageLabelPanel Create_DamageLabel()
    {
        return CreateUi<NovaDrift.Scripts.Ui.DamageLabel.DamageLabelPanel>(UiName.DamageLabel);
    }

    /// <summary>
    /// 打开 DamageLabel, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.DamageLabel.DamageLabelPanel Open_DamageLabel()
    {
        return OpenUi<NovaDrift.Scripts.Ui.DamageLabel.DamageLabelPanel>(UiName.DamageLabel);
    }

    /// <summary>
    /// 隐藏 DamageLabel 的所有实例
    /// </summary>
    public static void Hide_DamageLabel()
    {
        var uiInstance = Get_DamageLabel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 DamageLabel 的所有实例
    /// </summary>
    public static void Destroy_DamageLabel()
    {
        var uiInstance = Get_DamageLabel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 DamageLabel 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.DamageLabel.DamageLabelPanel[] Get_DamageLabel_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.DamageLabel.DamageLabelPanel>(nameof(NovaDrift.Scripts.Ui.DamageLabel.DamageLabel));
    }

    /// <summary>
    /// 创建 GalleryBtn, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel Create_GalleryBtn()
    {
        return CreateUi<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>(UiName.GalleryBtn);
    }

    /// <summary>
    /// 打开 GalleryBtn, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel Open_GalleryBtn()
    {
        return OpenUi<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>(UiName.GalleryBtn);
    }

    /// <summary>
    /// 隐藏 GalleryBtn 的所有实例
    /// </summary>
    public static void Hide_GalleryBtn()
    {
        var uiInstance = Get_GalleryBtn_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 GalleryBtn 的所有实例
    /// </summary>
    public static void Destroy_GalleryBtn()
    {
        var uiInstance = Get_GalleryBtn_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 GalleryBtn 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel[] Get_GalleryBtn_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>(nameof(NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtn));
    }

    /// <summary>
    /// 创建 GameOver, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.GameOver.GameOverPanel Create_GameOver()
    {
        return CreateUi<NovaDrift.Scripts.Ui.GameOver.GameOverPanel>(UiName.GameOver);
    }

    /// <summary>
    /// 打开 GameOver, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.GameOver.GameOverPanel Open_GameOver()
    {
        return OpenUi<NovaDrift.Scripts.Ui.GameOver.GameOverPanel>(UiName.GameOver);
    }

    /// <summary>
    /// 隐藏 GameOver 的所有实例
    /// </summary>
    public static void Hide_GameOver()
    {
        var uiInstance = Get_GameOver_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 GameOver 的所有实例
    /// </summary>
    public static void Destroy_GameOver()
    {
        var uiInstance = Get_GameOver_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 GameOver 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.GameOver.GameOverPanel[] Get_GameOver_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.GameOver.GameOverPanel>(nameof(NovaDrift.Scripts.Ui.GameOver.GameOver));
    }

    /// <summary>
    /// 创建 GearLibrary, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.GearLibrary.GearLibraryPanel Create_GearLibrary()
    {
        return CreateUi<NovaDrift.Scripts.Ui.GearLibrary.GearLibraryPanel>(UiName.GearLibrary);
    }

    /// <summary>
    /// 打开 GearLibrary, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.GearLibrary.GearLibraryPanel Open_GearLibrary()
    {
        return OpenUi<NovaDrift.Scripts.Ui.GearLibrary.GearLibraryPanel>(UiName.GearLibrary);
    }

    /// <summary>
    /// 隐藏 GearLibrary 的所有实例
    /// </summary>
    public static void Hide_GearLibrary()
    {
        var uiInstance = Get_GearLibrary_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 GearLibrary 的所有实例
    /// </summary>
    public static void Destroy_GearLibrary()
    {
        var uiInstance = Get_GearLibrary_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 GearLibrary 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.GearLibrary.GearLibraryPanel[] Get_GearLibrary_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.GearLibrary.GearLibraryPanel>(nameof(NovaDrift.Scripts.Ui.GearLibrary.GearLibrary));
    }

    /// <summary>
    /// 创建 GoodsDetails, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetailsPanel Create_GoodsDetails()
    {
        return CreateUi<NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetailsPanel>(UiName.GoodsDetails);
    }

    /// <summary>
    /// 打开 GoodsDetails, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetailsPanel Open_GoodsDetails()
    {
        return OpenUi<NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetailsPanel>(UiName.GoodsDetails);
    }

    /// <summary>
    /// 隐藏 GoodsDetails 的所有实例
    /// </summary>
    public static void Hide_GoodsDetails()
    {
        var uiInstance = Get_GoodsDetails_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 GoodsDetails 的所有实例
    /// </summary>
    public static void Destroy_GoodsDetails()
    {
        var uiInstance = Get_GoodsDetails_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 GoodsDetails 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetailsPanel[] Get_GoodsDetails_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetailsPanel>(nameof(NovaDrift.Scripts.Ui.GoodsDetails.GoodsDetails));
    }

    /// <summary>
    /// 创建 GoodsInfoPopup, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopupPanel Create_GoodsInfoPopup()
    {
        return CreateUi<NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopupPanel>(UiName.GoodsInfoPopup);
    }

    /// <summary>
    /// 打开 GoodsInfoPopup, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopupPanel Open_GoodsInfoPopup()
    {
        return OpenUi<NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopupPanel>(UiName.GoodsInfoPopup);
    }

    /// <summary>
    /// 隐藏 GoodsInfoPopup 的所有实例
    /// </summary>
    public static void Hide_GoodsInfoPopup()
    {
        var uiInstance = Get_GoodsInfoPopup_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 GoodsInfoPopup 的所有实例
    /// </summary>
    public static void Destroy_GoodsInfoPopup()
    {
        var uiInstance = Get_GoodsInfoPopup_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 GoodsInfoPopup 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopupPanel[] Get_GoodsInfoPopup_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopupPanel>(nameof(NovaDrift.Scripts.Ui.GoodsInfoPopup.GoodsInfoPopup));
    }

    /// <summary>
    /// 创建 GoodsItem, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel Create_GoodsItem()
    {
        return CreateUi<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>(UiName.GoodsItem);
    }

    /// <summary>
    /// 打开 GoodsItem, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel Open_GoodsItem()
    {
        return OpenUi<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>(UiName.GoodsItem);
    }

    /// <summary>
    /// 隐藏 GoodsItem 的所有实例
    /// </summary>
    public static void Hide_GoodsItem()
    {
        var uiInstance = Get_GoodsItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 GoodsItem 的所有实例
    /// </summary>
    public static void Destroy_GoodsItem()
    {
        var uiInstance = Get_GoodsItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 GoodsItem 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel[] Get_GoodsItem_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>(nameof(NovaDrift.Scripts.Ui.GoodsItem.GoodsItem));
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
    /// 创建 Loading, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Loading.LoadingPanel Create_Loading()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Loading.LoadingPanel>(UiName.Loading);
    }

    /// <summary>
    /// 打开 Loading, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Loading.LoadingPanel Open_Loading()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Loading.LoadingPanel>(UiName.Loading);
    }

    /// <summary>
    /// 隐藏 Loading 的所有实例
    /// </summary>
    public static void Hide_Loading()
    {
        var uiInstance = Get_Loading_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Loading 的所有实例
    /// </summary>
    public static void Destroy_Loading()
    {
        var uiInstance = Get_Loading_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Loading 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Loading.LoadingPanel[] Get_Loading_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Loading.LoadingPanel>(nameof(NovaDrift.Scripts.Ui.Loading.Loading));
    }

    /// <summary>
    /// 创建 PausedMenu, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.PausedMenu.PausedMenuPanel Create_PausedMenu()
    {
        return CreateUi<NovaDrift.Scripts.Ui.PausedMenu.PausedMenuPanel>(UiName.PausedMenu);
    }

    /// <summary>
    /// 打开 PausedMenu, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.PausedMenu.PausedMenuPanel Open_PausedMenu()
    {
        return OpenUi<NovaDrift.Scripts.Ui.PausedMenu.PausedMenuPanel>(UiName.PausedMenu);
    }

    /// <summary>
    /// 隐藏 PausedMenu 的所有实例
    /// </summary>
    public static void Hide_PausedMenu()
    {
        var uiInstance = Get_PausedMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 PausedMenu 的所有实例
    /// </summary>
    public static void Destroy_PausedMenu()
    {
        var uiInstance = Get_PausedMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 PausedMenu 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.PausedMenu.PausedMenuPanel[] Get_PausedMenu_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.PausedMenu.PausedMenuPanel>(nameof(NovaDrift.Scripts.Ui.PausedMenu.PausedMenu));
    }

    /// <summary>
    /// 创建 Popup, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Popup.PopupPanel Create_Popup()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Popup.PopupPanel>(UiName.Popup);
    }

    /// <summary>
    /// 打开 Popup, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Popup.PopupPanel Open_Popup()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Popup.PopupPanel>(UiName.Popup);
    }

    /// <summary>
    /// 隐藏 Popup 的所有实例
    /// </summary>
    public static void Hide_Popup()
    {
        var uiInstance = Get_Popup_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Popup 的所有实例
    /// </summary>
    public static void Destroy_Popup()
    {
        var uiInstance = Get_Popup_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Popup 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Popup.PopupPanel[] Get_Popup_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Popup.PopupPanel>(nameof(NovaDrift.Scripts.Ui.Popup.Popup));
    }

    /// <summary>
    /// 创建 PowerUpBtn, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtnPanel Create_PowerUpBtn()
    {
        return CreateUi<NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtnPanel>(UiName.PowerUpBtn);
    }

    /// <summary>
    /// 打开 PowerUpBtn, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtnPanel Open_PowerUpBtn()
    {
        return OpenUi<NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtnPanel>(UiName.PowerUpBtn);
    }

    /// <summary>
    /// 隐藏 PowerUpBtn 的所有实例
    /// </summary>
    public static void Hide_PowerUpBtn()
    {
        var uiInstance = Get_PowerUpBtn_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 PowerUpBtn 的所有实例
    /// </summary>
    public static void Destroy_PowerUpBtn()
    {
        var uiInstance = Get_PowerUpBtn_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 PowerUpBtn 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtnPanel[] Get_PowerUpBtn_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtnPanel>(nameof(NovaDrift.Scripts.Ui.PowerUpBtn.PowerUpBtn));
    }

    /// <summary>
    /// 创建 QuestItem, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.QuestItem.QuestItemPanel Create_QuestItem()
    {
        return CreateUi<NovaDrift.Scripts.Ui.QuestItem.QuestItemPanel>(UiName.QuestItem);
    }

    /// <summary>
    /// 打开 QuestItem, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.QuestItem.QuestItemPanel Open_QuestItem()
    {
        return OpenUi<NovaDrift.Scripts.Ui.QuestItem.QuestItemPanel>(UiName.QuestItem);
    }

    /// <summary>
    /// 隐藏 QuestItem 的所有实例
    /// </summary>
    public static void Hide_QuestItem()
    {
        var uiInstance = Get_QuestItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 QuestItem 的所有实例
    /// </summary>
    public static void Destroy_QuestItem()
    {
        var uiInstance = Get_QuestItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 QuestItem 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.QuestItem.QuestItemPanel[] Get_QuestItem_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.QuestItem.QuestItemPanel>(nameof(NovaDrift.Scripts.Ui.QuestItem.QuestItem));
    }

    /// <summary>
    /// 创建 Relife, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Relife.RelifePanel Create_Relife()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Relife.RelifePanel>(UiName.Relife);
    }

    /// <summary>
    /// 打开 Relife, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Relife.RelifePanel Open_Relife()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Relife.RelifePanel>(UiName.Relife);
    }

    /// <summary>
    /// 隐藏 Relife 的所有实例
    /// </summary>
    public static void Hide_Relife()
    {
        var uiInstance = Get_Relife_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Relife 的所有实例
    /// </summary>
    public static void Destroy_Relife()
    {
        var uiInstance = Get_Relife_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Relife 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Relife.RelifePanel[] Get_Relife_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Relife.RelifePanel>(nameof(NovaDrift.Scripts.Ui.Relife.Relife));
    }

    /// <summary>
    /// 创建 SalvoBulletCount, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCountPanel Create_SalvoBulletCount()
    {
        return CreateUi<NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCountPanel>(UiName.SalvoBulletCount);
    }

    /// <summary>
    /// 打开 SalvoBulletCount, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCountPanel Open_SalvoBulletCount()
    {
        return OpenUi<NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCountPanel>(UiName.SalvoBulletCount);
    }

    /// <summary>
    /// 隐藏 SalvoBulletCount 的所有实例
    /// </summary>
    public static void Hide_SalvoBulletCount()
    {
        var uiInstance = Get_SalvoBulletCount_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 SalvoBulletCount 的所有实例
    /// </summary>
    public static void Destroy_SalvoBulletCount()
    {
        var uiInstance = Get_SalvoBulletCount_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 SalvoBulletCount 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCountPanel[] Get_SalvoBulletCount_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCountPanel>(nameof(NovaDrift.Scripts.Ui.SalvoBulletCount.SalvoBulletCount));
    }

    /// <summary>
    /// 创建 ScoreItem, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.ScoreItem.ScoreItemPanel Create_ScoreItem()
    {
        return CreateUi<NovaDrift.Scripts.Ui.ScoreItem.ScoreItemPanel>(UiName.ScoreItem);
    }

    /// <summary>
    /// 打开 ScoreItem, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.ScoreItem.ScoreItemPanel Open_ScoreItem()
    {
        return OpenUi<NovaDrift.Scripts.Ui.ScoreItem.ScoreItemPanel>(UiName.ScoreItem);
    }

    /// <summary>
    /// 隐藏 ScoreItem 的所有实例
    /// </summary>
    public static void Hide_ScoreItem()
    {
        var uiInstance = Get_ScoreItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 ScoreItem 的所有实例
    /// </summary>
    public static void Destroy_ScoreItem()
    {
        var uiInstance = Get_ScoreItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 ScoreItem 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.ScoreItem.ScoreItemPanel[] Get_ScoreItem_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.ScoreItem.ScoreItemPanel>(nameof(NovaDrift.Scripts.Ui.ScoreItem.ScoreItem));
    }

    /// <summary>
    /// 创建 ScoreLabel, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel Create_ScoreLabel()
    {
        return CreateUi<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>(UiName.ScoreLabel);
    }

    /// <summary>
    /// 打开 ScoreLabel, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel Open_ScoreLabel()
    {
        return OpenUi<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>(UiName.ScoreLabel);
    }

    /// <summary>
    /// 隐藏 ScoreLabel 的所有实例
    /// </summary>
    public static void Hide_ScoreLabel()
    {
        var uiInstance = Get_ScoreLabel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 ScoreLabel 的所有实例
    /// </summary>
    public static void Destroy_ScoreLabel()
    {
        var uiInstance = Get_ScoreLabel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 ScoreLabel 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel[] Get_ScoreLabel_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>(nameof(NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabel));
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

    /// <summary>
    /// 创建 Setting, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Setting.SettingPanel Create_Setting()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Setting.SettingPanel>(UiName.Setting);
    }

    /// <summary>
    /// 打开 Setting, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Setting.SettingPanel Open_Setting()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Setting.SettingPanel>(UiName.Setting);
    }

    /// <summary>
    /// 隐藏 Setting 的所有实例
    /// </summary>
    public static void Hide_Setting()
    {
        var uiInstance = Get_Setting_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Setting 的所有实例
    /// </summary>
    public static void Destroy_Setting()
    {
        var uiInstance = Get_Setting_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Setting 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Setting.SettingPanel[] Get_Setting_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Setting.SettingPanel>(nameof(NovaDrift.Scripts.Ui.Setting.Setting));
    }

    /// <summary>
    /// 创建 Slogan, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Slogan.SloganPanel Create_Slogan()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Slogan.SloganPanel>(UiName.Slogan);
    }

    /// <summary>
    /// 打开 Slogan, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Slogan.SloganPanel Open_Slogan()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Slogan.SloganPanel>(UiName.Slogan);
    }

    /// <summary>
    /// 隐藏 Slogan 的所有实例
    /// </summary>
    public static void Hide_Slogan()
    {
        var uiInstance = Get_Slogan_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Slogan 的所有实例
    /// </summary>
    public static void Destroy_Slogan()
    {
        var uiInstance = Get_Slogan_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Slogan 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Slogan.SloganPanel[] Get_Slogan_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Slogan.SloganPanel>(nameof(NovaDrift.Scripts.Ui.Slogan.Slogan));
    }

    /// <summary>
    /// 创建 StartMenu, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.StartMenu.StartMenuPanel Create_StartMenu()
    {
        return CreateUi<NovaDrift.Scripts.Ui.StartMenu.StartMenuPanel>(UiName.StartMenu);
    }

    /// <summary>
    /// 打开 StartMenu, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.StartMenu.StartMenuPanel Open_StartMenu()
    {
        return OpenUi<NovaDrift.Scripts.Ui.StartMenu.StartMenuPanel>(UiName.StartMenu);
    }

    /// <summary>
    /// 隐藏 StartMenu 的所有实例
    /// </summary>
    public static void Hide_StartMenu()
    {
        var uiInstance = Get_StartMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 StartMenu 的所有实例
    /// </summary>
    public static void Destroy_StartMenu()
    {
        var uiInstance = Get_StartMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 StartMenu 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.StartMenu.StartMenuPanel[] Get_StartMenu_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.StartMenu.StartMenuPanel>(nameof(NovaDrift.Scripts.Ui.StartMenu.StartMenu));
    }

    /// <summary>
    /// 创建 StatMonitorLabel, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabelPanel Create_StatMonitorLabel()
    {
        return CreateUi<NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabelPanel>(UiName.StatMonitorLabel);
    }

    /// <summary>
    /// 打开 StatMonitorLabel, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabelPanel Open_StatMonitorLabel()
    {
        return OpenUi<NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabelPanel>(UiName.StatMonitorLabel);
    }

    /// <summary>
    /// 隐藏 StatMonitorLabel 的所有实例
    /// </summary>
    public static void Hide_StatMonitorLabel()
    {
        var uiInstance = Get_StatMonitorLabel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 StatMonitorLabel 的所有实例
    /// </summary>
    public static void Destroy_StatMonitorLabel()
    {
        var uiInstance = Get_StatMonitorLabel_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 StatMonitorLabel 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabelPanel[] Get_StatMonitorLabel_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabelPanel>(nameof(NovaDrift.Scripts.Ui.StatMonitorLabel.StatMonitorLabel));
    }

    /// <summary>
    /// 创建 StatsMonitor, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitorPanel Create_StatsMonitor()
    {
        return CreateUi<NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitorPanel>(UiName.StatsMonitor);
    }

    /// <summary>
    /// 打开 StatsMonitor, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitorPanel Open_StatsMonitor()
    {
        return OpenUi<NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitorPanel>(UiName.StatsMonitor);
    }

    /// <summary>
    /// 隐藏 StatsMonitor 的所有实例
    /// </summary>
    public static void Hide_StatsMonitor()
    {
        var uiInstance = Get_StatsMonitor_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 StatsMonitor 的所有实例
    /// </summary>
    public static void Destroy_StatsMonitor()
    {
        var uiInstance = Get_StatsMonitor_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 StatsMonitor 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitorPanel[] Get_StatsMonitor_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitorPanel>(nameof(NovaDrift.Scripts.Ui.StatsMonitor.StatsMonitor));
    }

    /// <summary>
    /// 创建 StatsMonitorItem, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel Create_StatsMonitorItem()
    {
        return CreateUi<NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel>(UiName.StatsMonitorItem);
    }

    /// <summary>
    /// 打开 StatsMonitorItem, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel Open_StatsMonitorItem()
    {
        return OpenUi<NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel>(UiName.StatsMonitorItem);
    }

    /// <summary>
    /// 隐藏 StatsMonitorItem 的所有实例
    /// </summary>
    public static void Hide_StatsMonitorItem()
    {
        var uiInstance = Get_StatsMonitorItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 StatsMonitorItem 的所有实例
    /// </summary>
    public static void Destroy_StatsMonitorItem()
    {
        var uiInstance = Get_StatsMonitorItem_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 StatsMonitorItem 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel[] Get_StatsMonitorItem_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel>(nameof(NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItem));
    }

    /// <summary>
    /// 创建 Tip, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static NovaDrift.Scripts.Ui.Tip.TipPanel Create_Tip()
    {
        return CreateUi<NovaDrift.Scripts.Ui.Tip.TipPanel>(UiName.Tip);
    }

    /// <summary>
    /// 打开 Tip, 并返回UI实例
    /// </summary>
    public static NovaDrift.Scripts.Ui.Tip.TipPanel Open_Tip()
    {
        return OpenUi<NovaDrift.Scripts.Ui.Tip.TipPanel>(UiName.Tip);
    }

    /// <summary>
    /// 隐藏 Tip 的所有实例
    /// </summary>
    public static void Hide_Tip()
    {
        var uiInstance = Get_Tip_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Tip 的所有实例
    /// </summary>
    public static void Destroy_Tip()
    {
        var uiInstance = Get_Tip_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Tip 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static NovaDrift.Scripts.Ui.Tip.TipPanel[] Get_Tip_Instance()
    {
        return GetUiInstance<NovaDrift.Scripts.Ui.Tip.TipPanel>(nameof(NovaDrift.Scripts.Ui.Tip.Tip));
    }

}
