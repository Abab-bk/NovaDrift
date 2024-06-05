namespace NovaDrift.Scripts.Ui.Hud;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Hud : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Hud.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((HudPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Hud.MarginContainer2
    /// </summary>
    public MarginContainer2 L_MarginContainer2
    {
        get
        {
            if (_L_MarginContainer2 == null) _L_MarginContainer2 = new MarginContainer2((HudPanel)this, GetNode<Godot.MarginContainer>("MarginContainer2"));
            return _L_MarginContainer2;
        }
    }
    private MarginContainer2 _L_MarginContainer2;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: Hud.DebugPanel
    /// </summary>
    public DebugPanel L_DebugPanel
    {
        get
        {
            if (_L_DebugPanel == null) _L_DebugPanel = new DebugPanel((HudPanel)this, GetNode<Godot.Control>("DebugPanel"));
            return _L_DebugPanel;
        }
    }
    private DebugPanel _L_DebugPanel;


    public Hud() : base(nameof(Hud))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_MarginContainer.L_VBoxContainer2.L_ProgressBars;
        RecordNestedUi(inst1.L_ExpProgressBar.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_ExpProgressBar.Instance.OnCreateUi();
        inst1.L_ExpProgressBar.Instance.OnInitNestedUi();

        var inst2 = L_MarginContainer.L_VBoxContainer2.L_ProgressBars;
        RecordNestedUi(inst2.L_HpProgressBar.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_HpProgressBar.Instance.OnCreateUi();
        inst2.L_HpProgressBar.Instance.OnInitNestedUi();

        var inst3 = L_MarginContainer.L_VBoxContainer2.L_ProgressBars;
        RecordNestedUi(inst3.L_ShieldProgressBar.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_ShieldProgressBar.Instance.OnCreateUi();
        inst3.L_ShieldProgressBar.Instance.OnInitNestedUi();

        var inst4 = L_MarginContainer.L_VBoxContainer2;
        RecordNestedUi(inst4.L_ShieldCooldownProgressBar.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_ShieldCooldownProgressBar.Instance.OnCreateUi();
        inst4.L_ShieldCooldownProgressBar.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Hud.MarginContainer.VBoxContainer2.ActionButtons
    /// </summary>
    public class ActionButtons : UiNode<HudPanel, Godot.HBoxContainer, ActionButtons>
    {
        public ActionButtons(HudPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override ActionButtons Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 路径: Hud.MarginContainer.VBoxContainer2.ProgressBars.ExpProgressBar
    /// </summary>
    public class ExpProgressBar : UiNode<HudPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel, ExpProgressBar>
    {
        public ExpProgressBar(HudPanel uiPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel node) : base(uiPanel, node) {  }
        public override ExpProgressBar Clone()
        {
            var uiNode = new ExpProgressBar(UiPanel, (NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 路径: Hud.MarginContainer.VBoxContainer2.ProgressBars.HpProgressBar
    /// </summary>
    public class HpProgressBar : UiNode<HudPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel, HpProgressBar>
    {
        public HpProgressBar(HudPanel uiPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel node) : base(uiPanel, node) {  }
        public override HpProgressBar Clone()
        {
            var uiNode = new HpProgressBar(UiPanel, (NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 路径: Hud.MarginContainer.VBoxContainer2.ProgressBars.ShieldProgressBar
    /// </summary>
    public class ShieldProgressBar : UiNode<HudPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel, ShieldProgressBar>
    {
        public ShieldProgressBar(HudPanel uiPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel node) : base(uiPanel, node) {  }
        public override ShieldProgressBar Clone()
        {
            var uiNode = new ShieldProgressBar(UiPanel, (NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Hud.MarginContainer.VBoxContainer2.ProgressBars
    /// </summary>
    public class ProgressBars : UiNode<HudPanel, Godot.VBoxContainer, ProgressBars>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ExpProgressBar
        /// </summary>
        public ExpProgressBar L_ExpProgressBar
        {
            get
            {
                if (_L_ExpProgressBar == null) _L_ExpProgressBar = new ExpProgressBar(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>("ExpProgressBar"));
                return _L_ExpProgressBar;
            }
        }
        private ExpProgressBar _L_ExpProgressBar;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.HpProgressBar
        /// </summary>
        public HpProgressBar L_HpProgressBar
        {
            get
            {
                if (_L_HpProgressBar == null) _L_HpProgressBar = new HpProgressBar(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>("HpProgressBar"));
                return _L_HpProgressBar;
            }
        }
        private HpProgressBar _L_HpProgressBar;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ShieldProgressBar
        /// </summary>
        public ShieldProgressBar L_ShieldProgressBar
        {
            get
            {
                if (_L_ShieldProgressBar == null) _L_ShieldProgressBar = new ShieldProgressBar(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>("ShieldProgressBar"));
                return _L_ShieldProgressBar;
            }
        }
        private ShieldProgressBar _L_ShieldProgressBar;

        public ProgressBars(HudPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override ProgressBars Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 路径: Hud.MarginContainer.VBoxContainer2.ShieldCooldownProgressBar
    /// </summary>
    public class ShieldCooldownProgressBar : UiNode<HudPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel, ShieldCooldownProgressBar>
    {
        public ShieldCooldownProgressBar(HudPanel uiPanel, NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel node) : base(uiPanel, node) {  }
        public override ShieldCooldownProgressBar Clone()
        {
            var uiNode = new ShieldCooldownProgressBar(UiPanel, (NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Hud.MarginContainer.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<HudPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Hud.MarginContainer.ActionButtons
        /// </summary>
        public ActionButtons L_ActionButtons
        {
            get
            {
                if (_L_ActionButtons == null) _L_ActionButtons = new ActionButtons(UiPanel, Instance.GetNode<Godot.HBoxContainer>("ActionButtons"));
                return _L_ActionButtons;
            }
        }
        private ActionButtons _L_ActionButtons;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Hud.MarginContainer.ProgressBars
        /// </summary>
        public ProgressBars L_ProgressBars
        {
            get
            {
                if (_L_ProgressBars == null) _L_ProgressBars = new ProgressBars(UiPanel, Instance.GetNode<Godot.VBoxContainer>("ProgressBars"));
                return _L_ProgressBars;
            }
        }
        private ProgressBars _L_ProgressBars;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.ShieldCooldownProgressBar
        /// </summary>
        public ShieldCooldownProgressBar L_ShieldCooldownProgressBar
        {
            get
            {
                if (_L_ShieldCooldownProgressBar == null) _L_ShieldCooldownProgressBar = new ShieldCooldownProgressBar(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel>("ShieldCooldownProgressBar"));
                return _L_ShieldCooldownProgressBar;
            }
        }
        private ShieldCooldownProgressBar _L_ShieldCooldownProgressBar;

        public VBoxContainer2(HudPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Hud.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<HudPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Hud.VBoxContainer2
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

        public MarginContainer(HudPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Hud.MarginContainer2.BuffIcons
    /// </summary>
    public class BuffIcons : UiNode<HudPanel, Godot.HBoxContainer, BuffIcons>
    {
        public BuffIcons(HudPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BuffIcons Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Hud.MarginContainer2
    /// </summary>
    public class MarginContainer2 : UiNode<HudPanel, Godot.MarginContainer, MarginContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Hud.BuffIcons
        /// </summary>
        public BuffIcons L_BuffIcons
        {
            get
            {
                if (_L_BuffIcons == null) _L_BuffIcons = new BuffIcons(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BuffIcons"));
                return _L_BuffIcons;
            }
        }
        private BuffIcons _L_BuffIcons;

        public MarginContainer2(HudPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer2 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: Hud.DebugPanel
    /// </summary>
    public class DebugPanel : UiNode<HudPanel, Godot.Control, DebugPanel>
    {
        public DebugPanel(HudPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override DebugPanel Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ActionButtons
    /// </summary>
    public ActionButtons S_ActionButtons => L_MarginContainer.L_VBoxContainer2.L_ActionButtons;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ProgressBars.ExpProgressBar
    /// </summary>
    public ExpProgressBar S_ExpProgressBar => L_MarginContainer.L_VBoxContainer2.L_ProgressBars.L_ExpProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ProgressBars.HpProgressBar
    /// </summary>
    public HpProgressBar S_HpProgressBar => L_MarginContainer.L_VBoxContainer2.L_ProgressBars.L_HpProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ProgressBars.ShieldProgressBar
    /// </summary>
    public ShieldProgressBar S_ShieldProgressBar => L_MarginContainer.L_VBoxContainer2.L_ProgressBars.L_ShieldProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ProgressBars
    /// </summary>
    public ProgressBars S_ProgressBars => L_MarginContainer.L_VBoxContainer2.L_ProgressBars;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AnimationProgressBar.AnimationProgressBarPanel"/>, 节点路径: Hud.MarginContainer.VBoxContainer2.ShieldCooldownProgressBar
    /// </summary>
    public ShieldCooldownProgressBar S_ShieldCooldownProgressBar => L_MarginContainer.L_VBoxContainer2.L_ShieldCooldownProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Hud.MarginContainer.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_MarginContainer.L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Hud.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Hud.MarginContainer2.BuffIcons
    /// </summary>
    public BuffIcons S_BuffIcons => L_MarginContainer2.L_BuffIcons;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Hud.MarginContainer2
    /// </summary>
    public MarginContainer2 S_MarginContainer2 => L_MarginContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: Hud.DebugPanel
    /// </summary>
    public DebugPanel S_DebugPanel => L_DebugPanel;

}
