namespace NovaDrift.Scripts.Ui.StatsMonitor;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class StatsMonitor : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: StatsMonitor.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((StatsMonitorPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public StatsMonitor() : base(nameof(StatsMonitor))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_PanelContainer.L_MarginContainer.L_Items;
        RecordNestedUi(inst1.L_StatsMonitorItem.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_StatsMonitorItem.Instance.OnCreateUi();
        inst1.L_StatsMonitorItem.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel"/>, 路径: StatsMonitor.PanelContainer.MarginContainer.Items.StatsMonitorItem
    /// </summary>
    public class StatsMonitorItem : UiNode<StatsMonitorPanel, NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel, StatsMonitorItem>
    {
        public StatsMonitorItem(StatsMonitorPanel uiPanel, NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel node) : base(uiPanel, node) {  }
        public override StatsMonitorItem Clone()
        {
            var uiNode = new StatsMonitorItem(UiPanel, (NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: StatsMonitor.PanelContainer.MarginContainer.Items
    /// </summary>
    public class Items : UiNode<StatsMonitorPanel, Godot.VBoxContainer, Items>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel"/>, 节点路径: StatsMonitor.PanelContainer.MarginContainer.StatsMonitorItem
        /// </summary>
        public StatsMonitorItem L_StatsMonitorItem
        {
            get
            {
                if (_L_StatsMonitorItem == null) _L_StatsMonitorItem = new StatsMonitorItem(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel>("StatsMonitorItem"));
                return _L_StatsMonitorItem;
            }
        }
        private StatsMonitorItem _L_StatsMonitorItem;

        public Items(StatsMonitorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Items Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: StatsMonitor.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<StatsMonitorPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: StatsMonitor.PanelContainer.Items
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

        public MarginContainer(StatsMonitorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: StatsMonitor.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<StatsMonitorPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StatsMonitor.MarginContainer
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

        public PanelContainer(StatsMonitorPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.StatsMonitorItem.StatsMonitorItemPanel"/>, 节点路径: StatsMonitor.PanelContainer.MarginContainer.Items.StatsMonitorItem
    /// </summary>
    public StatsMonitorItem S_StatsMonitorItem => L_PanelContainer.L_MarginContainer.L_Items.L_StatsMonitorItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: StatsMonitor.PanelContainer.MarginContainer.Items
    /// </summary>
    public Items S_Items => L_PanelContainer.L_MarginContainer.L_Items;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StatsMonitor.PanelContainer.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_PanelContainer.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: StatsMonitor.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
