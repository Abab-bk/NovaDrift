namespace NovaDrift.Scripts.Ui.ScoreLabel;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class ScoreLabel : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: ScoreLabel.HBoxContainer
    /// </summary>
    public HBoxContainer L_HBoxContainer
    {
        get
        {
            if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer((ScoreLabelPanel)this, GetNode<Godot.HBoxContainer>("HBoxContainer"));
            return _L_HBoxContainer;
        }
    }
    private HBoxContainer _L_HBoxContainer;


    public ScoreLabel() : base(nameof(ScoreLabel))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: ScoreLabel.HBoxContainer.TextLabel
    /// </summary>
    public class TextLabel : UiNode<ScoreLabelPanel, Godot.Label, TextLabel>
    {
        public TextLabel(ScoreLabelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TextLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: ScoreLabel.HBoxContainer.NumberLabel
    /// </summary>
    public class NumberLabel : UiNode<ScoreLabelPanel, Godot.Label, NumberLabel>
    {
        public NumberLabel(ScoreLabelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override NumberLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: ScoreLabel.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<ScoreLabelPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreLabel.TextLabel
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreLabel.NumberLabel
        /// </summary>
        public NumberLabel L_NumberLabel
        {
            get
            {
                if (_L_NumberLabel == null) _L_NumberLabel = new NumberLabel(UiPanel, Instance.GetNode<Godot.Label>("NumberLabel"));
                return _L_NumberLabel;
            }
        }
        private NumberLabel _L_NumberLabel;

        public HBoxContainer(ScoreLabelPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreLabel.HBoxContainer.TextLabel
    /// </summary>
    public TextLabel S_TextLabel => L_HBoxContainer.L_TextLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: ScoreLabel.HBoxContainer.NumberLabel
    /// </summary>
    public NumberLabel S_NumberLabel => L_HBoxContainer.L_NumberLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: ScoreLabel.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_HBoxContainer;

}
