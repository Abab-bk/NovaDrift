namespace NovaDrift.Scripts.Ui.PowerUpBtn;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class PowerUpBtn : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: PowerUpBtn.Icon
    /// </summary>
    public Icon L_Icon
    {
        get
        {
            if (_L_Icon == null) _L_Icon = new Icon((PowerUpBtnPanel)this, GetNode<Godot.TextureRect>("Icon"));
            return _L_Icon;
        }
    }
    private Icon _L_Icon;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PowerUpBtn.Button
    /// </summary>
    public Button L_Button
    {
        get
        {
            if (_L_Button == null) _L_Button = new Button((PowerUpBtnPanel)this, GetNode<Godot.Button>("Button"));
            return _L_Button;
        }
    }
    private Button _L_Button;


    public PowerUpBtn() : base(nameof(PowerUpBtn))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: PowerUpBtn.Icon
    /// </summary>
    public class Icon : UiNode<PowerUpBtnPanel, Godot.TextureRect, Icon>
    {
        public Icon(PowerUpBtnPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PowerUpBtn.Button
    /// </summary>
    public class Button : UiNode<PowerUpBtnPanel, Godot.Button, Button>
    {
        public Button(PowerUpBtnPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: PowerUpBtn.Icon
    /// </summary>
    public Icon S_Icon => L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PowerUpBtn.Button
    /// </summary>
    public Button S_Button => L_Button;

}
