namespace NovaDrift.Scripts.Ui.StartMenu;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class StartMenu : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Control"/>, 节点路径: StartMenu.Control
    /// </summary>
    public Control L_Control
    {
        get
        {
            if (_L_Control == null) _L_Control = new Control((StartMenuPanel)this, GetNode<Godot.Control>("Control"));
            return _L_Control;
        }
    }
    private Control _L_Control;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StartMenu.Content
    /// </summary>
    public Content L_Content
    {
        get
        {
            if (_L_Content == null) _L_Content = new Content((StartMenuPanel)this, GetNode<Godot.MarginContainer>("Content"));
            return _L_Content;
        }
    }
    private Content _L_Content;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: StartMenu.GameLogo
    /// </summary>
    public GameLogo L_GameLogo
    {
        get
        {
            if (_L_GameLogo == null) _L_GameLogo = new GameLogo((StartMenuPanel)this, GetNode<Godot.TextureRect>("GameLogo"));
            return _L_GameLogo;
        }
    }
    private GameLogo _L_GameLogo;

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

        var inst1 = L_Control;
        RecordNestedUi(inst1.L_PartGame.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_PartGame.Instance.OnCreateUi();
        inst1.L_PartGame.Instance.OnInitNestedUi();

        var inst2 = L_Control;
        RecordNestedUi(inst2.L_GearBtn.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_GearBtn.Instance.OnCreateUi();
        inst2.L_GearBtn.Instance.OnInitNestedUi();

        var inst3 = L_Control;
        RecordNestedUi(inst3.L_DailyQuestsBtn.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_DailyQuestsBtn.Instance.OnCreateUi();
        inst3.L_DailyQuestsBtn.Instance.OnInitNestedUi();

        var inst4 = L_Content.L_HBoxContainer;
        RecordNestedUi(inst4.L_StartGameBtn.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_StartGameBtn.Instance.OnCreateUi();
        inst4.L_StartGameBtn.Instance.OnInitNestedUi();

        var inst5 = L_Content.L_HBoxContainer;
        RecordNestedUi(inst5.L_SettingBtn.Instance, inst5, UiManager.RecordType.Open);
        inst5.L_SettingBtn.Instance.OnCreateUi();
        inst5.L_SettingBtn.Instance.OnInitNestedUi();

        var inst6 = L_Content.L_HBoxContainer;
        RecordNestedUi(inst6.L_CreditBtn.Instance, inst6, UiManager.RecordType.Open);
        inst6.L_CreditBtn.Instance.OnCreateUi();
        inst6.L_CreditBtn.Instance.OnInitNestedUi();

        var inst7 = L_Content.L_HBoxContainer;
        RecordNestedUi(inst7.L_ExitBtn.Instance, inst7, UiManager.RecordType.Open);
        inst7.L_ExitBtn.Instance.OnCreateUi();
        inst7.L_ExitBtn.Instance.OnInitNestedUi();

        var inst8 = this;
        RecordNestedUi(inst8.L_Setting.Instance, null, UiManager.RecordType.Open);
        inst8.L_Setting.Instance.OnCreateUi();
        inst8.L_Setting.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Control.PartGame
    /// </summary>
    public class PartGame : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, PartGame>
    {
        public PartGame(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override PartGame Clone()
        {
            var uiNode = new PartGame(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Control.GearBtn
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
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Control.DailyQuestsBtn
    /// </summary>
    public class DailyQuestsBtn : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, DailyQuestsBtn>
    {
        public DailyQuestsBtn(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override DailyQuestsBtn Clone()
        {
            var uiNode = new DailyQuestsBtn(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.Control"/>, 路径: StartMenu.Control
    /// </summary>
    public class Control : UiNode<StartMenuPanel, Godot.Control, Control>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.PartGame
        /// </summary>
        public PartGame L_PartGame
        {
            get
            {
                if (_L_PartGame == null) _L_PartGame = new PartGame(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("PartGame"));
                return _L_PartGame;
            }
        }
        private PartGame _L_PartGame;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.GearBtn
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.DailyQuestsBtn
        /// </summary>
        public DailyQuestsBtn L_DailyQuestsBtn
        {
            get
            {
                if (_L_DailyQuestsBtn == null) _L_DailyQuestsBtn = new DailyQuestsBtn(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("DailyQuestsBtn"));
                return _L_DailyQuestsBtn;
            }
        }
        private DailyQuestsBtn _L_DailyQuestsBtn;

        public Control(StartMenuPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Content.HBoxContainer.StartGameBtn
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
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Content.HBoxContainer.SettingBtn
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
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Content.HBoxContainer.CreditBtn
    /// </summary>
    public class CreditBtn : UiNode<StartMenuPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel, CreditBtn>
    {
        public CreditBtn(StartMenuPanel uiPanel, NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel node) : base(uiPanel, node) {  }
        public override CreditBtn Clone()
        {
            var uiNode = new CreditBtn(UiPanel, (NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 路径: StartMenu.Content.HBoxContainer.ExitBtn
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
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: StartMenu.Content.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<StartMenuPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.StartGameBtn
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.SettingBtn
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.CreditBtn
        /// </summary>
        public CreditBtn L_CreditBtn
        {
            get
            {
                if (_L_CreditBtn == null) _L_CreditBtn = new CreditBtn(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel>("CreditBtn"));
                return _L_CreditBtn;
            }
        }
        private CreditBtn _L_CreditBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.ExitBtn
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
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: StartMenu.Content
    /// </summary>
    public class Content : UiNode<StartMenuPanel, Godot.MarginContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StartMenu.HBoxContainer
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

        public Content(StartMenuPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.AnimationPlayer"/>, 路径: StartMenu.GameLogo.AnimationPlayer
    /// </summary>
    public class AnimationPlayer : UiNode<StartMenuPanel, Godot.AnimationPlayer, AnimationPlayer>
    {
        public AnimationPlayer(StartMenuPanel uiPanel, Godot.AnimationPlayer node) : base(uiPanel, node) {  }
        public override AnimationPlayer Clone() => new (UiPanel, (Godot.AnimationPlayer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: StartMenu.GameLogo.GameLogoTouch.Label
    /// </summary>
    public class Label : UiNode<StartMenuPanel, Godot.Label, Label>
    {
        public Label(StartMenuPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: StartMenu.GameLogo.GameLogoTouch
    /// </summary>
    public class GameLogoTouch : UiNode<StartMenuPanel, Godot.Button, GameLogoTouch>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: StartMenu.GameLogo.Label
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

        public GameLogoTouch(StartMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GameLogoTouch Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureButton"/>, 路径: StartMenu.GameLogo.LoginBtn
    /// </summary>
    public class LoginBtn : UiNode<StartMenuPanel, Godot.TextureButton, LoginBtn>
    {
        public LoginBtn(StartMenuPanel uiPanel, Godot.TextureButton node) : base(uiPanel, node) {  }
        public override LoginBtn Clone() => new (UiPanel, (Godot.TextureButton)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: StartMenu.GameLogo
    /// </summary>
    public class GameLogo : UiNode<StartMenuPanel, Godot.TextureRect, GameLogo>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.AnimationPlayer"/>, 节点路径: StartMenu.AnimationPlayer
        /// </summary>
        public AnimationPlayer L_AnimationPlayer
        {
            get
            {
                if (_L_AnimationPlayer == null) _L_AnimationPlayer = new AnimationPlayer(UiPanel, Instance.GetNode<Godot.AnimationPlayer>("AnimationPlayer"));
                return _L_AnimationPlayer;
            }
        }
        private AnimationPlayer _L_AnimationPlayer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.GameLogoTouch
        /// </summary>
        public GameLogoTouch L_GameLogoTouch
        {
            get
            {
                if (_L_GameLogoTouch == null) _L_GameLogoTouch = new GameLogoTouch(UiPanel, Instance.GetNode<Godot.Button>("GameLogoTouch"));
                return _L_GameLogoTouch;
            }
        }
        private GameLogoTouch _L_GameLogoTouch;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureButton"/>, 节点路径: StartMenu.LoginBtn
        /// </summary>
        public LoginBtn L_LoginBtn
        {
            get
            {
                if (_L_LoginBtn == null) _L_LoginBtn = new LoginBtn(UiPanel, Instance.GetNode<Godot.TextureButton>("LoginBtn"));
                return _L_LoginBtn;
            }
        }
        private LoginBtn _L_LoginBtn;

        public GameLogo(StartMenuPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override GameLogo Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
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
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Control.PartGame
    /// </summary>
    public PartGame S_PartGame => L_Control.L_PartGame;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Control.GearBtn
    /// </summary>
    public GearBtn S_GearBtn => L_Control.L_GearBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Control.DailyQuestsBtn
    /// </summary>
    public DailyQuestsBtn S_DailyQuestsBtn => L_Control.L_DailyQuestsBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Control"/>, 节点路径: StartMenu.Control
    /// </summary>
    public Control S_Control => L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.HBoxContainer.StartGameBtn
    /// </summary>
    public StartGameBtn S_StartGameBtn => L_Content.L_HBoxContainer.L_StartGameBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.HBoxContainer.SettingBtn
    /// </summary>
    public SettingBtn S_SettingBtn => L_Content.L_HBoxContainer.L_SettingBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.HBoxContainer.CreditBtn
    /// </summary>
    public CreditBtn S_CreditBtn => L_Content.L_HBoxContainer.L_CreditBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GalleryBtn.GalleryBtnPanel"/>, 节点路径: StartMenu.Content.HBoxContainer.ExitBtn
    /// </summary>
    public ExitBtn S_ExitBtn => L_Content.L_HBoxContainer.L_ExitBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: StartMenu.Content.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_Content.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StartMenu.Content
    /// </summary>
    public Content S_Content => L_Content;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.AnimationPlayer"/>, 节点路径: StartMenu.GameLogo.AnimationPlayer
    /// </summary>
    public AnimationPlayer S_AnimationPlayer => L_GameLogo.L_AnimationPlayer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: StartMenu.GameLogo.GameLogoTouch.Label
    /// </summary>
    public Label S_Label => L_GameLogo.L_GameLogoTouch.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.GameLogo.GameLogoTouch
    /// </summary>
    public GameLogoTouch S_GameLogoTouch => L_GameLogo.L_GameLogoTouch;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureButton"/>, 节点路径: StartMenu.GameLogo.LoginBtn
    /// </summary>
    public LoginBtn S_LoginBtn => L_GameLogo.L_LoginBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: StartMenu.GameLogo
    /// </summary>
    public GameLogo S_GameLogo => L_GameLogo;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.Setting.SettingPanel"/>, 节点路径: StartMenu.Setting
    /// </summary>
    public Setting S_Setting => L_Setting;

}
