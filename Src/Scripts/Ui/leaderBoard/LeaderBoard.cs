namespace NovaDrift.Scripts.Ui.LeaderBoard;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class LeaderBoard : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: LeaderBoard.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((LeaderBoardPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public LeaderBoard() : base(nameof(LeaderBoard))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst1.L_LeaderItem.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_LeaderItem.Instance.OnCreateUi();
        inst1.L_LeaderItem.Instance.OnInitNestedUi();

        var inst2 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst2.L_LeaderItem2.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_LeaderItem2.Instance.OnCreateUi();
        inst2.L_LeaderItem2.Instance.OnInitNestedUi();

        var inst3 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst3.L_LeaderItem3.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_LeaderItem3.Instance.OnCreateUi();
        inst3.L_LeaderItem3.Instance.OnInitNestedUi();

        var inst4 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst4.L_LeaderItem4.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_LeaderItem4.Instance.OnCreateUi();
        inst4.L_LeaderItem4.Instance.OnInitNestedUi();

        var inst5 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst5.L_LeaderItem5.Instance, inst5, UiManager.RecordType.Open);
        inst5.L_LeaderItem5.Instance.OnCreateUi();
        inst5.L_LeaderItem5.Instance.OnInitNestedUi();

        var inst6 = L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer;
        RecordNestedUi(inst6.L_LeaderItem6.Instance, inst6, UiManager.RecordType.Open);
        inst6.L_LeaderItem6.Instance.OnCreateUi();
        inst6.L_LeaderItem6.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<LeaderBoardPanel, Godot.Label, Label>
    {
        public Label(LeaderBoardPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem
    /// </summary>
    public class LeaderItem : UiNode<LeaderBoardPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel, LeaderItem>
    {
        public LeaderItem(LeaderBoardPanel uiPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel node) : base(uiPanel, node) {  }
        public override LeaderItem Clone()
        {
            var uiNode = new LeaderItem(UiPanel, (NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem2
    /// </summary>
    public class LeaderItem2 : UiNode<LeaderBoardPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel, LeaderItem2>
    {
        public LeaderItem2(LeaderBoardPanel uiPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel node) : base(uiPanel, node) {  }
        public override LeaderItem2 Clone()
        {
            var uiNode = new LeaderItem2(UiPanel, (NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem3
    /// </summary>
    public class LeaderItem3 : UiNode<LeaderBoardPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel, LeaderItem3>
    {
        public LeaderItem3(LeaderBoardPanel uiPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel node) : base(uiPanel, node) {  }
        public override LeaderItem3 Clone()
        {
            var uiNode = new LeaderItem3(UiPanel, (NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem4
    /// </summary>
    public class LeaderItem4 : UiNode<LeaderBoardPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel, LeaderItem4>
    {
        public LeaderItem4(LeaderBoardPanel uiPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel node) : base(uiPanel, node) {  }
        public override LeaderItem4 Clone()
        {
            var uiNode = new LeaderItem4(UiPanel, (NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem5
    /// </summary>
    public class LeaderItem5 : UiNode<LeaderBoardPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel, LeaderItem5>
    {
        public LeaderItem5(LeaderBoardPanel uiPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel node) : base(uiPanel, node) {  }
        public override LeaderItem5 Clone()
        {
            var uiNode = new LeaderItem5(UiPanel, (NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem6
    /// </summary>
    public class LeaderItem6 : UiNode<LeaderBoardPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel, LeaderItem6>
    {
        public LeaderItem6(LeaderBoardPanel uiPanel, NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel node) : base(uiPanel, node) {  }
        public override LeaderItem6 Clone()
        {
            var uiNode = new LeaderItem6(UiPanel, (NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_2 : UiNode<LeaderBoardPanel, Godot.VBoxContainer, VBoxContainer_2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.LeaderItem
        /// </summary>
        public LeaderItem L_LeaderItem
        {
            get
            {
                if (_L_LeaderItem == null) _L_LeaderItem = new LeaderItem(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel>("LeaderItem"));
                return _L_LeaderItem;
            }
        }
        private LeaderItem _L_LeaderItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.LeaderItem2
        /// </summary>
        public LeaderItem2 L_LeaderItem2
        {
            get
            {
                if (_L_LeaderItem2 == null) _L_LeaderItem2 = new LeaderItem2(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel>("LeaderItem2"));
                return _L_LeaderItem2;
            }
        }
        private LeaderItem2 _L_LeaderItem2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.LeaderItem3
        /// </summary>
        public LeaderItem3 L_LeaderItem3
        {
            get
            {
                if (_L_LeaderItem3 == null) _L_LeaderItem3 = new LeaderItem3(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel>("LeaderItem3"));
                return _L_LeaderItem3;
            }
        }
        private LeaderItem3 _L_LeaderItem3;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.LeaderItem4
        /// </summary>
        public LeaderItem4 L_LeaderItem4
        {
            get
            {
                if (_L_LeaderItem4 == null) _L_LeaderItem4 = new LeaderItem4(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel>("LeaderItem4"));
                return _L_LeaderItem4;
            }
        }
        private LeaderItem4 _L_LeaderItem4;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.LeaderItem5
        /// </summary>
        public LeaderItem5 L_LeaderItem5
        {
            get
            {
                if (_L_LeaderItem5 == null) _L_LeaderItem5 = new LeaderItem5(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel>("LeaderItem5"));
                return _L_LeaderItem5;
            }
        }
        private LeaderItem5 _L_LeaderItem5;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.LeaderItem6
        /// </summary>
        public LeaderItem6 L_LeaderItem6
        {
            get
            {
                if (_L_LeaderItem6 == null) _L_LeaderItem6 = new LeaderItem6(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel>("LeaderItem6"));
                return _L_LeaderItem6;
            }
        }
        private LeaderItem6 _L_LeaderItem6;

        public VBoxContainer_2(LeaderBoardPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<LeaderBoardPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_2 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_2 _L_VBoxContainer;

        public HBoxContainer(LeaderBoardPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<LeaderBoardPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.HBoxContainer
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

        public MarginContainer_1(LeaderBoardPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<LeaderBoardPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(LeaderBoardPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<LeaderBoardPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.MarginContainer
        /// </summary>
        public MarginContainer_1 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_1(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_1 _L_MarginContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.CloseBtn
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

        public VBoxContainer_1(LeaderBoardPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: LeaderBoard.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<LeaderBoardPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: LeaderBoard.MarginContainer.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer
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

        public VBoxContainer(LeaderBoardPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: LeaderBoard.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<LeaderBoardPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: LeaderBoard.VBoxContainer
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

        public MarginContainer(LeaderBoardPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.Label
    /// </summary>
    public Label S_Label => L_MarginContainer.L_VBoxContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem
    /// </summary>
    public LeaderItem S_LeaderItem => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_LeaderItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem2
    /// </summary>
    public LeaderItem2 S_LeaderItem2 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_LeaderItem2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem3
    /// </summary>
    public LeaderItem3 S_LeaderItem3 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_LeaderItem3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem4
    /// </summary>
    public LeaderItem4 S_LeaderItem4 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_LeaderItem4;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem5
    /// </summary>
    public LeaderItem5 S_LeaderItem5 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_LeaderItem5;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.LeaderItem.LeaderItemPanel"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer.VBoxContainer.LeaderItem6
    /// </summary>
    public LeaderItem6 S_LeaderItem6 => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer.L_VBoxContainer.L_LeaderItem6;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: LeaderBoard.MarginContainer.VBoxContainer.VBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_CloseBtn;

}
