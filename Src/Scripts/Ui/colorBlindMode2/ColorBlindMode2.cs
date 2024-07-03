namespace NovaDrift.Scripts.Ui.ColorBlindMode2;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class ColorBlindMode2 : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: ColorBlindMode2.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((ColorBlindMode2Panel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;


    public ColorBlindMode2() : base(nameof(ColorBlindMode2))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: ColorBlindMode2.ColorRect
    /// </summary>
    public class ColorRect : UiNode<ColorBlindMode2Panel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(ColorBlindMode2Panel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: ColorBlindMode2.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

}
