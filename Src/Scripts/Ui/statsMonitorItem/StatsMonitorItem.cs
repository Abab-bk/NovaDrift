namespace NovaDrift.Scripts.Ui.StatsMonitorItem;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class StatsMonitorItem : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StatsMonitorItem.HBoxContainer
    /// </summary>
    public HBoxContainer L_HBoxContainer
    {
        get
        {
            if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer((StatsMonitorItemPanel)this, GetNode<Godot.HBoxContainer>("HBoxContainer"));
            return _L_HBoxContainer;
        }
    }
    private HBoxContainer _L_HBoxContainer;


    public StatsMonitorItem() : base(nameof(StatsMonitorItem))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: StatsMonitorItem.HBoxContainer.PropertyLabel
    /// </summary>
    public class PropertyLabel : UiNode<StatsMonitorItemPanel, Godot.Label, PropertyLabel>
    {
        public PropertyLabel(StatsMonitorItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override PropertyLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: StatsMonitorItem.HBoxContainer.ValueLabel
    /// </summary>
    public class ValueLabel : UiNode<StatsMonitorItemPanel, Godot.Label, ValueLabel>
    {
        public ValueLabel(StatsMonitorItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override ValueLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: StatsMonitorItem.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<StatsMonitorItemPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatsMonitorItem.PropertyLabel
        /// </summary>
        public PropertyLabel L_PropertyLabel
        {
            get
            {
                if (_L_PropertyLabel == null) _L_PropertyLabel = new PropertyLabel(UiPanel, Instance.GetNode<Godot.Label>("PropertyLabel"));
                return _L_PropertyLabel;
            }
        }
        private PropertyLabel _L_PropertyLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatsMonitorItem.ValueLabel
        /// </summary>
        public ValueLabel L_ValueLabel
        {
            get
            {
                if (_L_ValueLabel == null) _L_ValueLabel = new ValueLabel(UiPanel, Instance.GetNode<Godot.Label>("ValueLabel"));
                return _L_ValueLabel;
            }
        }
        private ValueLabel _L_ValueLabel;

        public HBoxContainer(StatsMonitorItemPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatsMonitorItem.HBoxContainer.PropertyLabel
    /// </summary>
    public PropertyLabel S_PropertyLabel => L_HBoxContainer.L_PropertyLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: StatsMonitorItem.HBoxContainer.ValueLabel
    /// </summary>
    public ValueLabel S_ValueLabel => L_HBoxContainer.L_ValueLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StatsMonitorItem.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_HBoxContainer;

}
