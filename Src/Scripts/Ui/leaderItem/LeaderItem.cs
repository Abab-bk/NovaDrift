namespace NovaDrift.Scripts.Ui.LeaderItem;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class LeaderItem : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: LeaderItem.Button
    /// </summary>
    public Button L_Button
    {
        get
        {
            if (_L_Button == null) _L_Button = new Button((LeaderItemPanel)this, GetNode<Godot.Button>("Button"));
            return _L_Button;
        }
    }
    private Button _L_Button;


    public LeaderItem() : base(nameof(LeaderItem))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: LeaderItem.Button
    /// </summary>
    public class Button : UiNode<LeaderItemPanel, Godot.Button, Button>
    {
        public Button(LeaderItemPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: LeaderItem.Button
    /// </summary>
    public Button S_Button => L_Button;

}
