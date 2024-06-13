namespace NovaDrift.Scripts.Ui.GameOver;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GameOver : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GameOver.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((GameOverPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public GameOver() : base(nameof(GameOver))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2.Label
    /// </summary>
    public class Label : UiNode<GameOverPanel, Godot.Label, Label>
    {
        public Label(GameOverPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2.ScrollContainer.Items
    /// </summary>
    public class Items : UiNode<GameOverPanel, Godot.VBoxContainer, Items>
    {
        public Items(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Items Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<GameOverPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2.Items
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

        public ScrollContainer(GameOverPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<GameOverPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.ScrollContainer
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

        public VBoxContainer2(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer.Label
    /// </summary>
    public class Label_1 : UiNode<GameOverPanel, Godot.Label, Label_1>
    {
        public Label_1(GameOverPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<GameOverPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(GameOverPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer.AcidCoinsLabel
    /// </summary>
    public class AcidCoinsLabel : UiNode<GameOverPanel, Godot.Label, AcidCoinsLabel>
    {
        public AcidCoinsLabel(GameOverPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AcidCoinsLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<GameOverPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.TextureRect
        /// </summary>
        public TextureRect L_TextureRect
        {
            get
            {
                if (_L_TextureRect == null) _L_TextureRect = new TextureRect(UiPanel, Instance.GetNode<Godot.TextureRect>("TextureRect"));
                return _L_TextureRect;
            }
        }
        private TextureRect _L_TextureRect;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.AcidCoinsLabel
        /// </summary>
        public AcidCoinsLabel L_AcidCoinsLabel
        {
            get
            {
                if (_L_AcidCoinsLabel == null) _L_AcidCoinsLabel = new AcidCoinsLabel(UiPanel, Instance.GetNode<Godot.Label>("AcidCoinsLabel"));
                return _L_AcidCoinsLabel;
            }
        }
        private AcidCoinsLabel _L_AcidCoinsLabel;

        public HBoxContainer(GameOverPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3
    /// </summary>
    public class VBoxContainer3 : UiNode<GameOverPanel, Godot.VBoxContainer, VBoxContainer3>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2
        /// </summary>
        public VBoxContainer2 L_VBoxContainer2
        {
            get
            {
                if (_L_VBoxContainer2 == null) _L_VBoxContainer2 = new VBoxContainer2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer2"));
                return _L_VBoxContainer2;
            }
        }
        private VBoxContainer2 _L_VBoxContainer2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.HBoxContainer
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

        public VBoxContainer3(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer3 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public class ReStartBtn : UiNode<GameOverPanel, Godot.Button, ReStartBtn>
    {
        public ReStartBtn(GameOverPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ReStartBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer.BackToMainBtn
    /// </summary>
    public class BackToMainBtn : UiNode<GameOverPanel, Godot.Button, BackToMainBtn>
    {
        public BackToMainBtn(GameOverPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override BackToMainBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<GameOverPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.ReStartBtn
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.BackToMainBtn
        /// </summary>
        public BackToMainBtn L_BackToMainBtn
        {
            get
            {
                if (_L_BackToMainBtn == null) _L_BackToMainBtn = new BackToMainBtn(UiPanel, Instance.GetNode<Godot.Button>("BackToMainBtn"));
                return _L_BackToMainBtn;
            }
        }
        private BackToMainBtn _L_BackToMainBtn;

        public VBoxContainer_1(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<GameOverPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer3
        /// </summary>
        public VBoxContainer3 L_VBoxContainer3
        {
            get
            {
                if (_L_VBoxContainer3 == null) _L_VBoxContainer3 = new VBoxContainer3(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer3"));
                return _L_VBoxContainer3;
            }
        }
        private VBoxContainer3 _L_VBoxContainer3;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer
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

        public VBoxContainer(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GameOver.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<GameOverPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.VBoxContainer
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
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2.ScrollContainer.Items
    /// </summary>
    public Items S_Items => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3.L_VBoxContainer2.L_ScrollContainer.L_Items;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3.L_VBoxContainer2.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3.L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3.L_HBoxContainer.L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer.AcidCoinsLabel
    /// </summary>
    public AcidCoinsLabel S_AcidCoinsLabel => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3.L_HBoxContainer.L_AcidCoinsLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer3
    /// </summary>
    public VBoxContainer3 S_VBoxContainer3 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer.ReStartBtn
    /// </summary>
    public ReStartBtn S_ReStartBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_ReStartBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer.BackToMainBtn
    /// </summary>
    public BackToMainBtn S_BackToMainBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_BackToMainBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GameOver.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
