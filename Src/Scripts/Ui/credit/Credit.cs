namespace NovaDrift.Scripts.Ui.Credit;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Credit : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Credit.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((CreditPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public Credit() : base(nameof(Credit))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.Control
    /// </summary>
    public class Control : UiNode<CreditPanel, Godot.Control, Control>
    {
        public Control(CreditPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<CreditPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(CreditPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.Items.Control
    /// </summary>
    public class Control_1 : UiNode<CreditPanel, Godot.Control, Control_1>
    {
        public Control_1(CreditPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control_1 Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.Items
    /// </summary>
    public class Items : UiNode<CreditPanel, Godot.VBoxContainer, Items>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.Control
        /// </summary>
        public Control_1 L_Control
        {
            get
            {
                if (_L_Control == null) _L_Control = new Control_1(UiPanel, Instance.GetNode<Godot.Control>("Control"));
                return _L_Control;
            }
        }
        private Control_1 _L_Control;

        public Items(CreditPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Items Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<CreditPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.Control
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.TextureRect
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.Items
        /// </summary>
        public Items L_Items
        {
            get
            {
                if (_L_Items == null) _L_Items = new Items(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Items"));
                return _L_Items;
            }
        }
        private Items _L_Items;

        public VBoxContainer(CreditPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: Credit.MarginContainer.VBoxContainer2.Scroll
    /// </summary>
    public class Scroll : UiNode<CreditPanel, Godot.ScrollContainer, Scroll>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.VBoxContainer
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

        public Scroll(CreditPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override Scroll Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Credit.MarginContainer.VBoxContainer2.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<CreditPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(CreditPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Credit.MarginContainer.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<CreditPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Credit.MarginContainer.Scroll
        /// </summary>
        public Scroll L_Scroll
        {
            get
            {
                if (_L_Scroll == null) _L_Scroll = new Scroll(UiPanel, Instance.GetNode<Godot.ScrollContainer>("Scroll"));
                return _L_Scroll;
            }
        }
        private Scroll _L_Scroll;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Credit.MarginContainer.CloseBtn
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

        public VBoxContainer2(CreditPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Credit.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<CreditPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credit.VBoxContainer2
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

        public MarginContainer(CreditPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_MarginContainer.L_VBoxContainer2.L_Scroll.L_VBoxContainer.L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer.Items
    /// </summary>
    public Items S_Items => L_MarginContainer.L_VBoxContainer2.L_Scroll.L_VBoxContainer.L_Items;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_MarginContainer.L_VBoxContainer2.L_Scroll.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.Scroll
    /// </summary>
    public Scroll S_Scroll => L_MarginContainer.L_VBoxContainer2.L_Scroll;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Credit.MarginContainer.VBoxContainer2.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_MarginContainer.L_VBoxContainer2.L_CloseBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credit.MarginContainer.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_MarginContainer.L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Credit.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
