namespace NovaDrift.Scripts.Ui.Tip;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Tip : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Tip.Label
    /// </summary>
    public Label L_Label
    {
        get
        {
            if (_L_Label == null) _L_Label = new Label((TipPanel)this, GetNode<Godot.Label>("Label"));
            return _L_Label;
        }
    }
    private Label _L_Label;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Timer"/>, 节点路径: Tip.Timer
    /// </summary>
    public Timer L_Timer
    {
        get
        {
            if (_L_Timer == null) _L_Timer = new Timer((TipPanel)this, GetNode<Godot.Timer>("Timer"));
            return _L_Timer;
        }
    }
    private Timer _L_Timer;


    public Tip() : base(nameof(Tip))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Tip.Label
    /// </summary>
    public class Label : UiNode<TipPanel, Godot.Label, Label>
    {
        public Label(TipPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Timer"/>, 路径: Tip.Timer
    /// </summary>
    public class Timer : UiNode<TipPanel, Godot.Timer, Timer>
    {
        public Timer(TipPanel uiPanel, Godot.Timer node) : base(uiPanel, node) {  }
        public override Timer Clone() => new (UiPanel, (Godot.Timer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Tip.Label
    /// </summary>
    public Label S_Label => L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Timer"/>, 节点路径: Tip.Timer
    /// </summary>
    public Timer S_Timer => L_Timer;

}
