namespace NovaDrift.Scripts.Ui.GoodsDetails;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GoodsDetails : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsDetails.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((GoodsDetailsPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public GoodsDetails() : base(nameof(GoodsDetails))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsDetails.MarginContainer.HBoxContainer.VBoxContainer.TitleLabel
    /// </summary>
    public class TitleLabel : UiNode<GoodsDetailsPanel, Godot.Label, TitleLabel>
    {
        public TitleLabel(GoodsDetailsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TitleLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GoodsDetails.MarginContainer.HBoxContainer.VBoxContainer.DescLabel
    /// </summary>
    public class DescLabel : UiNode<GoodsDetailsPanel, Godot.Label, DescLabel>
    {
        public DescLabel(GoodsDetailsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override DescLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GoodsDetails.MarginContainer.HBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<GoodsDetailsPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsDetails.MarginContainer.HBoxContainer.TitleLabel
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsDetails.MarginContainer.HBoxContainer.DescLabel
        /// </summary>
        public DescLabel L_DescLabel
        {
            get
            {
                if (_L_DescLabel == null) _L_DescLabel = new DescLabel(UiPanel, Instance.GetNode<Godot.Label>("DescLabel"));
                return _L_DescLabel;
            }
        }
        private DescLabel _L_DescLabel;

        public VBoxContainer(GoodsDetailsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GoodsDetails.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<GoodsDetailsPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsDetails.MarginContainer.VBoxContainer
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

        public HBoxContainer(GoodsDetailsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GoodsDetails.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<GoodsDetailsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsDetails.HBoxContainer
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

        public MarginContainer(GoodsDetailsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsDetails.MarginContainer.HBoxContainer.VBoxContainer.TitleLabel
    /// </summary>
    public TitleLabel S_TitleLabel => L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_TitleLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GoodsDetails.MarginContainer.HBoxContainer.VBoxContainer.DescLabel
    /// </summary>
    public DescLabel S_DescLabel => L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_DescLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GoodsDetails.MarginContainer.HBoxContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_MarginContainer.L_HBoxContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GoodsDetails.MarginContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_MarginContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GoodsDetails.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
