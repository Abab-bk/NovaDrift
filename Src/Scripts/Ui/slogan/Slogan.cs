namespace NovaDrift.Scripts.Ui.Slogan;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Slogan : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Slogan.Slogan
    /// </summary>
    public Slogan_1 L_Slogan
    {
        get
        {
            if (_L_Slogan == null) _L_Slogan = new Slogan_1((SloganPanel)this, GetNode<Godot.Label>("Slogan"));
            return _L_Slogan;
        }
    }
    private Slogan_1 _L_Slogan;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.AnimationPlayer"/>, 节点路径: Slogan.AnimationPlayer
    /// </summary>
    public AnimationPlayer L_AnimationPlayer
    {
        get
        {
            if (_L_AnimationPlayer == null) _L_AnimationPlayer = new AnimationPlayer((SloganPanel)this, GetNode<Godot.AnimationPlayer>("AnimationPlayer"));
            return _L_AnimationPlayer;
        }
    }
    private AnimationPlayer _L_AnimationPlayer;


    public Slogan() : base(nameof(Slogan))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Slogan.Slogan
    /// </summary>
    public class Slogan_1 : UiNode<SloganPanel, Godot.Label, Slogan_1>
    {
        public Slogan_1(SloganPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Slogan_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.AnimationPlayer"/>, 路径: Slogan.AnimationPlayer
    /// </summary>
    public class AnimationPlayer : UiNode<SloganPanel, Godot.AnimationPlayer, AnimationPlayer>
    {
        public AnimationPlayer(SloganPanel uiPanel, Godot.AnimationPlayer node) : base(uiPanel, node) {  }
        public override AnimationPlayer Clone() => new (UiPanel, (Godot.AnimationPlayer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.AnimationPlayer"/>, 节点路径: Slogan.AnimationPlayer
    /// </summary>
    public AnimationPlayer S_AnimationPlayer => L_AnimationPlayer;

}
