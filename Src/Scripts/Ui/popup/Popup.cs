namespace NovaDrift.Scripts.Ui.Popup;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Popup : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Popup.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((PopupPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Popup.Panel
    /// </summary>
    public Panel L_Panel
    {
        get
        {
            if (_L_Panel == null) _L_Panel = new Panel((PopupPanel)this, GetNode<Godot.PanelContainer>("Panel"));
            return _L_Panel;
        }
    }
    private Panel _L_Panel;


    public Popup() : base(nameof(Popup))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: Popup.ColorRect
    /// </summary>
    public class ColorRect : UiNode<PopupPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(PopupPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Popup.Panel.VBoxContainer.PanelContainer.TitleLabel
    /// </summary>
    public class TitleLabel : UiNode<PopupPanel, Godot.Label, TitleLabel>
    {
        public TitleLabel(PopupPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TitleLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: Popup.Panel.VBoxContainer.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<PopupPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Popup.Panel.VBoxContainer.TitleLabel
        /// </summary>
        public TitleLabel L_TitleLabel
        {
            get
            {
                if (_L_TitleLabel == null) _L_TitleLabel = new TitleLabel(UiPanel, Instance.GetNode<Godot.Label>("TitleLabel"));
                return _L_TitleLabel;
            }
        }
        private TitleLabel _L_TitleLabel;

        public PanelContainer(PopupPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Popup.Panel.VBoxContainer.Content.Nodes.MessageContent.MessageLabel
    /// </summary>
    public class MessageLabel : UiNode<PopupPanel, Godot.Label, MessageLabel>
    {
        public MessageLabel(PopupPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override MessageLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Popup.Panel.VBoxContainer.Content.Nodes.MessageContent
    /// </summary>
    public class MessageContent : UiNode<PopupPanel, Godot.VBoxContainer, MessageContent>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Popup.Panel.VBoxContainer.Content.Nodes.MessageLabel
        /// </summary>
        public MessageLabel L_MessageLabel
        {
            get
            {
                if (_L_MessageLabel == null) _L_MessageLabel = new MessageLabel(UiPanel, Instance.GetNode<Godot.Label>("MessageLabel"));
                return _L_MessageLabel;
            }
        }
        private MessageLabel _L_MessageLabel;

        public MessageContent(PopupPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override MessageContent Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Popup.Panel.VBoxContainer.Content.Nodes
    /// </summary>
    public class Nodes : UiNode<PopupPanel, Godot.VBoxContainer, Nodes>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Popup.Panel.VBoxContainer.Content.MessageContent
        /// </summary>
        public MessageContent L_MessageContent
        {
            get
            {
                if (_L_MessageContent == null) _L_MessageContent = new MessageContent(UiPanel, Instance.GetNode<Godot.VBoxContainer>("MessageContent"));
                return _L_MessageContent;
            }
        }
        private MessageContent _L_MessageContent;

        public Nodes(PopupPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Nodes Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Popup.Panel.VBoxContainer.Content
    /// </summary>
    public class Content : UiNode<PopupPanel, Godot.MarginContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Popup.Panel.VBoxContainer.Nodes
        /// </summary>
        public Nodes L_Nodes
        {
            get
            {
                if (_L_Nodes == null) _L_Nodes = new Nodes(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Nodes"));
                return _L_Nodes;
            }
        }
        private Nodes _L_Nodes;

        public Content(PopupPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Popup.Panel.VBoxContainer.HBoxContainer.ConfirmBtn
    /// </summary>
    public class ConfirmBtn : UiNode<PopupPanel, Godot.Button, ConfirmBtn>
    {
        public ConfirmBtn(PopupPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ConfirmBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Popup.Panel.VBoxContainer.HBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<PopupPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(PopupPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Popup.Panel.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<PopupPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Popup.Panel.VBoxContainer.ConfirmBtn
        /// </summary>
        public ConfirmBtn L_ConfirmBtn
        {
            get
            {
                if (_L_ConfirmBtn == null) _L_ConfirmBtn = new ConfirmBtn(UiPanel, Instance.GetNode<Godot.Button>("ConfirmBtn"));
                return _L_ConfirmBtn;
            }
        }
        private ConfirmBtn _L_ConfirmBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Popup.Panel.VBoxContainer.CloseBtn
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

        public HBoxContainer(PopupPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Popup.Panel.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<PopupPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Popup.Panel.PanelContainer
        /// </summary>
        public PanelContainer L_PanelContainer
        {
            get
            {
                if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer(UiPanel, Instance.GetNode<Godot.PanelContainer>("PanelContainer"));
                return _L_PanelContainer;
            }
        }
        private PanelContainer _L_PanelContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Popup.Panel.Content
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Popup.Panel.HBoxContainer
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

        public VBoxContainer(PopupPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: Popup.Panel
    /// </summary>
    public class Panel : UiNode<PopupPanel, Godot.PanelContainer, Panel>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Popup.VBoxContainer
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

        public Panel(PopupPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override Panel Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Popup.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Popup.Panel.VBoxContainer.PanelContainer.TitleLabel
    /// </summary>
    public TitleLabel S_TitleLabel => L_Panel.L_VBoxContainer.L_PanelContainer.L_TitleLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Popup.Panel.VBoxContainer.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_Panel.L_VBoxContainer.L_PanelContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Popup.Panel.VBoxContainer.Content.Nodes.MessageContent.MessageLabel
    /// </summary>
    public MessageLabel S_MessageLabel => L_Panel.L_VBoxContainer.L_Content.L_Nodes.L_MessageContent.L_MessageLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Popup.Panel.VBoxContainer.Content.Nodes.MessageContent
    /// </summary>
    public MessageContent S_MessageContent => L_Panel.L_VBoxContainer.L_Content.L_Nodes.L_MessageContent;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Popup.Panel.VBoxContainer.Content.Nodes
    /// </summary>
    public Nodes S_Nodes => L_Panel.L_VBoxContainer.L_Content.L_Nodes;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Popup.Panel.VBoxContainer.Content
    /// </summary>
    public Content S_Content => L_Panel.L_VBoxContainer.L_Content;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Popup.Panel.VBoxContainer.HBoxContainer.ConfirmBtn
    /// </summary>
    public ConfirmBtn S_ConfirmBtn => L_Panel.L_VBoxContainer.L_HBoxContainer.L_ConfirmBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Popup.Panel.VBoxContainer.HBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_Panel.L_VBoxContainer.L_HBoxContainer.L_CloseBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Popup.Panel.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_Panel.L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Popup.Panel.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_Panel.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Popup.Panel
    /// </summary>
    public Panel S_Panel => L_Panel;

}
