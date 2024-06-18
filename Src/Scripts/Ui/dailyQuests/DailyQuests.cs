namespace NovaDrift.Scripts.Ui.DailyQuests;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class DailyQuests : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: DailyQuests.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((DailyQuestsPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public DailyQuests() : base(nameof(DailyQuests))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<DailyQuestsPanel, Godot.Label, Label>
    {
        public Label(DailyQuestsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer.Label
    /// </summary>
    public class Label_1 : UiNode<DailyQuestsPanel, Godot.Label, Label_1>
    {
        public Label_1(DailyQuestsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer.ScrollContainer.FinishedQuests
    /// </summary>
    public class FinishedQuests : UiNode<DailyQuestsPanel, Godot.VBoxContainer, FinishedQuests>
    {
        public FinishedQuests(DailyQuestsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override FinishedQuests Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<DailyQuestsPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer.FinishedQuests
        /// </summary>
        public FinishedQuests L_FinishedQuests
        {
            get
            {
                if (_L_FinishedQuests == null) _L_FinishedQuests = new FinishedQuests(UiPanel, Instance.GetNode<Godot.VBoxContainer>("FinishedQuests"));
                return _L_FinishedQuests;
            }
        }
        private FinishedQuests _L_FinishedQuests;

        public ScrollContainer(DailyQuestsPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer
    /// </summary>
    public class FinishedContainer : UiNode<DailyQuestsPanel, Godot.VBoxContainer, FinishedContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.Label
        /// </summary>
        public Label_1 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_1(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_1 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.ScrollContainer
        /// </summary>
        public ScrollContainer L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer _L_ScrollContainer;

        public FinishedContainer(DailyQuestsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override FinishedContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer.Label
    /// </summary>
    public class Label_2 : UiNode<DailyQuestsPanel, Godot.Label, Label_2>
    {
        public Label_2(DailyQuestsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer.ScrollContainer.UnfinishedQuests
    /// </summary>
    public class UnfinishedQuests : UiNode<DailyQuestsPanel, Godot.VBoxContainer, UnfinishedQuests>
    {
        public UnfinishedQuests(DailyQuestsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override UnfinishedQuests Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer_1 : UiNode<DailyQuestsPanel, Godot.ScrollContainer, ScrollContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer.UnfinishedQuests
        /// </summary>
        public UnfinishedQuests L_UnfinishedQuests
        {
            get
            {
                if (_L_UnfinishedQuests == null) _L_UnfinishedQuests = new UnfinishedQuests(UiPanel, Instance.GetNode<Godot.VBoxContainer>("UnfinishedQuests"));
                return _L_UnfinishedQuests;
            }
        }
        private UnfinishedQuests _L_UnfinishedQuests;

        public ScrollContainer_1(DailyQuestsPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_1 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer
    /// </summary>
    public class UnfinishedContainer : UiNode<DailyQuestsPanel, Godot.VBoxContainer, UnfinishedContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.Label
        /// </summary>
        public Label_2 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_2(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_2 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.ScrollContainer
        /// </summary>
        public ScrollContainer_1 L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer_1(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer_1 _L_ScrollContainer;

        public UnfinishedContainer(DailyQuestsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override UnfinishedContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<DailyQuestsPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.FinishedContainer
        /// </summary>
        public FinishedContainer L_FinishedContainer
        {
            get
            {
                if (_L_FinishedContainer == null) _L_FinishedContainer = new FinishedContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("FinishedContainer"));
                return _L_FinishedContainer;
            }
        }
        private FinishedContainer _L_FinishedContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.UnfinishedContainer
        /// </summary>
        public UnfinishedContainer L_UnfinishedContainer
        {
            get
            {
                if (_L_UnfinishedContainer == null) _L_UnfinishedContainer = new UnfinishedContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("UnfinishedContainer"));
                return _L_UnfinishedContainer;
            }
        }
        private UnfinishedContainer _L_UnfinishedContainer;

        public VBoxContainer_1(DailyQuestsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.Control
    /// </summary>
    public class Control : UiNode<DailyQuestsPanel, Godot.Control, Control>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_1 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_1(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_1 _L_VBoxContainer;

        public Control(DailyQuestsPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: DailyQuests.MarginContainer.VBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<DailyQuestsPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(DailyQuestsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: DailyQuests.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<DailyQuestsPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: DailyQuests.MarginContainer.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: DailyQuests.MarginContainer.Control
        /// </summary>
        public Control L_Control
        {
            get
            {
                if (_L_Control == null) _L_Control = new Control(UiPanel, Instance.GetNode<Godot.Control>("Control"));
                return _L_Control;
            }
        }
        private Control _L_Control;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: DailyQuests.MarginContainer.CloseBtn
        /// </summary>
        public CloseBtn L_CloseBtn
        {
            get
            {
                if (_L_CloseBtn == null) _L_CloseBtn = new CloseBtn(UiPanel, Instance.GetNode<Godot.Button>("CloseBtn"));
                return _L_CloseBtn;
            }
        }
        private CloseBtn _L_CloseBtn;

        public VBoxContainer(DailyQuestsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: DailyQuests.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<DailyQuestsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.VBoxContainer
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

        public MarginContainer(DailyQuestsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer.ScrollContainer.FinishedQuests
    /// </summary>
    public FinishedQuests S_FinishedQuests => L_MarginContainer.L_VBoxContainer.L_Control.L_VBoxContainer.L_FinishedContainer.L_ScrollContainer.L_FinishedQuests;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.FinishedContainer
    /// </summary>
    public FinishedContainer S_FinishedContainer => L_MarginContainer.L_VBoxContainer.L_Control.L_VBoxContainer.L_FinishedContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer.ScrollContainer.UnfinishedQuests
    /// </summary>
    public UnfinishedQuests S_UnfinishedQuests => L_MarginContainer.L_VBoxContainer.L_Control.L_VBoxContainer.L_UnfinishedContainer.L_ScrollContainer.L_UnfinishedQuests;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control.VBoxContainer.UnfinishedContainer
    /// </summary>
    public UnfinishedContainer S_UnfinishedContainer => L_MarginContainer.L_VBoxContainer.L_Control.L_VBoxContainer.L_UnfinishedContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.Control
    /// </summary>
    public Control S_Control => L_MarginContainer.L_VBoxContainer.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: DailyQuests.MarginContainer.VBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_MarginContainer.L_VBoxContainer.L_CloseBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: DailyQuests.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
