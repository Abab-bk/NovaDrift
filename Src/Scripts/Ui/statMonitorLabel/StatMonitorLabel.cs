namespace NovaDrift.Scripts.Ui.StatMonitorLabel;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class StatMonitorLabel : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StatMonitorLabel.HBoxContainer
    /// </summary>
    public HBoxContainer L_HBoxContainer
    {
        get
        {
            if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer((StatMonitorLabelPanel)this, GetNode<Godot.HBoxContainer>("HBoxContainer"));
            return _L_HBoxContainer;
        }
    }
    private HBoxContainer _L_HBoxContainer;


    public StatMonitorLabel() : base(nameof(StatMonitorLabel))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: StatMonitorLabel.HBoxContainer.StatNameLabel
    /// </summary>
    public class StatNameLabel : UiNode<StatMonitorLabelPanel, Godot.Label, StatNameLabel>
    {
        public StatNameLabel(StatMonitorLabelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override StatNameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: StatMonitorLabel.HBoxContainer.StatNumLabel
    /// </summary>
    public class StatNumLabel : UiNode<StatMonitorLabelPanel, Godot.Label, StatNumLabel>
    {
        public StatNumLabel(StatMonitorLabelPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override StatNumLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: StatMonitorLabel.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<StatMonitorLabelPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatMonitorLabel.StatNameLabel
        /// </summary>
        public StatNameLabel L_StatNameLabel
        {
            get
            {
                if (_L_StatNameLabel == null) _L_StatNameLabel = new StatNameLabel(UiPanel, Instance.GetNode<Godot.Label>("StatNameLabel"));
                return _L_StatNameLabel;
            }
        }
        private StatNameLabel _L_StatNameLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatMonitorLabel.StatNumLabel
        /// </summary>
        public StatNumLabel L_StatNumLabel
        {
            get
            {
                if (_L_StatNumLabel == null) _L_StatNumLabel = new StatNumLabel(UiPanel, Instance.GetNode<Godot.Label>("StatNumLabel"));
                return _L_StatNumLabel;
            }
        }
        private StatNumLabel _L_StatNumLabel;

        public HBoxContainer(StatMonitorLabelPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatMonitorLabel.HBoxContainer.StatNameLabel
    /// </summary>
    public StatNameLabel S_StatNameLabel => L_HBoxContainer.L_StatNameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatMonitorLabel.HBoxContainer.StatNumLabel
    /// </summary>
    public StatNumLabel S_StatNumLabel => L_HBoxContainer.L_StatNumLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StatMonitorLabel.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_HBoxContainer;

}
