namespace NovaDrift.Scripts.Ui.QuestItem;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class QuestItem : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: QuestItem.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((QuestItemPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public QuestItem() : base(nameof(QuestItem))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ProgressBar"/>, 路径: QuestItem.PanelContainer.ProgressBar
    /// </summary>
    public class ProgressBar : UiNode<QuestItemPanel, Godot.ProgressBar, ProgressBar>
    {
        public ProgressBar(QuestItemPanel uiPanel, Godot.ProgressBar node) : base(uiPanel, node) {  }
        public override ProgressBar Clone() => new (UiPanel, (Godot.ProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.HBoxContainer.Title
    /// </summary>
    public class Title : UiNode<QuestItemPanel, Godot.Label, Title>
    {
        public Title(QuestItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Title Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.HBoxContainer.ProgressLabel
    /// </summary>
    public class ProgressLabel : UiNode<QuestItemPanel, Godot.Label, ProgressLabel>
    {
        public ProgressLabel(QuestItemPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override ProgressLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_1 : UiNode<QuestItemPanel, Godot.HBoxContainer, HBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.Title
        /// </summary>
        public Title L_Title
        {
            get
            {
                if (_L_Title == null) _L_Title = new Title(UiPanel, Instance.GetNode<Godot.Label>("Title"));
                return _L_Title;
            }
        }
        private Title _L_Title;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.ProgressLabel
        /// </summary>
        public ProgressLabel L_ProgressLabel
        {
            get
            {
                if (_L_ProgressLabel == null) _L_ProgressLabel = new ProgressLabel(UiPanel, Instance.GetNode<Godot.Label>("ProgressLabel"));
                return _L_ProgressLabel;
            }
        }
        private ProgressLabel _L_ProgressLabel;

        public HBoxContainer_1(QuestItemPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<QuestItemPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.HBoxContainer
        /// </summary>
        public HBoxContainer_1 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_1 _L_HBoxContainer;

        public VBoxContainer(QuestItemPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.Control
    /// </summary>
    public class Control : UiNode<QuestItemPanel, Godot.Control, Control>
    {
        public Control(QuestItemPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.Button
    /// </summary>
    public class Button : UiNode<QuestItemPanel, Godot.Button, Button>
    {
        public Button(QuestItemPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<QuestItemPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.VBoxContainer
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.Control
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.Button
        /// </summary>
        public Button L_Button
        {
            get
            {
                if (_L_Button == null) _L_Button = new Button(UiPanel, Instance.GetNode<Godot.Button>("Button"));
                return _L_Button;
            }
        }
        private Button _L_Button;

        public HBoxContainer(QuestItemPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: QuestItem.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<QuestItemPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: QuestItem.PanelContainer.HBoxContainer
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

        public MarginContainer(QuestItemPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: QuestItem.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<QuestItemPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: QuestItem.ProgressBar
        /// </summary>
        public ProgressBar L_ProgressBar
        {
            get
            {
                if (_L_ProgressBar == null) _L_ProgressBar = new ProgressBar(UiPanel, Instance.GetNode<Godot.ProgressBar>("ProgressBar"));
                return _L_ProgressBar;
            }
        }
        private ProgressBar _L_ProgressBar;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: QuestItem.MarginContainer
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

        public PanelContainer(QuestItemPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: QuestItem.PanelContainer.ProgressBar
    /// </summary>
    public ProgressBar S_ProgressBar => L_PanelContainer.L_ProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.HBoxContainer.Title
    /// </summary>
    public Title S_Title => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_HBoxContainer.L_Title;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer.HBoxContainer.ProgressLabel
    /// </summary>
    public ProgressLabel S_ProgressLabel => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_HBoxContainer.L_ProgressLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.Control
    /// </summary>
    public Control S_Control => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: QuestItem.PanelContainer.MarginContainer.HBoxContainer.Button
    /// </summary>
    public Button S_Button => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_Button;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: QuestItem.PanelContainer.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_PanelContainer.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: QuestItem.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
