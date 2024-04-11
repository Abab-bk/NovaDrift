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

        var inst1 = L_Content.L_Content;
        RecordNestedUi(inst1.L_AbilityPanel.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_AbilityPanel.Instance.OnCreateUi();
        inst1.L_AbilityPanel.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.GridContainer"/>, 路径: SelectAbility.Content.Content.Abilities
    /// </summary>
    public class Abilities : UiNode<SelectAbilityPanel, Godot.GridContainer, Abilities>
    {
        public Abilities(SelectAbilityPanel uiPanel, Godot.GridContainer node) : base(uiPanel, node) {  }
        public override Abilities Clone() => new (UiPanel, (Godot.GridContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 路径: SelectAbility.Content.Content.AbilityPanel
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
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.Content.Content
    /// </summary>
    public class Content_1 : UiNode<SelectAbilityPanel, Godot.HBoxContainer, Content_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.Content.Abilities
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: SelectAbility.Content.AbilityPanel
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
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: SelectAbility.Content
    /// </summary>
    public class Content : UiNode<SelectAbilityPanel, Godot.PanelContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content
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

        public Content(SelectAbilityPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.GridContainer"/>, 节点路径: SelectAbility.Content.Content.Abilities
    /// </summary>
    public Abilities S_Abilities => L_Content.L_Content.L_Abilities;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: SelectAbility.Content.Content.AbilityPanel
    /// </summary>
    public AbilityPanel S_AbilityPanel => L_Content.L_Content.L_AbilityPanel;

}
