namespace NovaDrift.Scripts.Ui.PausedMenu;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class PausedMenu : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: PausedMenu.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((PausedMenuPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: PausedMenu.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((PausedMenuPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: PausedMenu.Indicator
    /// </summary>
    public Indicator L_Indicator
    {
        get
        {
            if (_L_Indicator == null) _L_Indicator = new Indicator((PausedMenuPanel)this, GetNode<Godot.TextureRect>("Indicator"));
            return _L_Indicator;
        }
    }
    private Indicator _L_Indicator;


    public PausedMenu() : base(nameof(PausedMenu))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_Content;
        RecordNestedUi(inst1.L_AbilityPanel.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_AbilityPanel.Instance.OnCreateUi();
        inst1.L_AbilityPanel.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: PausedMenu.ColorRect
    /// </summary>
    public class ColorRect : UiNode<PausedMenuPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(PausedMenuPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<PausedMenuPanel, Godot.Label, Label>
    {
        public Label(PausedMenuPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Stats
    /// </summary>
    public class Stats : UiNode<PausedMenuPanel, Godot.VBoxContainer, Stats>
    {
        public Stats(PausedMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Stats Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HFlowContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content.ScrollContainer.Abilities
    /// </summary>
    public class Abilities : UiNode<PausedMenuPanel, Godot.HFlowContainer, Abilities>
    {
        public Abilities(PausedMenuPanel uiPanel, Godot.HFlowContainer node) : base(uiPanel, node) {  }
        public override Abilities Clone() => new (UiPanel, (Godot.HFlowContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content.ScrollContainer
    /// </summary>
    public class ScrollContainer_1 : UiNode<PausedMenuPanel, Godot.ScrollContainer, ScrollContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HFlowContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content.Abilities
        /// </summary>
        public Abilities L_Abilities
        {
            get
            {
                if (_L_Abilities == null) _L_Abilities = new Abilities(UiPanel, Instance.GetNode<Godot.HFlowContainer>("Abilities"));
                return _L_Abilities;
            }
        }
        private Abilities _L_Abilities;

        public ScrollContainer_1(PausedMenuPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_1 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content.AbilityPanel
    /// </summary>
    public class AbilityPanel : UiNode<PausedMenuPanel, NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel, AbilityPanel>
    {
        public AbilityPanel(PausedMenuPanel uiPanel, NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel node) : base(uiPanel, node) {  }
        public override AbilityPanel Clone()
        {
            var uiNode = new AbilityPanel(UiPanel, (NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content
    /// </summary>
    public class Content : UiNode<PausedMenuPanel, Godot.HBoxContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.ScrollContainer
        /// </summary>
        public ScrollContainer_1 L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer_1(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer_1 _L_ScrollContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.AbilityPanel
        /// </summary>
        public AbilityPanel L_AbilityPanel
        {
            get
            {
                if (_L_AbilityPanel == null) _L_AbilityPanel = new AbilityPanel(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel>("AbilityPanel"));
                return _L_AbilityPanel;
            }
        }
        private AbilityPanel _L_AbilityPanel;

        public Content(PausedMenuPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<PausedMenuPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.Stats
        /// </summary>
        public Stats L_Stats
        {
            get
            {
                if (_L_Stats == null) _L_Stats = new Stats(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Stats"));
                return _L_Stats;
            }
        }
        private Stats _L_Stats;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.Content
        /// </summary>
        public Content L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Content"));
                return _L_Content;
            }
        }
        private Content _L_Content;

        public VBoxContainer_1(PausedMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<PausedMenuPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_1 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_1(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_1 _L_VBoxContainer;

        public ScrollContainer(PausedMenuPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public class ReStartBtn : UiNode<PausedMenuPanel, Godot.Button, ReStartBtn>
    {
        public ReStartBtn(PausedMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ReStartBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.VBoxContainer.BackToMainBtn
    /// </summary>
    public class BackToMainBtn : UiNode<PausedMenuPanel, Godot.Button, BackToMainBtn>
    {
        public BackToMainBtn(PausedMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override BackToMainBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_2 : UiNode<PausedMenuPanel, Godot.VBoxContainer, VBoxContainer_2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ReStartBtn
        /// </summary>
        public ReStartBtn L_ReStartBtn
        {
            get
            {
                if (_L_ReStartBtn == null) _L_ReStartBtn = new ReStartBtn(UiPanel, Instance.GetNode<Godot.Button>("ReStartBtn"));
                return _L_ReStartBtn;
            }
        }
        private ReStartBtn _L_ReStartBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.BackToMainBtn
        /// </summary>
        public BackToMainBtn L_BackToMainBtn
        {
            get
            {
                if (_L_BackToMainBtn == null) _L_BackToMainBtn = new BackToMainBtn(UiPanel, Instance.GetNode<Godot.Button>("BackToMainBtn"));
                return _L_BackToMainBtn;
            }
        }
        private BackToMainBtn _L_BackToMainBtn;

        public VBoxContainer_2(PausedMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PausedMenu.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<PausedMenuPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: PausedMenu.MarginContainer.Label
        /// </summary>
        public Label L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: PausedMenu.MarginContainer.ScrollContainer
        /// </summary>
        public ScrollContainer L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer _L_ScrollContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_2 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_2 _L_VBoxContainer;

        public VBoxContainer(PausedMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: PausedMenu.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<PausedMenuPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PausedMenu.VBoxContainer
        /// </summary>
        public VBoxContainer L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer _L_VBoxContainer;

        public MarginContainer(PausedMenuPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: PausedMenu.Indicator
    /// </summary>
    public class Indicator : UiNode<PausedMenuPanel, Godot.TextureRect, Indicator>
    {
        public Indicator(PausedMenuPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Indicator Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: PausedMenu.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.Label
    /// </summary>
    public Label S_Label => L_MarginContainer.L_VBoxContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Stats
    /// </summary>
    public Stats S_Stats => L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_Stats;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HFlowContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content.ScrollContainer.Abilities
    /// </summary>
    public Abilities S_Abilities => L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_Content.L_ScrollContainer.L_Abilities;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content.AbilityPanel
    /// </summary>
    public AbilityPanel S_AbilityPanel => L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_Content.L_AbilityPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.ScrollContainer.VBoxContainer.Content
    /// </summary>
    public Content S_Content => L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_Content;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public ReStartBtn S_ReStartBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_ReStartBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PausedMenu.MarginContainer.VBoxContainer.VBoxContainer.BackToMainBtn
    /// </summary>
    public BackToMainBtn S_BackToMainBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_BackToMainBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: PausedMenu.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: PausedMenu.Indicator
    /// </summary>
    public Indicator S_Indicator => L_Indicator;

}
