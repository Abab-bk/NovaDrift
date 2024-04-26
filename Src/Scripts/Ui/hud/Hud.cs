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


    public Hud() : base(nameof(Hud))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureProgressBar"/>, 路径: Hud.MarginContainer.VBoxContainer.ExpProgressBar
    /// </summary>
    public class ExpProgressBar : UiNode<HudPanel, Godot.TextureProgressBar, ExpProgressBar>
    {
        public ExpProgressBar(HudPanel uiPanel, Godot.TextureProgressBar node) : base(uiPanel, node) {  }
        public override ExpProgressBar Clone() => new (UiPanel, (Godot.TextureProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureProgressBar"/>, 路径: Hud.MarginContainer.VBoxContainer.HpProgressBar
    /// </summary>
    public class HpProgressBar : UiNode<HudPanel, Godot.TextureProgressBar, HpProgressBar>
    {
        public HpProgressBar(HudPanel uiPanel, Godot.TextureProgressBar node) : base(uiPanel, node) {  }
        public override HpProgressBar Clone() => new (UiPanel, (Godot.TextureProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ProgressBar"/>, 路径: Hud.MarginContainer.VBoxContainer.ShieldBar
    /// </summary>
    public class ShieldBar : UiNode<HudPanel, Godot.ProgressBar, ShieldBar>
    {
        public ShieldBar(HudPanel uiPanel, Godot.ProgressBar node) : base(uiPanel, node) {  }
        public override ShieldBar Clone() => new (UiPanel, (Godot.ProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Hud.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<HudPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: Hud.MarginContainer.ExpProgressBar
        /// </summary>
        public ExpProgressBar L_ExpProgressBar
        {
            get
            {
                if (_L_ExpProgressBar == null) _L_ExpProgressBar = new ExpProgressBar(UiPanel, Instance.GetNode<Godot.TextureProgressBar>("ExpProgressBar"));
                return _L_ExpProgressBar;
            }
        }
        private ExpProgressBar _L_ExpProgressBar;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: Hud.MarginContainer.HpProgressBar
        /// </summary>
        public HpProgressBar L_HpProgressBar
        {
            get
            {
                if (_L_HpProgressBar == null) _L_HpProgressBar = new HpProgressBar(UiPanel, Instance.GetNode<Godot.TextureProgressBar>("HpProgressBar"));
                return _L_HpProgressBar;
            }
        }
        private HpProgressBar _L_HpProgressBar;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: Hud.MarginContainer.ShieldBar
        /// </summary>
        public ShieldBar L_ShieldBar
        {
            get
            {
                if (_L_ShieldBar == null) _L_ShieldBar = new ShieldBar(UiPanel, Instance.GetNode<Godot.ProgressBar>("ShieldBar"));
                return _L_ShieldBar;
            }
        }
        private ShieldBar _L_ShieldBar;

        public VBoxContainer(HudPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Hud.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<HudPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Hud.VBoxContainer
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

        public MarginContainer(HudPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: Hud.MarginContainer.VBoxContainer.ExpProgressBar
    /// </summary>
    public ExpProgressBar S_ExpProgressBar => L_MarginContainer.L_VBoxContainer.L_ExpProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: Hud.MarginContainer.VBoxContainer.HpProgressBar
    /// </summary>
    public HpProgressBar S_HpProgressBar => L_MarginContainer.L_VBoxContainer.L_HpProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: Hud.MarginContainer.VBoxContainer.ShieldBar
    /// </summary>
    public ShieldBar S_ShieldBar => L_MarginContainer.L_VBoxContainer.L_ShieldBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Hud.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Hud.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
