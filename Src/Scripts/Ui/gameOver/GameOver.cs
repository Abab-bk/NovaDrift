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

        var inst1 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst1.L_ScoreLabel.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_ScoreLabel.Instance.OnCreateUi();
        inst1.L_ScoreLabel.Instance.OnInitNestedUi();

        var inst2 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst2.L_ScoreLabel2.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_ScoreLabel2.Instance.OnCreateUi();
        inst2.L_ScoreLabel2.Instance.OnInitNestedUi();

        var inst3 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst3.L_ScoreLabel3.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_ScoreLabel3.Instance.OnCreateUi();
        inst3.L_ScoreLabel3.Instance.OnInitNestedUi();

        var inst4 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst4.L_ScoreLabel4.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_ScoreLabel4.Instance.OnCreateUi();
        inst4.L_ScoreLabel4.Instance.OnInitNestedUi();

        var inst5 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst5.L_ScoreLabel5.Instance, inst5, UiManager.RecordType.Open);
        inst5.L_ScoreLabel5.Instance.OnCreateUi();
        inst5.L_ScoreLabel5.Instance.OnInitNestedUi();

        var inst6 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst6.L_ScoreLabel6.Instance, inst6, UiManager.RecordType.Open);
        inst6.L_ScoreLabel6.Instance.OnCreateUi();
        inst6.L_ScoreLabel6.Instance.OnInitNestedUi();

        var inst7 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;
        RecordNestedUi(inst7.L_ScoreLabel7.Instance, inst7, UiManager.RecordType.Open);
        inst7.L_ScoreLabel7.Instance.OnCreateUi();
        inst7.L_ScoreLabel7.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.Label
    /// </summary>
    public class Label : UiNode<GameOverPanel, Godot.Label, Label>
    {
        public Label(GameOverPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel
    /// </summary>
    public class ScoreLabel : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel>
    {
        public ScoreLabel(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel Clone()
        {
            var uiNode = new ScoreLabel(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel2
    /// </summary>
    public class ScoreLabel2 : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel2>
    {
        public ScoreLabel2(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel2 Clone()
        {
            var uiNode = new ScoreLabel2(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel3
    /// </summary>
    public class ScoreLabel3 : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel3>
    {
        public ScoreLabel3(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel3 Clone()
        {
            var uiNode = new ScoreLabel3(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel4
    /// </summary>
    public class ScoreLabel4 : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel4>
    {
        public ScoreLabel4(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel4 Clone()
        {
            var uiNode = new ScoreLabel4(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel5
    /// </summary>
    public class ScoreLabel5 : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel5>
    {
        public ScoreLabel5(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel5 Clone()
        {
            var uiNode = new ScoreLabel5(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel6
    /// </summary>
    public class ScoreLabel6 : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel6>
    {
        public ScoreLabel6(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel6 Clone()
        {
            var uiNode = new ScoreLabel6(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel7
    /// </summary>
    public class ScoreLabel7 : UiNode<GameOverPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel, ScoreLabel7>
    {
        public ScoreLabel7(GameOverPanel uiPanel, NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel node) : base(uiPanel, node) {  }
        public override ScoreLabel7 Clone()
        {
            var uiNode = new ScoreLabel7(UiPanel, (NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items
    /// </summary>
    public class Items : UiNode<GameOverPanel, Godot.VBoxContainer, Items>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel
        /// </summary>
        public ScoreLabel L_ScoreLabel
        {
            get
            {
                if (_L_ScoreLabel == null) _L_ScoreLabel = new ScoreLabel(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel"));
                return _L_ScoreLabel;
            }
        }
        private ScoreLabel _L_ScoreLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel2
        /// </summary>
        public ScoreLabel2 L_ScoreLabel2
        {
            get
            {
                if (_L_ScoreLabel2 == null) _L_ScoreLabel2 = new ScoreLabel2(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel2"));
                return _L_ScoreLabel2;
            }
        }
        private ScoreLabel2 _L_ScoreLabel2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel3
        /// </summary>
        public ScoreLabel3 L_ScoreLabel3
        {
            get
            {
                if (_L_ScoreLabel3 == null) _L_ScoreLabel3 = new ScoreLabel3(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel3"));
                return _L_ScoreLabel3;
            }
        }
        private ScoreLabel3 _L_ScoreLabel3;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel4
        /// </summary>
        public ScoreLabel4 L_ScoreLabel4
        {
            get
            {
                if (_L_ScoreLabel4 == null) _L_ScoreLabel4 = new ScoreLabel4(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel4"));
                return _L_ScoreLabel4;
            }
        }
        private ScoreLabel4 _L_ScoreLabel4;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel5
        /// </summary>
        public ScoreLabel5 L_ScoreLabel5
        {
            get
            {
                if (_L_ScoreLabel5 == null) _L_ScoreLabel5 = new ScoreLabel5(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel5"));
                return _L_ScoreLabel5;
            }
        }
        private ScoreLabel5 _L_ScoreLabel5;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel6
        /// </summary>
        public ScoreLabel6 L_ScoreLabel6
        {
            get
            {
                if (_L_ScoreLabel6 == null) _L_ScoreLabel6 = new ScoreLabel6(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel6"));
                return _L_ScoreLabel6;
            }
        }
        private ScoreLabel6 _L_ScoreLabel6;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.ScoreLabel7
        /// </summary>
        public ScoreLabel7 L_ScoreLabel7
        {
            get
            {
                if (_L_ScoreLabel7 == null) _L_ScoreLabel7 = new ScoreLabel7(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel>("ScoreLabel7"));
                return _L_ScoreLabel7;
            }
        }
        private ScoreLabel7 _L_ScoreLabel7;

        public Items(GameOverPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Items Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<GameOverPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.Items
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
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<GameOverPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.ScrollContainer
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer2
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
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.Label
    /// </summary>
    public Label S_Label => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel
    /// </summary>
    public ScoreLabel S_ScoreLabel => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel2
    /// </summary>
    public ScoreLabel2 S_ScoreLabel2 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel3
    /// </summary>
    public ScoreLabel3 S_ScoreLabel3 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel4
    /// </summary>
    public ScoreLabel4 S_ScoreLabel4 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel4;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel5
    /// </summary>
    public ScoreLabel5 S_ScoreLabel5 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel5;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel6
    /// </summary>
    public ScoreLabel6 S_ScoreLabel6 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel6;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.ScoreLabel.ScoreLabelPanel"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items.ScoreLabel7
    /// </summary>
    public ScoreLabel7 S_ScoreLabel7 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items.L_ScoreLabel7;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer.Items
    /// </summary>
    public Items S_Items => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer.L_Items;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GameOver.MarginContainer.VBoxContainer.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer2;

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
