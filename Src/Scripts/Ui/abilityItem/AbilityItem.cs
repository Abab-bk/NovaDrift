namespace NovaDrift.Scripts.Ui.AbilityItem;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class AbilityItem : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: AbilityItem.IconTexture
    /// </summary>
    public IconTexture L_IconTexture
    {
        get
        {
            if (_L_IconTexture == null) _L_IconTexture = new IconTexture((AbilityItemPanel)this, GetNode<Godot.TextureRect>("IconTexture"));
            return _L_IconTexture;
        }
    }
    private IconTexture _L_IconTexture;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: AbilityItem.Button
    /// </summary>
    public Button L_Button
    {
        get
        {
            if (_L_Button == null) _L_Button = new Button((AbilityItemPanel)this, GetNode<Godot.Button>("Button"));
            return _L_Button;
        }
    }
    private Button _L_Button;


    public AbilityItem() : base(nameof(AbilityItem))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: AbilityItem.IconTexture
    /// </summary>
    public class IconTexture : UiNode<AbilityItemPanel, Godot.TextureRect, IconTexture>
    {
        public IconTexture(AbilityItemPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override IconTexture Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: AbilityItem.Button
    /// </summary>
    public class Button : UiNode<AbilityItemPanel, Godot.Button, Button>
    {
        public Button(AbilityItemPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: AbilityItem.IconTexture
    /// </summary>
    public IconTexture S_IconTexture => L_IconTexture;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: AbilityItem.Button
    /// </summary>
    public Button S_Button => L_Button;

}
