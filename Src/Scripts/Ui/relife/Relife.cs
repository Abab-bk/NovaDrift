namespace NovaDrift.Scripts.Ui.Relife;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Relife : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Relife.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((RelifePanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Relife.VBoxContainer2
    /// </summary>
    public VBoxContainer2 L_VBoxContainer2
    {
        get
        {
            if (_L_VBoxContainer2 == null) _L_VBoxContainer2 = new VBoxContainer2((RelifePanel)this, GetNode<Godot.VBoxContainer>("VBoxContainer2"));
            return _L_VBoxContainer2;
        }
    }
    private VBoxContainer2 _L_VBoxContainer2;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Timer"/>, 节点路径: Relife.Timer
    /// </summary>
    public Timer L_Timer
    {
        get
        {
            if (_L_Timer == null) _L_Timer = new Timer((RelifePanel)this, GetNode<Godot.Timer>("Timer"));
            return _L_Timer;
        }
    }
    private Timer _L_Timer;


    public Relife() : base(nameof(Relife))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: Relife.ColorRect
    /// </summary>
    public class ColorRect : UiNode<RelifePanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(RelifePanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Relife.VBoxContainer2.Label
    /// </summary>
    public class Label : UiNode<RelifePanel, Godot.Label, Label>
    {
        public Label(RelifePanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Relife.VBoxContainer2.VBoxContainer.RelifeBtn
    /// </summary>
    public class RelifeBtn : UiNode<RelifePanel, Godot.Button, RelifeBtn>
    {
        public RelifeBtn(RelifePanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override RelifeBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Relife.VBoxContainer2.VBoxContainer.ContinueBtn
    /// </summary>
    public class ContinueBtn : UiNode<RelifePanel, Godot.Button, ContinueBtn>
    {
        public ContinueBtn(RelifePanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ContinueBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Relife.VBoxContainer2.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<RelifePanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Relife.VBoxContainer2.RelifeBtn
        /// </summary>
        public RelifeBtn L_RelifeBtn
        {
            get
            {
                if (_L_RelifeBtn == null) _L_RelifeBtn = new RelifeBtn(UiPanel, Instance.GetNode<Godot.Button>("RelifeBtn"));
                return _L_RelifeBtn;
            }
        }
        private RelifeBtn _L_RelifeBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Relife.VBoxContainer2.ContinueBtn
        /// </summary>
        public ContinueBtn L_ContinueBtn
        {
            get
            {
                if (_L_ContinueBtn == null) _L_ContinueBtn = new ContinueBtn(UiPanel, Instance.GetNode<Godot.Button>("ContinueBtn"));
                return _L_ContinueBtn;
            }
        }
        private ContinueBtn _L_ContinueBtn;

        public VBoxContainer(RelifePanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Relife.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<RelifePanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Relife.Label
        /// </summary>
        public Label L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Relife.VBoxContainer
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

        public VBoxContainer2(RelifePanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Timer"/>, 路径: Relife.Timer
    /// </summary>
    public class Timer : UiNode<RelifePanel, Godot.Timer, Timer>
    {
        public Timer(RelifePanel uiPanel, Godot.Timer node) : base(uiPanel, node) {  }
        public override Timer Clone() => new (UiPanel, (Godot.Timer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Relife.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Relife.VBoxContainer2.Label
    /// </summary>
    public Label S_Label => L_VBoxContainer2.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Relife.VBoxContainer2.VBoxContainer.RelifeBtn
    /// </summary>
    public RelifeBtn S_RelifeBtn => L_VBoxContainer2.L_VBoxContainer.L_RelifeBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Relife.VBoxContainer2.VBoxContainer.ContinueBtn
    /// </summary>
    public ContinueBtn S_ContinueBtn => L_VBoxContainer2.L_VBoxContainer.L_ContinueBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Relife.VBoxContainer2.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_VBoxContainer2.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Relife.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Timer"/>, 节点路径: Relife.Timer
    /// </summary>
    public Timer S_Timer => L_Timer;

}
