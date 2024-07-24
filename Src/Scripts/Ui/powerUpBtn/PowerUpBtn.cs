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
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TouchScreenButton"/>, 节点路径: PowerUpBtn.TouchScreenButton
    /// </summary>
    public TouchScreenButton L_TouchScreenButton
    {
        get
        {
            if (_L_TouchScreenButton == null) _L_TouchScreenButton = new TouchScreenButton((PowerUpBtnPanel)this, GetNode<Godot.TouchScreenButton>("TouchScreenButton"));
            return _L_TouchScreenButton;
        }
    }
    private TouchScreenButton _L_TouchScreenButton;


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
    /// 类型: <see cref="Godot.TouchScreenButton"/>, 路径: PowerUpBtn.TouchScreenButton
    /// </summary>
    public class TouchScreenButton : UiNode<PowerUpBtnPanel, Godot.TouchScreenButton, TouchScreenButton>
    {
        public TouchScreenButton(PowerUpBtnPanel uiPanel, Godot.TouchScreenButton node) : base(uiPanel, node) {  }
        public override TouchScreenButton Clone() => new (UiPanel, (Godot.TouchScreenButton)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: PowerUpBtn.Icon
    /// </summary>
    public Icon S_Icon => L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TouchScreenButton"/>, 节点路径: PowerUpBtn.TouchScreenButton
    /// </summary>
    public TouchScreenButton S_TouchScreenButton => L_TouchScreenButton;

}
