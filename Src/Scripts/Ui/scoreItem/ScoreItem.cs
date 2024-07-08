namespace NovaDrift.Scripts.Ui.ScoreItem;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class ScoreItem : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: ScoreItem.ScoreItem
    /// </summary>
    public ScoreItem_1 L_ScoreItem
    {
        get
        {
            if (_L_ScoreItem == null) _L_ScoreItem = new ScoreItem_1((ScoreItemPanel)this, GetNode<Godot.HBoxContainer>("ScoreItem"));
            return _L_ScoreItem;
        }
    }
    private ScoreItem_1 _L_ScoreItem;


    public ScoreItem() : base(nameof(ScoreItem))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: ScoreItem.ScoreItem.TextLabel
    /// </summary>
    public class TextLabel : UiNode<ScoreItemPanel, Godot.Label, TextLabel>
    {
        public TextLabel(ScoreItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TextLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: ScoreItem.ScoreItem.ScoreLabel
    /// </summary>
    public class ScoreLabel : UiNode<ScoreItemPanel, Godot.Label, ScoreLabel>
    {
        public ScoreLabel(ScoreItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override ScoreLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: ScoreItem.ScoreItem
    /// </summary>
    public class ScoreItem_1 : UiNode<ScoreItemPanel, Godot.HBoxContainer, ScoreItem_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreItem.TextLabel
        /// </summary>
        public TextLabel L_TextLabel
        {
            get
            {
                if (_L_TextLabel == null) _L_TextLabel = new TextLabel(UiPanel, Instance.GetNode<Godot.Label>("TextLabel"));
                return _L_TextLabel;
            }
        }
        private TextLabel _L_TextLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreItem.ScoreLabel
        /// </summary>
        public ScoreLabel L_ScoreLabel
        {
            get
            {
                if (_L_ScoreLabel == null) _L_ScoreLabel = new ScoreLabel(UiPanel, Instance.GetNode<Godot.Label>("ScoreLabel"));
                return _L_ScoreLabel;
            }
        }
        private ScoreLabel _L_ScoreLabel;

        public ScoreItem_1(ScoreItemPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override ScoreItem_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreItem.ScoreItem.TextLabel
    /// </summary>
    public TextLabel S_TextLabel => L_ScoreItem.L_TextLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreItem.ScoreItem.ScoreLabel
    /// </summary>
    public ScoreLabel S_ScoreLabel => L_ScoreItem.L_ScoreLabel;

}
