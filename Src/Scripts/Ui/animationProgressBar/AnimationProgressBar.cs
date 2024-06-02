namespace NovaDrift.Scripts.Ui.AnimationProgressBar;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class AnimationProgressBar : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: AnimationProgressBar.Bar
    /// </summary>
    public Bar L_Bar
    {
        get
        {
            if (_L_Bar == null) _L_Bar = new Bar((AnimationProgressBarPanel)this, GetNode<Godot.TextureProgressBar>("Bar"));
            return _L_Bar;
        }
    }
    private Bar _L_Bar;


    public AnimationProgressBar() : base(nameof(AnimationProgressBar))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureProgressBar"/>, 路径: AnimationProgressBar.Bar.EasedBar
    /// </summary>
    public class EasedBar : UiNode<AnimationProgressBarPanel, Godot.TextureProgressBar, EasedBar>
    {
        public EasedBar(AnimationProgressBarPanel uiPanel, Godot.TextureProgressBar node) : base(uiPanel, node) {  }
        public override EasedBar Clone() => new (UiPanel, (Godot.TextureProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureProgressBar"/>, 路径: AnimationProgressBar.Bar
    /// </summary>
    public class Bar : UiNode<AnimationProgressBarPanel, Godot.TextureProgressBar, Bar>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: AnimationProgressBar.EasedBar
        /// </summary>
        public EasedBar L_EasedBar
        {
            get
            {
                if (_L_EasedBar == null) _L_EasedBar = new EasedBar(UiPanel, Instance.GetNode<Godot.TextureProgressBar>("EasedBar"));
                return _L_EasedBar;
            }
        }
        private EasedBar _L_EasedBar;

        public Bar(AnimationProgressBarPanel uiPanel, Godot.TextureProgressBar node) : base(uiPanel, node) {  }
        public override Bar Clone() => new (UiPanel, (Godot.TextureProgressBar)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: AnimationProgressBar.Bar.EasedBar
    /// </summary>
    public EasedBar S_EasedBar => L_Bar.L_EasedBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: AnimationProgressBar.Bar
    /// </summary>
    public Bar S_Bar => L_Bar;

}
