namespace NovaDrift.Scripts.Ui.GalleryBtn;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GalleryBtn : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GalleryBtn.Background
    /// </summary>
    public Background L_Background
    {
        get
        {
            if (_L_Background == null) _L_Background = new Background((GalleryBtnPanel)this, GetNode<Godot.PanelContainer>("Background"));
            return _L_Background;
        }
    }
    private Background _L_Background;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GalleryBtn.Button
    /// </summary>
    public Button L_Button
    {
        get
        {
            if (_L_Button == null) _L_Button = new Button((GalleryBtnPanel)this, GetNode<Godot.Button>("Button"));
            return _L_Button;
        }
    }
    private Button _L_Button;


    public GalleryBtn() : base(nameof(GalleryBtn))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GalleryBtn.Background.MarginContainer.Image
    /// </summary>
    public class Image : UiNode<GalleryBtnPanel, Godot.TextureRect, Image>
    {
        public Image(GalleryBtnPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Image Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GalleryBtn.Background.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<GalleryBtnPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GalleryBtn.Background.Image
        /// </summary>
        public Image L_Image
        {
            get
            {
                if (_L_Image == null) _L_Image = new Image(UiPanel, Instance.GetNode<Godot.TextureRect>("Image"));
                return _L_Image;
            }
        }
        private Image _L_Image;

        public MarginContainer(GalleryBtnPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GalleryBtn.Background.Black.MarginContainer.Label
    /// </summary>
    public class Label : UiNode<GalleryBtnPanel, Godot.Label, Label>
    {
        public Label(GalleryBtnPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GalleryBtn.Background.Black.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<GalleryBtnPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GalleryBtn.Background.Black.Label
        /// </summary>
        public Label L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label _L_Label;

        public MarginContainer_1(GalleryBtnPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GalleryBtn.Background.Black
    /// </summary>
    public class Black : UiNode<GalleryBtnPanel, Godot.TextureRect, Black>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GalleryBtn.Background.MarginContainer
        /// </summary>
        public MarginContainer_1 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_1(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_1 _L_MarginContainer;

        public Black(GalleryBtnPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Black Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GalleryBtn.Background
    /// </summary>
    public class Background : UiNode<GalleryBtnPanel, Godot.PanelContainer, Background>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GalleryBtn.MarginContainer
        /// </summary>
        public MarginContainer L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer _L_MarginContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GalleryBtn.Black
        /// </summary>
        public Black L_Black
        {
            get
            {
                if (_L_Black == null) _L_Black = new Black(UiPanel, Instance.GetNode<Godot.TextureRect>("Black"));
                return _L_Black;
            }
        }
        private Black _L_Black;

        public Background(GalleryBtnPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override Background Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GalleryBtn.Button
    /// </summary>
    public class Button : UiNode<GalleryBtnPanel, Godot.Button, Button>
    {
        public Button(GalleryBtnPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GalleryBtn.Background.MarginContainer.Image
    /// </summary>
    public Image S_Image => L_Background.L_MarginContainer.L_Image;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GalleryBtn.Background.Black.MarginContainer.Label
    /// </summary>
    public Label S_Label => L_Background.L_Black.L_MarginContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GalleryBtn.Background.Black
    /// </summary>
    public Black S_Black => L_Background.L_Black;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GalleryBtn.Background
    /// </summary>
    public Background S_Background => L_Background;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GalleryBtn.Button
    /// </summary>
    public Button S_Button => L_Button;

}
