namespace NovaDrift.Scripts.Ui.BuffIcon;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class BuffIcon : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: BuffIcon.ProgressBar
    /// </summary>
    public ProgressBar L_ProgressBar
    {
        get
        {
            if (_L_ProgressBar == null) _L_ProgressBar = new ProgressBar((BuffIconPanel)this, GetNode<Godot.TextureProgressBar>("ProgressBar"));
            return _L_ProgressBar;
        }
    }
    private ProgressBar _L_ProgressBar;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: BuffIcon.Icon
    /// </summary>
    public Icon L_Icon
    {
        get
        {
            if (_L_Icon == null) _L_Icon = new Icon((BuffIconPanel)this, GetNode<Godot.TextureRect>("Icon"));
            return _L_Icon;
        }
    }
    private Icon _L_Icon;


    public BuffIcon() : base(nameof(BuffIcon))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureProgressBar"/>, 路径: BuffIcon.ProgressBar
    /// </summary>
    public class ProgressBar : UiNode<BuffIconPanel, Godot.TextureProgressBar, ProgressBar>
    {
        public ProgressBar(BuffIconPanel uiPanel, Godot.TextureProgressBar node) : base(uiPanel, node) {  }
        public override ProgressBar Clone() => new (UiPanel, (Godot.TextureProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: BuffIcon.Icon
    /// </summary>
    public class Icon : UiNode<BuffIconPanel, Godot.TextureRect, Icon>
    {
        public Icon(BuffIconPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureProgressBar"/>, 节点路径: BuffIcon.ProgressBar
    /// </summary>
    public ProgressBar S_ProgressBar => L_ProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: BuffIcon.Icon
    /// </summary>
    public Icon S_Icon => L_Icon;

}
