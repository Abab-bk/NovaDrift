namespace NovaDrift.Scripts.Ui.AbilityPanel;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class AbilityPanel : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: AbilityPanel.TextureRect
    /// </summary>
    public TextureRect L_TextureRect
    {
        get
        {
            if (_L_TextureRect == null) _L_TextureRect = new TextureRect((AbilityPanelPanel)this, GetNode<Godot.TextureRect>("TextureRect"));
            return _L_TextureRect;
        }
    }
    private TextureRect _L_TextureRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: AbilityPanel.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((AbilityPanelPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public AbilityPanel() : base(nameof(AbilityPanel))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: AbilityPanel.TextureRect
    /// </summary>
    public class TextureRect : UiNode<AbilityPanelPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(AbilityPanelPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: AbilityPanel.MarginContainer.VBoxContainer.Content.AbilityTitle
    /// </summary>
    public class AbilityTitle : UiNode<AbilityPanelPanel, Godot.Label, AbilityTitle>
    {
        public AbilityTitle(AbilityPanelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AbilityTitle Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: AbilityPanel.MarginContainer.VBoxContainer.Content.AbilityDesc
    /// </summary>
    public class AbilityDesc : UiNode<AbilityPanelPanel, Godot.Label, AbilityDesc>
    {
        public AbilityDesc(AbilityPanelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AbilityDesc Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: AbilityPanel.MarginContainer.VBoxContainer.Content
    /// </summary>
    public class Content : UiNode<AbilityPanelPanel, Godot.VBoxContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer.AbilityTitle
        /// </summary>
        public AbilityTitle L_AbilityTitle
        {
            get
            {
                if (_L_AbilityTitle == null) _L_AbilityTitle = new AbilityTitle(UiPanel, Instance.GetNode<Godot.Label>("AbilityTitle"));
                return _L_AbilityTitle;
            }
        }
        private AbilityTitle _L_AbilityTitle;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer.AbilityDesc
        /// </summary>
        public AbilityDesc L_AbilityDesc
        {
            get
            {
                if (_L_AbilityDesc == null) _L_AbilityDesc = new AbilityDesc(UiPanel, Instance.GetNode<Godot.Label>("AbilityDesc"));
                return _L_AbilityDesc;
            }
        }
        private AbilityDesc _L_AbilityDesc;

        public Content(AbilityPanelPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: AbilityPanel.MarginContainer.VBoxContainer.YesBtn
    /// </summary>
    public class YesBtn : UiNode<AbilityPanelPanel, Godot.Button, YesBtn>
    {
        public YesBtn(AbilityPanelPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override YesBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: AbilityPanel.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<AbilityPanelPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityPanel.MarginContainer.Content
        /// </summary>
        public Content L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Content"));
                return _L_Content;
            }
        }
        private Content _L_Content;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: AbilityPanel.MarginContainer.YesBtn
        /// </summary>
        public YesBtn L_YesBtn
        {
            get
            {
                if (_L_YesBtn == null) _L_YesBtn = new YesBtn(UiPanel, Instance.GetNode<Godot.Button>("YesBtn"));
                return _L_YesBtn;
            }
        }
        private YesBtn _L_YesBtn;

        public VBoxContainer(AbilityPanelPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: AbilityPanel.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<AbilityPanelPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityPanel.VBoxContainer
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

        public MarginContainer(AbilityPanelPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: AbilityPanel.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer.Content.AbilityTitle
    /// </summary>
    public AbilityTitle S_AbilityTitle => L_MarginContainer.L_VBoxContainer.L_Content.L_AbilityTitle;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer.Content.AbilityDesc
    /// </summary>
    public AbilityDesc S_AbilityDesc => L_MarginContainer.L_VBoxContainer.L_Content.L_AbilityDesc;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer.Content
    /// </summary>
    public Content S_Content => L_MarginContainer.L_VBoxContainer.L_Content;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer.YesBtn
    /// </summary>
    public YesBtn S_YesBtn => L_MarginContainer.L_VBoxContainer.L_YesBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityPanel.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: AbilityPanel.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
