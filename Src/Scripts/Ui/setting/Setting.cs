namespace NovaDrift.Scripts.Ui.Setting;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Setting : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Setting.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((SettingPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public Setting() : base(nameof(Setting))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.MarginContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<SettingPanel, Godot.Label, Label>
    {
        public Label(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.UiVolum.Label
    /// </summary>
    public class Label_1 : UiNode<SettingPanel, Godot.Label, Label_1>
    {
        public Label_1(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.UiVolum.UiVolumeSlider
    /// </summary>
    public class UiVolumeSlider : UiNode<SettingPanel, Godot.HSlider, UiVolumeSlider>
    {
        public UiVolumeSlider(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override UiVolumeSlider Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.UiVolum
    /// </summary>
    public class UiVolum : UiNode<SettingPanel, Godot.HBoxContainer, UiVolum>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.Label
        /// </summary>
        public Label_1 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_1(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_1 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.UiVolumeSlider
        /// </summary>
        public UiVolumeSlider L_UiVolumeSlider
        {
            get
            {
                if (_L_UiVolumeSlider == null) _L_UiVolumeSlider = new UiVolumeSlider(UiPanel, Instance.GetNode<Godot.HSlider>("UiVolumeSlider"));
                return _L_UiVolumeSlider;
            }
        }
        private UiVolumeSlider _L_UiVolumeSlider;

        public UiVolum(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override UiVolum Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.MusicVolum.Label
    /// </summary>
    public class Label_2 : UiNode<SettingPanel, Godot.Label, Label_2>
    {
        public Label_2(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.MusicVolum.MusicVolumeSlider
    /// </summary>
    public class MusicVolumeSlider : UiNode<SettingPanel, Godot.HSlider, MusicVolumeSlider>
    {
        public MusicVolumeSlider(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override MusicVolumeSlider Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.MusicVolum
    /// </summary>
    public class MusicVolum : UiNode<SettingPanel, Godot.HBoxContainer, MusicVolum>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.Label
        /// </summary>
        public Label_2 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_2(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_2 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.MusicVolumeSlider
        /// </summary>
        public MusicVolumeSlider L_MusicVolumeSlider
        {
            get
            {
                if (_L_MusicVolumeSlider == null) _L_MusicVolumeSlider = new MusicVolumeSlider(UiPanel, Instance.GetNode<Godot.HSlider>("MusicVolumeSlider"));
                return _L_MusicVolumeSlider;
            }
        }
        private MusicVolumeSlider _L_MusicVolumeSlider;

        public MusicVolum(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override MusicVolum Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.SoundVolum.Label
    /// </summary>
    public class Label_3 : UiNode<SettingPanel, Godot.Label, Label_3>
    {
        public Label_3(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_3 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.SoundVolum.SoundVolumeSlider
    /// </summary>
    public class SoundVolumeSlider : UiNode<SettingPanel, Godot.HSlider, SoundVolumeSlider>
    {
        public SoundVolumeSlider(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override SoundVolumeSlider Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.SoundVolum
    /// </summary>
    public class SoundVolum : UiNode<SettingPanel, Godot.HBoxContainer, SoundVolum>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.Label
        /// </summary>
        public Label_3 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_3(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_3 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.SoundVolumeSlider
        /// </summary>
        public SoundVolumeSlider L_SoundVolumeSlider
        {
            get
            {
                if (_L_SoundVolumeSlider == null) _L_SoundVolumeSlider = new SoundVolumeSlider(UiPanel, Instance.GetNode<Godot.HSlider>("SoundVolumeSlider"));
                return _L_SoundVolumeSlider;
            }
        }
        private SoundVolumeSlider _L_SoundVolumeSlider;

        public SoundVolum(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override SoundVolum Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_2 : UiNode<SettingPanel, Godot.VBoxContainer, VBoxContainer_2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.UiVolum
        /// </summary>
        public UiVolum L_UiVolum
        {
            get
            {
                if (_L_UiVolum == null) _L_UiVolum = new UiVolum(UiPanel, Instance.GetNode<Godot.HBoxContainer>("UiVolum"));
                return _L_UiVolum;
            }
        }
        private UiVolum _L_UiVolum;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.MusicVolum
        /// </summary>
        public MusicVolum L_MusicVolum
        {
            get
            {
                if (_L_MusicVolum == null) _L_MusicVolum = new MusicVolum(UiPanel, Instance.GetNode<Godot.HBoxContainer>("MusicVolum"));
                return _L_MusicVolum;
            }
        }
        private MusicVolum _L_MusicVolum;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.SoundVolum
        /// </summary>
        public SoundVolum L_SoundVolum
        {
            get
            {
                if (_L_SoundVolum == null) _L_SoundVolum = new SoundVolum(UiPanel, Instance.GetNode<Godot.HBoxContainer>("SoundVolum"));
                return _L_SoundVolum;
            }
        }
        private SoundVolum _L_SoundVolum;

        public VBoxContainer_2(SettingPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<SettingPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_2 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_2 _L_VBoxContainer;

        public MarginContainer_1(SettingPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<SettingPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(SettingPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Setting.MarginContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<SettingPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.MarginContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Setting.MarginContainer.VBoxContainer.CloseBtn
        /// </summary>
        public CloseBtn L_CloseBtn
        {
            get
            {
                if (_L_CloseBtn == null) _L_CloseBtn = new CloseBtn(UiPanel, Instance.GetNode<Godot.Button>("CloseBtn"));
                return _L_CloseBtn;
            }
        }
        private CloseBtn _L_CloseBtn;

        public VBoxContainer_1(SettingPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Setting.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<SettingPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.MarginContainer.Label
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_1 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_1(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_1 _L_VBoxContainer;

        public VBoxContainer(SettingPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Setting.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<SettingPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Setting.VBoxContainer
        /// </summary>
        public VBoxContainer L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer _L_VBoxContainer;

        public MarginContainer(SettingPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.UiVolum.UiVolumeSlider
    /// </summary>
    public UiVolumeSlider S_UiVolumeSlider => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_VBoxContainer.L_UiVolum.L_UiVolumeSlider;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.UiVolum
    /// </summary>
    public UiVolum S_UiVolum => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_VBoxContainer.L_UiVolum;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.MusicVolum.MusicVolumeSlider
    /// </summary>
    public MusicVolumeSlider S_MusicVolumeSlider => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_VBoxContainer.L_MusicVolum.L_MusicVolumeSlider;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.MusicVolum
    /// </summary>
    public MusicVolum S_MusicVolum => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_VBoxContainer.L_MusicVolum;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.SoundVolum.SoundVolumeSlider
    /// </summary>
    public SoundVolumeSlider S_SoundVolumeSlider => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_VBoxContainer.L_SoundVolum.L_SoundVolumeSlider;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.MarginContainer.VBoxContainer.SoundVolum
    /// </summary>
    public SoundVolum S_SoundVolum => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_MarginContainer.L_VBoxContainer.L_SoundVolum;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Setting.MarginContainer.VBoxContainer.VBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_CloseBtn;

}
