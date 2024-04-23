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


    public PausedMenu() : base(nameof(PausedMenu))
    {
    }

    public sealed override void OnInitNestedUi()
    {

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
    /// 类型: <see cref="Godot.GridContainer"/>, 路径: PausedMenu.MarginContainer.HBoxContainer.ScrollContainer.Abilities
    /// </summary>
    public class Abilities : UiNode<PausedMenuPanel, Godot.GridContainer, Abilities>
    {
        public Abilities(PausedMenuPanel uiPanel, Godot.GridContainer node) : base(uiPanel, node) {  }
        public override Abilities Clone() => new (UiPanel, (Godot.GridContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: PausedMenu.MarginContainer.HBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<PausedMenuPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.Abilities
        /// </summary>
        public Abilities L_Abilities
        {
            get
            {
                if (_L_Abilities == null) _L_Abilities = new Abilities(UiPanel, Instance.GetNode<Godot.GridContainer>("Abilities"));
                return _L_Abilities;
            }
        }
        private Abilities _L_Abilities;

        public ScrollContainer(PausedMenuPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<PausedMenuPanel, Godot.Label, Label>
    {
        public Label(PausedMenuPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public class ReStartBtn : UiNode<PausedMenuPanel, Godot.Button, ReStartBtn>
    {
        public ReStartBtn(PausedMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ReStartBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<PausedMenuPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer.ReStartBtn
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

        public VBoxContainer_1(PausedMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<PausedMenuPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer
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

        public VBoxContainer(PausedMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: PausedMenu.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<PausedMenuPanel, Godot.HBoxContainer, HBoxContainer>
    {
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
        public VBoxContainer L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer _L_VBoxContainer;

        public HBoxContainer(PausedMenuPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: PausedMenu.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<PausedMenuPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: PausedMenu.HBoxContainer
        /// </summary>
        public HBoxContainer L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer _L_HBoxContainer;

        public MarginContainer(PausedMenuPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: PausedMenu.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.ScrollContainer.Abilities
    /// </summary>
    public Abilities S_Abilities => L_MarginContainer.L_HBoxContainer.L_ScrollContainer.L_Abilities;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_MarginContainer.L_HBoxContainer.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer.Label
    /// </summary>
    public Label S_Label => L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer.VBoxContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public ReStartBtn S_ReStartBtn => L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer.L_ReStartBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: PausedMenu.MarginContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_MarginContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: PausedMenu.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
