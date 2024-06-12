namespace NovaDrift.Scripts.Ui.GoodsItem;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GoodsItem : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GoodsItem.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((GoodsItemPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GoodsItem.Button
    /// </summary>
    public Button L_Button
    {
        get
        {
            if (_L_Button == null) _L_Button = new Button((GoodsItemPanel)this, GetNode<Godot.Button>("Button"));
            return _L_Button;
        }
    }
    private Button _L_Button;


    public GoodsItem() : base(nameof(GoodsItem))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.Image
    /// </summary>
    public class Image : UiNode<GoodsItemPanel, Godot.TextureRect, Image>
    {
        public Image(GoodsItemPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Image Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.Control
    /// </summary>
    public class Control : UiNode<GoodsItemPanel, Godot.Control, Control>
    {
        public Control(GoodsItemPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.VBoxContainer2.TypeLabel
    /// </summary>
    public class TypeLabel : UiNode<GoodsItemPanel, Godot.Label, TypeLabel>
    {
        public TypeLabel(GoodsItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TypeLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.VBoxContainer2.NameLabel
    /// </summary>
    public class NameLabel : UiNode<GoodsItemPanel, Godot.Label, NameLabel>
    {
        public NameLabel(GoodsItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override NameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<GoodsItemPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.TypeLabel
        /// </summary>
        public TypeLabel L_TypeLabel
        {
            get
            {
                if (_L_TypeLabel == null) _L_TypeLabel = new TypeLabel(UiPanel, Instance.GetNode<Godot.Label>("TypeLabel"));
                return _L_TypeLabel;
            }
        }
        private TypeLabel _L_TypeLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.NameLabel
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

        public VBoxContainer2(GoodsItemPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<GoodsItemPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.Control
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer2
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

        public VBoxContainer_1(GoodsItemPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<GoodsItemPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.VBoxContainer
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

        public MarginContainer(GoodsItemPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.Img
    /// </summary>
    public class Img : UiNode<GoodsItemPanel, Godot.MarginContainer, Img>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Image
        /// </summary>
        public Image L_Image
        {
            get
            {
                if (_L_Image == null) _L_Image = new Image(UiPanel, Instance.GetNode<Godot.TextureRect>("Image"));
                return _L_Image;
            }
        }
        private Image _L_Image;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.MarginContainer
        /// </summary>
        public MarginContainer L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer _L_MarginContainer;

        public Img(GoodsItemPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Img Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer.MarginContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<GoodsItemPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(GoodsItemPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer.MarginContainer
    /// </summary>
    public class MarginContainer_2 : UiNode<GoodsItemPanel, Godot.MarginContainer, MarginContainer_2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer.TextureRect
        /// </summary>
        public TextureRect L_TextureRect
        {
            get
            {
                if (_L_TextureRect == null) _L_TextureRect = new TextureRect(UiPanel, Instance.GetNode<Godot.TextureRect>("TextureRect"));
                return _L_TextureRect;
            }
        }
        private TextureRect _L_TextureRect;

        public MarginContainer_2(GoodsItemPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_2 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer.PriceLabel
    /// </summary>
    public class PriceLabel : UiNode<GoodsItemPanel, Godot.Label, PriceLabel>
    {
        public PriceLabel(GoodsItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override PriceLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer
    /// </summary>
    public class PriceContainer : UiNode<GoodsItemPanel, Godot.HBoxContainer, PriceContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.MarginContainer
        /// </summary>
        public MarginContainer_2 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_2(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_2 _L_MarginContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceLabel
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

        public PriceContainer(GoodsItemPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override PriceContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.DiscountLabel.ColorRect
    /// </summary>
    public class ColorRect : UiNode<GoodsItemPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(GoodsItemPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.DiscountLabel
    /// </summary>
    public class DiscountLabel : UiNode<GoodsItemPanel, Godot.Label, DiscountLabel>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.ColorRect
        /// </summary>
        public ColorRect L_ColorRect
        {
            get
            {
                if (_L_ColorRect == null) _L_ColorRect = new ColorRect(UiPanel, Instance.GetNode<Godot.ColorRect>("ColorRect"));
                return _L_ColorRect;
            }
        }
        private ColorRect _L_ColorRect;

        public DiscountLabel(GoodsItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override DiscountLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<GoodsItemPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.PriceContainer
        /// </summary>
        public PriceContainer L_PriceContainer
        {
            get
            {
                if (_L_PriceContainer == null) _L_PriceContainer = new PriceContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("PriceContainer"));
                return _L_PriceContainer;
            }
        }
        private PriceContainer _L_PriceContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.DiscountLabel
        /// </summary>
        public DiscountLabel L_DiscountLabel
        {
            get
            {
                if (_L_DiscountLabel == null) _L_DiscountLabel = new DiscountLabel(UiPanel, Instance.GetNode<Godot.Label>("DiscountLabel"));
                return _L_DiscountLabel;
            }
        }
        private DiscountLabel _L_DiscountLabel;

        public HBoxContainer(GoodsItemPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<GoodsItemPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.HBoxContainer
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

        public MarginContainer_1(GoodsItemPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer
    /// </summary>
    public class PanelContainer_1 : UiNode<GoodsItemPanel, Godot.PanelContainer, PanelContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.MarginContainer
        /// </summary>
        public MarginContainer_1 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_1(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_1 _L_MarginContainer;

        public PanelContainer_1(GoodsItemPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer_1 Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsItem.PanelContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<GoodsItemPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsItem.PanelContainer.Img
        /// </summary>
        public Img L_Img
        {
            get
            {
                if (_L_Img == null) _L_Img = new Img(UiPanel, Instance.GetNode<Godot.MarginContainer>("Img"));
                return _L_Img;
            }
        }
        private Img _L_Img;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GoodsItem.PanelContainer.PanelContainer
        /// </summary>
        public PanelContainer_1 L_PanelContainer
        {
            get
            {
                if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer_1(UiPanel, Instance.GetNode<Godot.PanelContainer>("PanelContainer"));
                return _L_PanelContainer;
            }
        }
        private PanelContainer_1 _L_PanelContainer;

        public VBoxContainer(GoodsItemPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GoodsItem.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<GoodsItemPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsItem.VBoxContainer
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

        public PanelContainer(GoodsItemPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GoodsItem.Button
    /// </summary>
    public class Button : UiNode<GoodsItemPanel, Godot.Button, Button>
    {
        public Button(GoodsItemPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.Image
    /// </summary>
    public Image S_Image => L_PanelContainer.L_VBoxContainer.L_Img.L_Image;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.Control
    /// </summary>
    public Control S_Control => L_PanelContainer.L_VBoxContainer.L_Img.L_MarginContainer.L_VBoxContainer.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.VBoxContainer2.TypeLabel
    /// </summary>
    public TypeLabel S_TypeLabel => L_PanelContainer.L_VBoxContainer.L_Img.L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_TypeLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.VBoxContainer2.NameLabel
    /// </summary>
    public NameLabel S_NameLabel => L_PanelContainer.L_VBoxContainer.L_Img.L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_NameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img.MarginContainer.VBoxContainer.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_PanelContainer.L_VBoxContainer.L_Img.L_MarginContainer.L_VBoxContainer.L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.Img
    /// </summary>
    public Img S_Img => L_PanelContainer.L_VBoxContainer.L_Img;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer.MarginContainer.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_PanelContainer.L_VBoxContainer.L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_PriceContainer.L_MarginContainer.L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer.PriceLabel
    /// </summary>
    public PriceLabel S_PriceLabel => L_PanelContainer.L_VBoxContainer.L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_PriceContainer.L_PriceLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.PriceContainer
    /// </summary>
    public PriceContainer S_PriceContainer => L_PanelContainer.L_VBoxContainer.L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_PriceContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.DiscountLabel.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_PanelContainer.L_VBoxContainer.L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_DiscountLabel.L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer.DiscountLabel
    /// </summary>
    public DiscountLabel S_DiscountLabel => L_PanelContainer.L_VBoxContainer.L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_DiscountLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsItem.PanelContainer.VBoxContainer.PanelContainer.MarginContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_PanelContainer.L_VBoxContainer.L_PanelContainer.L_MarginContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GoodsItem.Button
    /// </summary>
    public Button S_Button => L_Button;

}
