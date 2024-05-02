namespace NovaDrift.Scripts.Ui.AbilityTree;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class AbilityTree : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: AbilityTree.HBoxContainer
    /// </summary>
    public HBoxContainer L_HBoxContainer
    {
        get
        {
            if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer((AbilityTreePanel)this, GetNode<Godot.HBoxContainer>("HBoxContainer"));
            return _L_HBoxContainer;
        }
    }
    private HBoxContainer _L_HBoxContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: AbilityTree.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((AbilityTreePanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;


    public AbilityTree() : base(nameof(AbilityTree))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_HBoxContainer;
        RecordNestedUi(inst1.L_StartAbility.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_StartAbility.Instance.OnCreateUi();
        inst1.L_StartAbility.Instance.OnInitNestedUi();

        var inst2 = L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst2.L_MiddleAbility1.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_MiddleAbility1.Instance.OnCreateUi();
        inst2.L_MiddleAbility1.Instance.OnInitNestedUi();

        var inst3 = L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst3.L_MiddleAbility2.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_MiddleAbility2.Instance.OnCreateUi();
        inst3.L_MiddleAbility2.Instance.OnInitNestedUi();

        var inst4 = L_HBoxContainer;
        RecordNestedUi(inst4.L_EndAbility.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_EndAbility.Instance.OnCreateUi();
        inst4.L_EndAbility.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 路径: AbilityTree.HBoxContainer.StartAbility
    /// </summary>
    public class StartAbility : UiNode<AbilityTreePanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel, StartAbility>
    {
        public StartAbility(AbilityTreePanel uiPanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel node) : base(uiPanel, node) {  }
        public override StartAbility Clone()
        {
            var uiNode = new StartAbility(UiPanel, (NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 路径: AbilityTree.HBoxContainer.VBoxContainer.MiddleAbility1
    /// </summary>
    public class MiddleAbility1 : UiNode<AbilityTreePanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel, MiddleAbility1>
    {
        public MiddleAbility1(AbilityTreePanel uiPanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel node) : base(uiPanel, node) {  }
        public override MiddleAbility1 Clone()
        {
            var uiNode = new MiddleAbility1(UiPanel, (NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 路径: AbilityTree.HBoxContainer.VBoxContainer.MiddleAbility2
    /// </summary>
    public class MiddleAbility2 : UiNode<AbilityTreePanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel, MiddleAbility2>
    {
        public MiddleAbility2(AbilityTreePanel uiPanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel node) : base(uiPanel, node) {  }
        public override MiddleAbility2 Clone()
        {
            var uiNode = new MiddleAbility2(UiPanel, (NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: AbilityTree.HBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<AbilityTreePanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.HBoxContainer.MiddleAbility1
        /// </summary>
        public MiddleAbility1 L_MiddleAbility1
        {
            get
            {
                if (_L_MiddleAbility1 == null) _L_MiddleAbility1 = new MiddleAbility1(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>("MiddleAbility1"));
                return _L_MiddleAbility1;
            }
        }
        private MiddleAbility1 _L_MiddleAbility1;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.HBoxContainer.MiddleAbility2
        /// </summary>
        public MiddleAbility2 L_MiddleAbility2
        {
            get
            {
                if (_L_MiddleAbility2 == null) _L_MiddleAbility2 = new MiddleAbility2(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>("MiddleAbility2"));
                return _L_MiddleAbility2;
            }
        }
        private MiddleAbility2 _L_MiddleAbility2;

        public VBoxContainer(AbilityTreePanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 路径: AbilityTree.HBoxContainer.EndAbility
    /// </summary>
    public class EndAbility : UiNode<AbilityTreePanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel, EndAbility>
    {
        public EndAbility(AbilityTreePanel uiPanel, NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel node) : base(uiPanel, node) {  }
        public override EndAbility Clone()
        {
            var uiNode = new EndAbility(UiPanel, (NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: AbilityTree.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<AbilityTreePanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.StartAbility
        /// </summary>
        public StartAbility L_StartAbility
        {
            get
            {
                if (_L_StartAbility == null) _L_StartAbility = new StartAbility(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>("StartAbility"));
                return _L_StartAbility;
            }
        }
        private StartAbility _L_StartAbility;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityTree.VBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.EndAbility
        /// </summary>
        public EndAbility L_EndAbility
        {
            get
            {
                if (_L_EndAbility == null) _L_EndAbility = new EndAbility(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel>("EndAbility"));
                return _L_EndAbility;
            }
        }
        private EndAbility _L_EndAbility;

        public HBoxContainer(AbilityTreePanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: AbilityTree.ColorRect
    /// </summary>
    public class ColorRect : UiNode<AbilityTreePanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(AbilityTreePanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.HBoxContainer.StartAbility
    /// </summary>
    public StartAbility S_StartAbility => L_HBoxContainer.L_StartAbility;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.HBoxContainer.VBoxContainer.MiddleAbility1
    /// </summary>
    public MiddleAbility1 S_MiddleAbility1 => L_HBoxContainer.L_VBoxContainer.L_MiddleAbility1;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.HBoxContainer.VBoxContainer.MiddleAbility2
    /// </summary>
    public MiddleAbility2 S_MiddleAbility2 => L_HBoxContainer.L_VBoxContainer.L_MiddleAbility2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: AbilityTree.HBoxContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_HBoxContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityItem.AbilityItemPanel"/>, 节点路径: AbilityTree.HBoxContainer.EndAbility
    /// </summary>
    public EndAbility S_EndAbility => L_HBoxContainer.L_EndAbility;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: AbilityTree.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: AbilityTree.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

}
