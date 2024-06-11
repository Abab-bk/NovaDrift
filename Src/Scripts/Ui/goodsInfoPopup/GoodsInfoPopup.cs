namespace NovaDrift.Scripts.Ui.GoodsInfoPopup;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GoodsInfoPopup : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: GoodsInfoPopup.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((GoodsInfoPopupPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((GoodsInfoPopupPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public GoodsInfoPopup() : base(nameof(GoodsInfoPopup))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: GoodsInfoPopup.ColorRect
    /// </summary>
    public class ColorRect : UiNode<GoodsInfoPopupPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(GoodsInfoPopupPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer.NameLabel
    /// </summary>
    public class NameLabel : UiNode<GoodsInfoPopupPanel, Godot.Label, NameLabel>
    {
        public NameLabel(GoodsInfoPopupPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override NameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer.DescLabel
    /// </summary>
    public class DescLabel : UiNode<GoodsInfoPopupPanel, Godot.Label, DescLabel>
    {
        public DescLabel(GoodsInfoPopupPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override DescLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<GoodsInfoPopupPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.NameLabel
        /// </summary>
        public NameLabel L_NameLabel
        {
            get
            {
                if (_L_NameLabel == null) _L_NameLabel = new NameLabel(UiPanel, Instance.GetNode<Godot.Label>("NameLabel"));
                return _L_NameLabel;
            }
        }
        private NameLabel _L_NameLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.DescLabel
        /// </summary>
        public DescLabel L_DescLabel
        {
            get
            {
                if (_L_DescLabel == null) _L_DescLabel = new DescLabel(UiPanel, Instance.GetNode<Godot.Label>("DescLabel"));
                return _L_DescLabel;
            }
        }
        private DescLabel _L_DescLabel;

        public VBoxContainer_1(GoodsInfoPopupPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.Control
    /// </summary>
    public class Control : UiNode<GoodsInfoPopupPanel, Godot.Control, Control>
    {
        public Control(GoodsInfoPopupPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.PriceLabel
    /// </summary>
    public class PriceLabel : UiNode<GoodsInfoPopupPanel, Godot.Label, PriceLabel>
    {
        public PriceLabel(GoodsInfoPopupPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override PriceLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.HBoxContainer.BuyBtn
    /// </summary>
    public class BuyBtn : UiNode<GoodsInfoPopupPanel, Godot.Button, BuyBtn>
    {
        public BuyBtn(GoodsInfoPopupPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override BuyBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.HBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<GoodsInfoPopupPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(GoodsInfoPopupPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.HBoxContainer
    /// </summary>
    public class HBoxContainer_1 : UiNode<GoodsInfoPopupPanel, Godot.HBoxContainer, HBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.BuyBtn
        /// </summary>
        public BuyBtn L_BuyBtn
        {
            get
            {
                if (_L_BuyBtn == null) _L_BuyBtn = new BuyBtn(UiPanel, Instance.GetNode<Godot.Button>("BuyBtn"));
                return _L_BuyBtn;
            }
        }
        private BuyBtn _L_BuyBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.CloseBtn
        /// </summary>
        public CloseBtn L_CloseBtn
        {
            get
            {
                if (_L_CloseBtn == null) _L_CloseBtn = new CloseBtn(UiPanel, Instance.GetNode<Godot.Button>("CloseBtn"));
                return _L_CloseBtn;
            }
        }
        private CloseBtn _L_CloseBtn;

        public HBoxContainer_1(GoodsInfoPopupPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<GoodsInfoPopupPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.PriceLabel
        /// </summary>
        public PriceLabel L_PriceLabel
        {
            get
            {
                if (_L_PriceLabel == null) _L_PriceLabel = new PriceLabel(UiPanel, Instance.GetNode<Godot.Label>("PriceLabel"));
                return _L_PriceLabel;
            }
        }
        private PriceLabel _L_PriceLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.HBoxContainer
        /// </summary>
        public HBoxContainer_1 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_1 _L_HBoxContainer;

        public VBoxContainer2(GoodsInfoPopupPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<GoodsInfoPopupPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.Control
        /// </summary>
        public Control L_Control
        {
            get
            {
                if (_L_Control == null) _L_Control = new Control(UiPanel, Instance.GetNode<Godot.Control>("Control"));
                return _L_Control;
            }
        }
        private Control _L_Control;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer2
        /// </summary>
        public VBoxContainer2 L_VBoxContainer2
        {
            get
            {
                if (_L_VBoxContainer2 == null) _L_VBoxContainer2 = new VBoxContainer2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer2"));
                return _L_VBoxContainer2;
            }
        }
        private VBoxContainer2 _L_VBoxContainer2;

        public VBoxContainer(GoodsInfoPopupPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.Icon
    /// </summary>
    public class Icon : UiNode<GoodsInfoPopupPanel, Godot.TextureRect, Icon>
    {
        public Icon(GoodsInfoPopupPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<GoodsInfoPopupPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.VBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.Icon
        /// </summary>
        public Icon L_Icon
        {
            get
            {
                if (_L_Icon == null) _L_Icon = new Icon(UiPanel, Instance.GetNode<Godot.TextureRect>("Icon"));
                return _L_Icon;
            }
        }
        private Icon _L_Icon;

        public HBoxContainer(GoodsInfoPopupPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GoodsInfoPopup.PanelContainer.Content
    /// </summary>
    public class Content : UiNode<GoodsInfoPopupPanel, Godot.MarginContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.HBoxContainer
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

        public Content(GoodsInfoPopupPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GoodsInfoPopup.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<GoodsInfoPopupPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsInfoPopup.Content
        /// </summary>
        public Content L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content(UiPanel, Instance.GetNode<Godot.MarginContainer>("Content"));
                return _L_Content;
            }
        }
        private Content _L_Content;

        public PanelContainer(GoodsInfoPopupPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: GoodsInfoPopup.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer.NameLabel
    /// </summary>
    public NameLabel S_NameLabel => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer.L_NameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer.DescLabel
    /// </summary>
    public DescLabel S_DescLabel => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer.L_DescLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.Control
    /// </summary>
    public Control S_Control => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.PriceLabel
    /// </summary>
    public PriceLabel S_PriceLabel => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer2.L_PriceLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.HBoxContainer.BuyBtn
    /// </summary>
    public BuyBtn S_BuyBtn => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer2.L_HBoxContainer.L_BuyBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2.HBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer2.L_HBoxContainer.L_CloseBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.VBoxContainer.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_PanelContainer.L_Content.L_HBoxContainer.L_VBoxContainer.L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content.HBoxContainer.Icon
    /// </summary>
    public Icon S_Icon => L_PanelContainer.L_Content.L_HBoxContainer.L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer.Content
    /// </summary>
    public Content S_Content => L_PanelContainer.L_Content;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GoodsInfoPopup.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
