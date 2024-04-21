namespace NovaDrift.Scripts.Ui.SelectAbility;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class SelectAbility : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: SelectAbility.Content
    /// </summary>
    public Content L_Content
    {
        get
        {
            if (_L_Content == null) _L_Content = new Content((SelectAbilityPanel)this, GetNode<Godot.PanelContainer>("Content"));
            return _L_Content;
        }
    }
    private Content _L_Content;


    public SelectAbility() : base(nameof(SelectAbility))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_Content.L_VBoxContainer.L_Content;
        RecordNestedUi(inst1.L_AbilityPanel.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_AbilityPanel.Instance.OnCreateUi();
        inst1.L_AbilityPanel.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.GridContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.VBoxContainer.Abilities
    /// </summary>
    public class Abilities : UiNode<SelectAbilityPanel, Godot.GridContainer, Abilities>
    {
        public Abilities(SelectAbilityPanel uiPanel, Godot.GridContainer node) : base(uiPanel, node) {  }
        public override Abilities Clone() => new (UiPanel, (Godot.GridContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.GridContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.VBoxContainer.Gears
    /// </summary>
    public class Gears : UiNode<SelectAbilityPanel, Godot.GridContainer, Gears>
    {
        public Gears(SelectAbilityPanel uiPanel, Godot.GridContainer node) : base(uiPanel, node) {  }
        public override Gears Clone() => new (UiPanel, (Godot.GridContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<SelectAbilityPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Abilities
        /// </summary>
        public Abilities L_Abilities
        {
            get
            {
                if (_L_Abilities == null) _L_Abilities = new Abilities(UiPanel, Instance.GetNode<Godot.GridContainer>("Abilities"));
                return _L_Abilities;
            }
        }
        private Abilities _L_Abilities;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Gears
        /// </summary>
        public Gears L_Gears
        {
            get
            {
                if (_L_Gears == null) _L_Gears = new Gears(UiPanel, Instance.GetNode<Godot.GridContainer>("Gears"));
                return _L_Gears;
            }
        }
        private Gears _L_Gears;

        public VBoxContainer_1(SelectAbilityPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 路径: SelectAbility.Content.VBoxContainer.Content.AbilityPanel
    /// </summary>
    public class AbilityPanel : UiNode<SelectAbilityPanel, NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel, AbilityPanel>
    {
        public AbilityPanel(SelectAbilityPanel uiPanel, NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel node) : base(uiPanel, node) {  }
        public override AbilityPanel Clone()
        {
            var uiNode = new AbilityPanel(UiPanel, (NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content
    /// </summary>
    public class Content_1 : UiNode<SelectAbilityPanel, Godot.HBoxContainer, Content_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.VBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: SelectAbility.Content.VBoxContainer.AbilityPanel
        /// </summary>
        public AbilityPanel L_AbilityPanel
        {
            get
            {
                if (_L_AbilityPanel == null) _L_AbilityPanel = new AbilityPanel(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel>("AbilityPanel"));
                return _L_AbilityPanel;
            }
        }
        private AbilityPanel _L_AbilityPanel;

        public Content_1(SelectAbilityPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Content_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: SelectAbility.Content.VBoxContainer.YesBtn
    /// </summary>
    public class YesBtn : UiNode<SelectAbilityPanel, Godot.Button, YesBtn>
    {
        public YesBtn(SelectAbilityPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override YesBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: SelectAbility.Content.VBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<SelectAbilityPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(SelectAbilityPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<SelectAbilityPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.Content
        /// </summary>
        public Content_1 L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Content"));
                return _L_Content;
            }
        }
        private Content_1 _L_Content;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: SelectAbility.Content.YesBtn
        /// </summary>
        public YesBtn L_YesBtn
        {
            get
            {
                if (_L_YesBtn == null) _L_YesBtn = new YesBtn(UiPanel, Instance.GetNode<Godot.Button>("YesBtn"));
                return _L_YesBtn;
            }
        }
        private YesBtn _L_YesBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: SelectAbility.Content.CloseBtn
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

        public VBoxContainer(SelectAbilityPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: SelectAbility.Content
    /// </summary>
    public class Content : UiNode<SelectAbilityPanel, Godot.PanelContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.VBoxContainer
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

        public Content(SelectAbilityPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.VBoxContainer.Abilities
    /// </summary>
    public Abilities S_Abilities => L_Content.L_VBoxContainer.L_Content.L_VBoxContainer.L_Abilities;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.VBoxContainer.Gears
    /// </summary>
    public Gears S_Gears => L_Content.L_VBoxContainer.L_Content.L_VBoxContainer.L_Gears;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.AbilityPanel
    /// </summary>
    public AbilityPanel S_AbilityPanel => L_Content.L_VBoxContainer.L_Content.L_AbilityPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: SelectAbility.Content.VBoxContainer.YesBtn
    /// </summary>
    public YesBtn S_YesBtn => L_Content.L_VBoxContainer.L_YesBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: SelectAbility.Content.VBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_Content.L_VBoxContainer.L_CloseBtn;

}
