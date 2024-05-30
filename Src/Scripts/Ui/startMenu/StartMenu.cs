namespace NovaDrift.Scripts.Ui.StartMenu;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class StartMenu : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StartMenu.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((StartMenuPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.Setting.SettingPanel"/>, 节点路径: StartMenu.Setting
    /// </summary>
    public Setting L_Setting
    {
        get
        {
            if (_L_Setting == null) _L_Setting = new Setting((StartMenuPanel)this, GetNode<NovaDrift.Scripts.Ui.Setting.SettingPanel>("Setting"));
            return _L_Setting;
        }
    }
    private Setting _L_Setting;


    public StartMenu() : base(nameof(StartMenu))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_MarginContainer.L_VBoxContainer.L_HBoxContainer;
        RecordNestedUi(inst1.L_StartGameBtn.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_StartGameBtn.Instance.OnCreateUi();
        inst1.L_StartGameBtn.Instance.OnInitNestedUi();

        var inst2 = L_MarginContainer.L_VBoxContainer.L_HBoxContainer;
        RecordNestedUi(inst2.L_GearBtn.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_GearBtn.Instance.OnCreateUi();
        inst2.L_GearBtn.Instance.OnInitNestedUi();

        var inst3 = L_MarginContainer.L_VBoxContainer.L_HBoxContainer;
        RecordNestedUi(inst3.L_SettingBtn.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_SettingBtn.Instance.OnCreateUi();
        inst3.L_SettingBtn.Instance.OnInitNestedUi();

        var inst4 = L_MarginContainer.L_VBoxContainer.L_HBoxContainer;
        RecordNestedUi(inst4.L_ExitBtn.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_ExitBtn.Instance.OnCreateUi();
        inst4.L_ExitBtn.Instance.OnInitNestedUi();

        var inst5 = this;
        RecordNestedUi(inst5.L_Setting.Instance, null, UiManager.RecordType.Open);
        inst5.L_Setting.Instance.OnCreateUi();
        inst5.L_Setting.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: StartMenu.MarginContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<StartMenuPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(StartMenuPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: StartMenu.MarginContainer.VBoxContainer.Control
    /// </summary>
    public class Control : UiNode<StartMenuPanel, Godot.Control, Control>
    {
        public Control(StartMenuPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.StartGameBtn
    /// </summary>
    public class StartGameBtn : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, StartGameBtn>
    {
        public StartGameBtn(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override StartGameBtn Clone()
        {
            var uiNode = new StartGameBtn(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.GearBtn
    /// </summary>
    public class GearBtn : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, GearBtn>
    {
        public GearBtn(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override GearBtn Clone()
        {
            var uiNode = new GearBtn(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.SettingBtn
    /// </summary>
    public class SettingBtn : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, SettingBtn>
    {
        public SettingBtn(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override SettingBtn Clone()
        {
            var uiNode = new SettingBtn(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.ExitBtn
    /// </summary>
    public class ExitBtn : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, ExitBtn>
    {
        public ExitBtn(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override ExitBtn Clone()
        {
            var uiNode = new ExitBtn(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<StartMenuPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.StartGameBtn
        /// </summary>
        public StartGameBtn L_StartGameBtn
        {
            get
            {
                if (_L_StartGameBtn == null) _L_StartGameBtn = new StartGameBtn(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("StartGameBtn"));
                return _L_StartGameBtn;
            }
        }
        private StartGameBtn _L_StartGameBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.GearBtn
        /// </summary>
        public GearBtn L_GearBtn
        {
            get
            {
                if (_L_GearBtn == null) _L_GearBtn = new GearBtn(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("GearBtn"));
                return _L_GearBtn;
            }
        }
        private GearBtn _L_GearBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.SettingBtn
        /// </summary>
        public SettingBtn L_SettingBtn
        {
            get
            {
                if (_L_SettingBtn == null) _L_SettingBtn = new SettingBtn(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("SettingBtn"));
                return _L_SettingBtn;
            }
        }
        private SettingBtn _L_SettingBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.ExitBtn
        /// </summary>
        public ExitBtn L_ExitBtn
        {
            get
            {
                if (_L_ExitBtn == null) _L_ExitBtn = new ExitBtn(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("ExitBtn"));
                return _L_ExitBtn;
            }
        }
        private ExitBtn _L_ExitBtn;

        public HBoxContainer(StartMenuPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: StartMenu.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<StartMenuPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: StartMenu.MarginContainer.Control
        /// </summary>
        public Control L_Control
        {
            get
            {
                if (_L_Control == null) _L_Control = new Control(UiPanel, Instance.GetNode<Godot.Control>("Control"));
                return _L_Control;
            }
        }
        private Control _L_Control;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StartMenu.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer _L_HBoxContainer;

        public VBoxContainer(StartMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: StartMenu.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<StartMenuPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: StartMenu.TextureRect
        /// </summary>
        public TextureRect L_TextureRect
        {
            get
            {
                if (_L_TextureRect == null) _L_TextureRect = new TextureRect(UiPanel, Instance.GetNode<Godot.TextureRect>("TextureRect"));
                return _L_TextureRect;
            }
        }
        private TextureRect _L_TextureRect;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: StartMenu.VBoxContainer
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

        public MarginContainer(StartMenuPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.Setting.SettingPanel"/>, 路径: StartMenu.Setting
    /// </summary>
    public class Setting : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.Setting.SettingPanel, Setting>
    {
        public Setting(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.Setting.SettingPanel node) : base(uiPanel, node) {  }
        public override Setting Clone()
        {
            var uiNode = new Setting(UiPanel, (NovaDrift.Scripts.Ui.Setting.SettingPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: StartMenu.MarginContainer.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_MarginContainer.L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.Control
    /// </summary>
    public Control S_Control => L_MarginContainer.L_VBoxContainer.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.StartGameBtn
    /// </summary>
    public StartGameBtn S_StartGameBtn => L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_StartGameBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.GearBtn
    /// </summary>
    public GearBtn S_GearBtn => L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_GearBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.SettingBtn
    /// </summary>
    public SettingBtn S_SettingBtn => L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_SettingBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer.ExitBtn
    /// </summary>
    public ExitBtn S_ExitBtn => L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_ExitBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_MarginContainer.L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StartMenu.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.Setting.SettingPanel"/>, 节点路径: StartMenu.Setting
    /// </summary>
    public Setting S_Setting => L_Setting;

}
