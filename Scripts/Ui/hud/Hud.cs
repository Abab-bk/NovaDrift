namespace NovaDrift.Scripts.Ui.Hud;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Hud : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: Hud.ExpProgressBar
    /// </summary>
    public ExpProgressBar L_ExpProgressBar
    {
        get
        {
            if (_L_ExpProgressBar == null) _L_ExpProgressBar = new ExpProgressBar((HudPanel)this, GetNode<Godot.ProgressBar>("ExpProgressBar"));
            return _L_ExpProgressBar;
        }
    }
    private ExpProgressBar _L_ExpProgressBar;


    public Hud() : base(nameof(Hud))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ProgressBar"/>, 路径: Hud.ExpProgressBar
    /// </summary>
    public class ExpProgressBar : UiNode<HudPanel, Godot.ProgressBar, ExpProgressBar>
    {
        public ExpProgressBar(HudPanel uiPanel, Godot.ProgressBar node) : base(uiPanel, node) {  }
        public override ExpProgressBar Clone() => new (UiPanel, (Godot.ProgressBar)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: Hud.ExpProgressBar
    /// </summary>
    public ExpProgressBar S_ExpProgressBar => L_ExpProgressBar;

}
