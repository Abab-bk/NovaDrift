namespace NovaDrift.Scripts.Ui.AbilityPanel;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class AbilityPanel : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityPanel.Content
    /// </summary>
    public Content L_Content
    {
        get
        {
            if (_L_Content == null) _L_Content = new Content((AbilityPanelPanel)this, GetNode<Godot.VBoxContainer>("Content"));
            return _L_Content;
        }
    }
    private Content _L_Content;


    public AbilityPanel() : base(nameof(AbilityPanel))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: AbilityPanel.Content.AbilityTitle
    /// </summary>
    public class AbilityTitle : UiNode<AbilityPanelPanel, Godot.Label, AbilityTitle>
    {
        public AbilityTitle(AbilityPanelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AbilityTitle Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: AbilityPanel.Content.AbilityDesc
    /// </summary>
    public class AbilityDesc : UiNode<AbilityPanelPanel, Godot.Label, AbilityDesc>
    {
        public AbilityDesc(AbilityPanelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AbilityDesc Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: AbilityPanel.Content
    /// </summary>
    public class Content : UiNode<AbilityPanelPanel, Godot.VBoxContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.AbilityTitle
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.AbilityDesc
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
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.Content.AbilityTitle
    /// </summary>
    public AbilityTitle S_AbilityTitle => L_Content.L_AbilityTitle;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: AbilityPanel.Content.AbilityDesc
    /// </summary>
    public AbilityDesc S_AbilityDesc => L_Content.L_AbilityDesc;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityPanel.Content
    /// </summary>
    public Content S_Content => L_Content;

}
