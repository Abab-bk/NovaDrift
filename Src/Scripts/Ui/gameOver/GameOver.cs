namespace NovaDrift.Scripts.Ui.GameOver;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GameOver : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GameOver.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((GameOverPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public GameOver() : base(nameof(GameOver))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GameOver.PanelContainer.MarginContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<GameOverPanel, Godot.Label, Label>
    {
        public Label(GameOverPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GameOver.PanelContainer.MarginContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public class ReStartBtn : UiNode<GameOverPanel, Godot.Button, ReStartBtn>
    {
        public ReStartBtn(GameOverPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ReStartBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.PanelContainer.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<GameOverPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.PanelContainer.MarginContainer.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GameOver.PanelContainer.MarginContainer.ReStartBtn
        /// </summary>
        public ReStartBtn L_ReStartBtn
        {
            get
            {
                if (_L_ReStartBtn == null) _L_ReStartBtn = new ReStartBtn(UiPanel, Instance.GetNode<Godot.Button>("ReStartBtn"));
                return _L_ReStartBtn;
            }
        }
        private ReStartBtn _L_ReStartBtn;

        public VBoxContainer(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GameOver.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<GameOverPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.PanelContainer.VBoxContainer
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

        public MarginContainer(GameOverPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GameOver.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<GameOverPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GameOver.MarginContainer
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

        public PanelContainer(GameOverPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.PanelContainer.MarginContainer.VBoxContainer.Label
    /// </summary>
    public Label S_Label => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GameOver.PanelContainer.MarginContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public ReStartBtn S_ReStartBtn => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ReStartBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.PanelContainer.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_PanelContainer.L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GameOver.PanelContainer.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_PanelContainer.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GameOver.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
