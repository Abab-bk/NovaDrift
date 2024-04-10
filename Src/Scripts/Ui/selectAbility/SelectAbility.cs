namespace NovaDrift.Scripts.Ui.SelectAbility;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class SelectAbility : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: SelectAbility.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((SelectAbilityPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public SelectAbility() : base(nameof(SelectAbility))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.GridContainer"/>, 路径: SelectAbility.PanelContainer.HBoxContainer.GridContainer
    /// </summary>
    public class GridContainer : UiNode<SelectAbilityPanel, Godot.GridContainer, GridContainer>
    {
        public GridContainer(SelectAbilityPanel uiPanel, Godot.GridContainer node) : base(uiPanel, node) {  }
        public override GridContainer Clone() => new (UiPanel, (Godot.GridContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.VBoxContainer.AbilityTitle
    /// </summary>
    public class AbilityTitle : UiNode<SelectAbilityPanel, Godot.Label, AbilityTitle>
    {
        public AbilityTitle(SelectAbilityPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AbilityTitle Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.VBoxContainer.AbilityDesc
    /// </summary>
    public class AbilityDesc : UiNode<SelectAbilityPanel, Godot.Label, AbilityDesc>
    {
        public AbilityDesc(SelectAbilityPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AbilityDesc Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<SelectAbilityPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.AbilityTitle
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.AbilityDesc
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

        public VBoxContainer(SelectAbilityPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer
    /// </summary>
    public class PanelContainer_1 : UiNode<SelectAbilityPanel, Godot.PanelContainer, PanelContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.VBoxContainer
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

        public PanelContainer_1(SelectAbilityPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer_1 Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.PanelContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<SelectAbilityPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.PanelContainer.GridContainer
        /// </summary>
        public GridContainer L_GridContainer
        {
            get
            {
                if (_L_GridContainer == null) _L_GridContainer = new GridContainer(UiPanel, Instance.GetNode<Godot.GridContainer>("GridContainer"));
                return _L_GridContainer;
            }
        }
        private GridContainer _L_GridContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: SelectAbility.PanelContainer.PanelContainer
        /// </summary>
        public PanelContainer_1 L_PanelContainer
        {
            get
            {
                if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer_1(UiPanel, Instance.GetNode<Godot.PanelContainer>("PanelContainer"));
                return _L_PanelContainer;
            }
        }
        private PanelContainer_1 _L_PanelContainer;

        public HBoxContainer(SelectAbilityPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: SelectAbility.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<SelectAbilityPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.HBoxContainer
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

        public PanelContainer(SelectAbilityPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.GridContainer
    /// </summary>
    public GridContainer S_GridContainer => L_PanelContainer.L_HBoxContainer.L_GridContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.VBoxContainer.AbilityTitle
    /// </summary>
    public AbilityTitle S_AbilityTitle => L_PanelContainer.L_HBoxContainer.L_PanelContainer.L_VBoxContainer.L_AbilityTitle;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.VBoxContainer.AbilityDesc
    /// </summary>
    public AbilityDesc S_AbilityDesc => L_PanelContainer.L_HBoxContainer.L_PanelContainer.L_VBoxContainer.L_AbilityDesc;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer.PanelContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_PanelContainer.L_HBoxContainer.L_PanelContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.PanelContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_PanelContainer.L_HBoxContainer;

}
