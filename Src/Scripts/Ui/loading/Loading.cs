namespace NovaDrift.Scripts.Ui.Loading;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Loading : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: Loading.ProgressBar
    /// </summary>
    public ProgressBar L_ProgressBar
    {
        get
        {
            if (_L_ProgressBar == null) _L_ProgressBar = new ProgressBar((LoadingPanel)this, GetNode<Godot.ProgressBar>("ProgressBar"));
            return _L_ProgressBar;
        }
    }
    private ProgressBar _L_ProgressBar;


    public Loading() : base(nameof(Loading))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ProgressBar"/>, 路径: Loading.ProgressBar
    /// </summary>
    public class ProgressBar : UiNode<LoadingPanel, Godot.ProgressBar, ProgressBar>
    {
        public ProgressBar(LoadingPanel uiPanel, Godot.ProgressBar node) : base(uiPanel, node) {  }
        public override ProgressBar Clone() => new (UiPanel, (Godot.ProgressBar)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: Loading.ProgressBar
    /// </summary>
    public ProgressBar S_ProgressBar => L_ProgressBar;

}
