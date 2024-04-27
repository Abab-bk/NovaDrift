namespace NovaDrift.Scripts.Ui.SalvoBulletCount;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class SalvoBulletCount : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: SalvoBulletCount.Label
    /// </summary>
    public Label L_Label
    {
        get
        {
            if (_L_Label == null) _L_Label = new Label((SalvoBulletCountPanel)this, GetNode<Godot.Label>("Label"));
            return _L_Label;
        }
    }
    private Label _L_Label;


    public SalvoBulletCount() : base(nameof(SalvoBulletCount))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: SalvoBulletCount.Label
    /// </summary>
    public class Label : UiNode<SalvoBulletCountPanel, Godot.Label, Label>
    {
        public Label(SalvoBulletCountPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: SalvoBulletCount.Label
    /// </summary>
    public Label S_Label => L_Label;

}
