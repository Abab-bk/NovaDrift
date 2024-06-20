namespace NovaDrift.Scripts.Ui.GearLibrary;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class GearLibrary : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GearLibrary.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((GearLibraryPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer
    /// </summary>
    public VBoxContainer L_VBoxContainer
    {
        get
        {
            if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer((GearLibraryPanel)this, GetNode<Godot.VBoxContainer>("VBoxContainer"));
            return _L_VBoxContainer;
        }
    }
    private VBoxContainer _L_VBoxContainer;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureButton"/>, 节点路径: GearLibrary.CloseBtn
    /// </summary>
    public CloseBtn L_CloseBtn
    {
        get
        {
            if (_L_CloseBtn == null) _L_CloseBtn = new CloseBtn((GearLibraryPanel)this, GetNode<Godot.TextureButton>("CloseBtn"));
            return _L_CloseBtn;
        }
    }
    private CloseBtn _L_CloseBtn;


    public GearLibrary() : base(nameof(GearLibrary))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer;
        RecordNestedUi(inst1.L_GoodsItem.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_GoodsItem.Instance.OnCreateUi();
        inst1.L_GoodsItem.Instance.OnInitNestedUi();

        var inst2 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer;
        RecordNestedUi(inst2.L_GoodsItem2.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_GoodsItem2.Instance.OnCreateUi();
        inst2.L_GoodsItem2.Instance.OnInitNestedUi();

        var inst3 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer2;
        RecordNestedUi(inst3.L_GoodsItem.Instance, inst3, UiManager.RecordType.Open);
        inst3.L_GoodsItem.Instance.OnCreateUi();
        inst3.L_GoodsItem.Instance.OnInitNestedUi();

        var inst4 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer2;
        RecordNestedUi(inst4.L_GoodsItem2.Instance, inst4, UiManager.RecordType.Open);
        inst4.L_GoodsItem2.Instance.OnCreateUi();
        inst4.L_GoodsItem2.Instance.OnInitNestedUi();

        var inst5 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer3;
        RecordNestedUi(inst5.L_GoodsItem.Instance, inst5, UiManager.RecordType.Open);
        inst5.L_GoodsItem.Instance.OnCreateUi();
        inst5.L_GoodsItem.Instance.OnInitNestedUi();

        var inst6 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer3;
        RecordNestedUi(inst6.L_GoodsItem2.Instance, inst6, UiManager.RecordType.Open);
        inst6.L_GoodsItem2.Instance.OnCreateUi();
        inst6.L_GoodsItem2.Instance.OnInitNestedUi();

        var inst7 = L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods;
        RecordNestedUi(inst7.L_GoodsItem.Instance, inst7, UiManager.RecordType.Open);
        inst7.L_GoodsItem.Instance.OnCreateUi();
        inst7.L_GoodsItem.Instance.OnInitNestedUi();

        var inst8 = L_VBoxContainer.L_Content.L_Content.L_UpGrade.L_Goods;
        RecordNestedUi(inst8.L_GoodsItem.Instance, inst8, UiManager.RecordType.Open);
        inst8.L_GoodsItem.Instance.OnCreateUi();
        inst8.L_GoodsItem.Instance.OnInitNestedUi();

        var inst9 = L_VBoxContainer.L_Content.L_Content.L_UpGrade.L_Goods;
        RecordNestedUi(inst9.L_GoodsItem2.Instance, inst9, UiManager.RecordType.Open);
        inst9.L_GoodsItem2.Instance.OnCreateUi();
        inst9.L_GoodsItem2.Instance.OnInitNestedUi();

        var inst10 = L_VBoxContainer.L_Content.L_Content.L_UiSkin.L_Goods;
        RecordNestedUi(inst10.L_GoodsItem.Instance, inst10, UiManager.RecordType.Open);
        inst10.L_GoodsItem.Instance.OnCreateUi();
        inst10.L_GoodsItem.Instance.OnInitNestedUi();

        var inst11 = L_VBoxContainer.L_Content.L_Content.L_Animation.L_Goods;
        RecordNestedUi(inst11.L_GoodsItem.Instance, inst11, UiManager.RecordType.Open);
        inst11.L_GoodsItem.Instance.OnCreateUi();
        inst11.L_GoodsItem.Instance.OnInitNestedUi();

        var inst12 = L_VBoxContainer.L_Content.L_Content.L_Animation.L_Goods;
        RecordNestedUi(inst12.L_GoodsItem2.Instance, inst12, UiManager.RecordType.Open);
        inst12.L_GoodsItem2.Instance.OnCreateUi();
        inst12.L_GoodsItem2.Instance.OnInitNestedUi();

        var inst13 = L_VBoxContainer.L_Content.L_Content.L_Gear.L_Goods;
        RecordNestedUi(inst13.L_GoodsItem.Instance, inst13, UiManager.RecordType.Open);
        inst13.L_GoodsItem.Instance.OnCreateUi();
        inst13.L_GoodsItem.Instance.OnInitNestedUi();

        var inst14 = L_VBoxContainer.L_Content.L_Content.L_Gear.L_Goods;
        RecordNestedUi(inst14.L_GoodsItem2.Instance, inst14, UiManager.RecordType.Open);
        inst14.L_GoodsItem2.Instance.OnCreateUi();
        inst14.L_GoodsItem2.Instance.OnInitNestedUi();

        var inst15 = L_VBoxContainer.L_Content.L_Content.L_Gear.L_Goods;
        RecordNestedUi(inst15.L_GoodsItem3.Instance, inst15, UiManager.RecordType.Open);
        inst15.L_GoodsItem3.Instance.OnCreateUi();
        inst15.L_GoodsItem3.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: GearLibrary.PanelContainer.MarginContainer.HBoxContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<GearLibraryPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(GearLibraryPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GearLibrary.PanelContainer.MarginContainer.HBoxContainer.AcidCoinsLabel
    /// </summary>
    public class AcidCoinsLabel : UiNode<GearLibraryPanel, Godot.Label, AcidCoinsLabel>
    {
        public AcidCoinsLabel(GearLibraryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AcidCoinsLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.PanelContainer.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<GearLibraryPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GearLibrary.PanelContainer.MarginContainer.TextureRect
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.PanelContainer.MarginContainer.AcidCoinsLabel
        /// </summary>
        public AcidCoinsLabel L_AcidCoinsLabel
        {
            get
            {
                if (_L_AcidCoinsLabel == null) _L_AcidCoinsLabel = new AcidCoinsLabel(UiPanel, Instance.GetNode<Godot.Label>("AcidCoinsLabel"));
                return _L_AcidCoinsLabel;
            }
        }
        private AcidCoinsLabel _L_AcidCoinsLabel;

        public HBoxContainer(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GearLibrary.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<GearLibraryPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.PanelContainer.HBoxContainer
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

        public MarginContainer(GearLibraryPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GearLibrary.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<GearLibraryPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GearLibrary.MarginContainer
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

        public PanelContainer(GearLibraryPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Label
    /// </summary>
    public class Label : UiNode<GearLibraryPanel, Godot.Label, Label>
    {
        public Label(GearLibraryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer.GoodsItem
    /// </summary>
    public class GoodsItem : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem>
    {
        public GoodsItem(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem Clone()
        {
            var uiNode = new GoodsItem(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer.GoodsItem2
    /// </summary>
    public class GoodsItem2 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem2>
    {
        public GoodsItem2(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem2 Clone()
        {
            var uiNode = new GoodsItem2(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<GearLibraryPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem
        /// </summary>
        public GoodsItem L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem _L_GoodsItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem2
        /// </summary>
        public GoodsItem2 L_GoodsItem2
        {
            get
            {
                if (_L_GoodsItem2 == null) _L_GoodsItem2 = new GoodsItem2(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem2"));
                return _L_GoodsItem2;
            }
        }
        private GoodsItem2 _L_GoodsItem2;

        public VBoxContainer_1(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer2.GoodsItem
    /// </summary>
    public class GoodsItem_1 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_1>
    {
        public GoodsItem_1(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_1 Clone()
        {
            var uiNode = new GoodsItem_1(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer2.GoodsItem2
    /// </summary>
    public class GoodsItem2_1 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem2_1>
    {
        public GoodsItem2_1(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem2_1 Clone()
        {
            var uiNode = new GoodsItem2_1(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer2
    /// </summary>
    public class VBoxContainer2 : UiNode<GearLibraryPanel, Godot.VBoxContainer, VBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem
        /// </summary>
        public GoodsItem_1 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_1(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_1 _L_GoodsItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem2
        /// </summary>
        public GoodsItem2_1 L_GoodsItem2
        {
            get
            {
                if (_L_GoodsItem2 == null) _L_GoodsItem2 = new GoodsItem2_1(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem2"));
                return _L_GoodsItem2;
            }
        }
        private GoodsItem2_1 _L_GoodsItem2;

        public VBoxContainer2(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer3.GoodsItem
    /// </summary>
    public class GoodsItem_2 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_2>
    {
        public GoodsItem_2(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_2 Clone()
        {
            var uiNode = new GoodsItem_2(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer3.GoodsItem2
    /// </summary>
    public class GoodsItem2_2 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem2_2>
    {
        public GoodsItem2_2(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem2_2 Clone()
        {
            var uiNode = new GoodsItem2_2(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer3
    /// </summary>
    public class VBoxContainer3 : UiNode<GearLibraryPanel, Godot.VBoxContainer, VBoxContainer3>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem
        /// </summary>
        public GoodsItem_2 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_2(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_2 _L_GoodsItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem2
        /// </summary>
        public GoodsItem2_2 L_GoodsItem2
        {
            get
            {
                if (_L_GoodsItem2 == null) _L_GoodsItem2 = new GoodsItem2_2(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem2"));
                return _L_GoodsItem2;
            }
        }
        private GoodsItem2_2 _L_GoodsItem2;

        public VBoxContainer3(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer3 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.GoodsItem
    /// </summary>
    public class GoodsItem_3 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_3>
    {
        public GoodsItem_3(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_3 Clone()
        {
            var uiNode = new GoodsItem_3(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods
    /// </summary>
    public class Goods : UiNode<GearLibraryPanel, Godot.HBoxContainer, Goods>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.VBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.VBoxContainer2
        /// </summary>
        public VBoxContainer2 L_VBoxContainer2
        {
            get
            {
                if (_L_VBoxContainer2 == null) _L_VBoxContainer2 = new VBoxContainer2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer2"));
                return _L_VBoxContainer2;
            }
        }
        private VBoxContainer2 _L_VBoxContainer2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.VBoxContainer3
        /// </summary>
        public VBoxContainer3 L_VBoxContainer3
        {
            get
            {
                if (_L_VBoxContainer3 == null) _L_VBoxContainer3 = new VBoxContainer3(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer3"));
                return _L_VBoxContainer3;
            }
        }
        private VBoxContainer3 _L_VBoxContainer3;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.GoodsItem
        /// </summary>
        public GoodsItem_3 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_3(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_3 _L_GoodsItem;

        public Goods(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Goods Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Home
    /// </summary>
    public class Home : UiNode<GearLibraryPanel, Godot.VBoxContainer, Home>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Goods
        /// </summary>
        public Goods L_Goods
        {
            get
            {
                if (_L_Goods == null) _L_Goods = new Goods(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Goods"));
                return _L_Goods;
            }
        }
        private Goods _L_Goods;

        public Home(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Home Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UpGrade.Label
    /// </summary>
    public class Label_1 : UiNode<GearLibraryPanel, Godot.Label, Label_1>
    {
        public Label_1(GearLibraryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UpGrade.Goods.GoodsItem
    /// </summary>
    public class GoodsItem_4 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_4>
    {
        public GoodsItem_4(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_4 Clone()
        {
            var uiNode = new GoodsItem_4(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UpGrade.Goods.GoodsItem2
    /// </summary>
    public class GoodsItem2_3 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem2_3>
    {
        public GoodsItem2_3(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem2_3 Clone()
        {
            var uiNode = new GoodsItem2_3(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UpGrade.Goods
    /// </summary>
    public class Goods_1 : UiNode<GearLibraryPanel, Godot.HBoxContainer, Goods_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.UpGrade.GoodsItem
        /// </summary>
        public GoodsItem_4 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_4(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_4 _L_GoodsItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.UpGrade.GoodsItem2
        /// </summary>
        public GoodsItem2_3 L_GoodsItem2
        {
            get
            {
                if (_L_GoodsItem2 == null) _L_GoodsItem2 = new GoodsItem2_3(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem2"));
                return _L_GoodsItem2;
            }
        }
        private GoodsItem2_3 _L_GoodsItem2;

        public Goods_1(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Goods_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UpGrade
    /// </summary>
    public class UpGrade : UiNode<GearLibraryPanel, Godot.VBoxContainer, UpGrade>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Goods
        /// </summary>
        public Goods_1 L_Goods
        {
            get
            {
                if (_L_Goods == null) _L_Goods = new Goods_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Goods"));
                return _L_Goods;
            }
        }
        private Goods_1 _L_Goods;

        public UpGrade(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override UpGrade Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UiSkin.Label
    /// </summary>
    public class Label_2 : UiNode<GearLibraryPanel, Godot.Label, Label_2>
    {
        public Label_2(GearLibraryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UiSkin.Goods.GoodsItem
    /// </summary>
    public class GoodsItem_5 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_5>
    {
        public GoodsItem_5(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_5 Clone()
        {
            var uiNode = new GoodsItem_5(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UiSkin.Goods
    /// </summary>
    public class Goods_2 : UiNode<GearLibraryPanel, Godot.HBoxContainer, Goods_2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.UiSkin.GoodsItem
        /// </summary>
        public GoodsItem_5 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_5(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_5 _L_GoodsItem;

        public Goods_2(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Goods_2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.UiSkin
    /// </summary>
    public class UiSkin : UiNode<GearLibraryPanel, Godot.VBoxContainer, UiSkin>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Goods
        /// </summary>
        public Goods_2 L_Goods
        {
            get
            {
                if (_L_Goods == null) _L_Goods = new Goods_2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Goods"));
                return _L_Goods;
            }
        }
        private Goods_2 _L_Goods;

        public UiSkin(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override UiSkin Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Animation.Label
    /// </summary>
    public class Label_3 : UiNode<GearLibraryPanel, Godot.Label, Label_3>
    {
        public Label_3(GearLibraryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_3 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Animation.Goods.GoodsItem
    /// </summary>
    public class GoodsItem_6 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_6>
    {
        public GoodsItem_6(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_6 Clone()
        {
            var uiNode = new GoodsItem_6(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Animation.Goods.GoodsItem2
    /// </summary>
    public class GoodsItem2_4 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem2_4>
    {
        public GoodsItem2_4(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem2_4 Clone()
        {
            var uiNode = new GoodsItem2_4(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Animation.Goods
    /// </summary>
    public class Goods_3 : UiNode<GearLibraryPanel, Godot.HBoxContainer, Goods_3>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Animation.GoodsItem
        /// </summary>
        public GoodsItem_6 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_6(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_6 _L_GoodsItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Animation.GoodsItem2
        /// </summary>
        public GoodsItem2_4 L_GoodsItem2
        {
            get
            {
                if (_L_GoodsItem2 == null) _L_GoodsItem2 = new GoodsItem2_4(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem2"));
                return _L_GoodsItem2;
            }
        }
        private GoodsItem2_4 _L_GoodsItem2;

        public Goods_3(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Goods_3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Animation
    /// </summary>
    public class Animation : UiNode<GearLibraryPanel, Godot.VBoxContainer, Animation>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Goods
        /// </summary>
        public Goods_3 L_Goods
        {
            get
            {
                if (_L_Goods == null) _L_Goods = new Goods_3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Goods"));
                return _L_Goods;
            }
        }
        private Goods_3 _L_Goods;

        public Animation(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Animation Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Gear.Label
    /// </summary>
    public class Label_4 : UiNode<GearLibraryPanel, Godot.Label, Label_4>
    {
        public Label_4(GearLibraryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_4 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Gear.Goods.GoodsItem
    /// </summary>
    public class GoodsItem_7 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem_7>
    {
        public GoodsItem_7(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem_7 Clone()
        {
            var uiNode = new GoodsItem_7(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Gear.Goods.GoodsItem2
    /// </summary>
    public class GoodsItem2_5 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem2_5>
    {
        public GoodsItem2_5(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem2_5 Clone()
        {
            var uiNode = new GoodsItem2_5(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Gear.Goods.GoodsItem3
    /// </summary>
    public class GoodsItem3 : UiNode<GearLibraryPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel, GoodsItem3>
    {
        public GoodsItem3(GearLibraryPanel uiPanel, NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel node) : base(uiPanel, node) {  }
        public override GoodsItem3 Clone()
        {
            var uiNode = new GoodsItem3(UiPanel, (NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Gear.Goods
    /// </summary>
    public class Goods_4 : UiNode<GearLibraryPanel, Godot.HBoxContainer, Goods_4>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Gear.GoodsItem
        /// </summary>
        public GoodsItem_7 L_GoodsItem
        {
            get
            {
                if (_L_GoodsItem == null) _L_GoodsItem = new GoodsItem_7(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem"));
                return _L_GoodsItem;
            }
        }
        private GoodsItem_7 _L_GoodsItem;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Gear.GoodsItem2
        /// </summary>
        public GoodsItem2_5 L_GoodsItem2
        {
            get
            {
                if (_L_GoodsItem2 == null) _L_GoodsItem2 = new GoodsItem2_5(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem2"));
                return _L_GoodsItem2;
            }
        }
        private GoodsItem2_5 _L_GoodsItem2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Gear.GoodsItem3
        /// </summary>
        public GoodsItem3 L_GoodsItem3
        {
            get
            {
                if (_L_GoodsItem3 == null) _L_GoodsItem3 = new GoodsItem3(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel>("GoodsItem3"));
                return _L_GoodsItem3;
            }
        }
        private GoodsItem3 _L_GoodsItem3;

        public Goods_4(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Goods_4 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content.Gear
    /// </summary>
    public class Gear : UiNode<GearLibraryPanel, Godot.VBoxContainer, Gear>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Label
        /// </summary>
        public Label_4 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_4(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_4 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Goods
        /// </summary>
        public Goods_4 L_Goods
        {
            get
            {
                if (_L_Goods == null) _L_Goods = new Goods_4(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Goods"));
                return _L_Goods;
            }
        }
        private Goods_4 _L_Goods;

        public Gear(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Gear Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TabContainer"/>, 路径: GearLibrary.VBoxContainer.Content.Content
    /// </summary>
    public class Content_1 : UiNode<GearLibraryPanel, Godot.TabContainer, Content_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Home
        /// </summary>
        public Home L_Home
        {
            get
            {
                if (_L_Home == null) _L_Home = new Home(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Home"));
                return _L_Home;
            }
        }
        private Home _L_Home;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.UpGrade
        /// </summary>
        public UpGrade L_UpGrade
        {
            get
            {
                if (_L_UpGrade == null) _L_UpGrade = new UpGrade(UiPanel, Instance.GetNode<Godot.VBoxContainer>("UpGrade"));
                return _L_UpGrade;
            }
        }
        private UpGrade _L_UpGrade;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.UiSkin
        /// </summary>
        public UiSkin L_UiSkin
        {
            get
            {
                if (_L_UiSkin == null) _L_UiSkin = new UiSkin(UiPanel, Instance.GetNode<Godot.VBoxContainer>("UiSkin"));
                return _L_UiSkin;
            }
        }
        private UiSkin _L_UiSkin;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Animation
        /// </summary>
        public Animation L_Animation
        {
            get
            {
                if (_L_Animation == null) _L_Animation = new Animation(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Animation"));
                return _L_Animation;
            }
        }
        private Animation _L_Animation;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Gear
        /// </summary>
        public Gear L_Gear
        {
            get
            {
                if (_L_Gear == null) _L_Gear = new Gear(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Gear"));
                return _L_Gear;
            }
        }
        private Gear _L_Gear;

        public Content_1(GearLibraryPanel uiPanel, Godot.TabContainer node) : base(uiPanel, node) {  }
        public override Content_1 Clone() => new (UiPanel, (Godot.TabContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GearLibrary.VBoxContainer.Content
    /// </summary>
    public class Content : UiNode<GearLibraryPanel, Godot.MarginContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TabContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content
        /// </summary>
        public Content_1 L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content_1(UiPanel, Instance.GetNode<Godot.TabContainer>("Content"));
                return _L_Content;
            }
        }
        private Content_1 _L_Content;

        public Content(GearLibraryPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.HomeBtn
    /// </summary>
    public class HomeBtn : UiNode<GearLibraryPanel, Godot.Button, HomeBtn>
    {
        public HomeBtn(GearLibraryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override HomeBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.UpgradeBtn
    /// </summary>
    public class UpgradeBtn : UiNode<GearLibraryPanel, Godot.Button, UpgradeBtn>
    {
        public UpgradeBtn(GearLibraryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override UpgradeBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.UiSkinBtn
    /// </summary>
    public class UiSkinBtn : UiNode<GearLibraryPanel, Godot.Button, UiSkinBtn>
    {
        public UiSkinBtn(GearLibraryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override UiSkinBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.AnimationBtn
    /// </summary>
    public class AnimationBtn : UiNode<GearLibraryPanel, Godot.Button, AnimationBtn>
    {
        public AnimationBtn(GearLibraryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override AnimationBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.GearBtn
    /// </summary>
    public class GearBtn : UiNode<GearLibraryPanel, Godot.Button, GearBtn>
    {
        public GearBtn(GearLibraryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GearBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.InventoryBtn
    /// </summary>
    public class InventoryBtn : UiNode<GearLibraryPanel, Godot.Button, InventoryBtn>
    {
        public InventoryBtn(GearLibraryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override InventoryBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_1 : UiNode<GearLibraryPanel, Godot.HBoxContainer, HBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HomeBtn
        /// </summary>
        public HomeBtn L_HomeBtn
        {
            get
            {
                if (_L_HomeBtn == null) _L_HomeBtn = new HomeBtn(UiPanel, Instance.GetNode<Godot.Button>("HomeBtn"));
                return _L_HomeBtn;
            }
        }
        private HomeBtn _L_HomeBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.UpgradeBtn
        /// </summary>
        public UpgradeBtn L_UpgradeBtn
        {
            get
            {
                if (_L_UpgradeBtn == null) _L_UpgradeBtn = new UpgradeBtn(UiPanel, Instance.GetNode<Godot.Button>("UpgradeBtn"));
                return _L_UpgradeBtn;
            }
        }
        private UpgradeBtn _L_UpgradeBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.UiSkinBtn
        /// </summary>
        public UiSkinBtn L_UiSkinBtn
        {
            get
            {
                if (_L_UiSkinBtn == null) _L_UiSkinBtn = new UiSkinBtn(UiPanel, Instance.GetNode<Godot.Button>("UiSkinBtn"));
                return _L_UiSkinBtn;
            }
        }
        private UiSkinBtn _L_UiSkinBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.AnimationBtn
        /// </summary>
        public AnimationBtn L_AnimationBtn
        {
            get
            {
                if (_L_AnimationBtn == null) _L_AnimationBtn = new AnimationBtn(UiPanel, Instance.GetNode<Godot.Button>("AnimationBtn"));
                return _L_AnimationBtn;
            }
        }
        private AnimationBtn _L_AnimationBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.GearBtn
        /// </summary>
        public GearBtn L_GearBtn
        {
            get
            {
                if (_L_GearBtn == null) _L_GearBtn = new GearBtn(UiPanel, Instance.GetNode<Godot.Button>("GearBtn"));
                return _L_GearBtn;
            }
        }
        private GearBtn _L_GearBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.InventoryBtn
        /// </summary>
        public InventoryBtn L_InventoryBtn
        {
            get
            {
                if (_L_InventoryBtn == null) _L_InventoryBtn = new InventoryBtn(UiPanel, Instance.GetNode<Godot.Button>("InventoryBtn"));
                return _L_InventoryBtn;
            }
        }
        private InventoryBtn _L_InventoryBtn;

        public HBoxContainer_1(GearLibraryPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<GearLibraryPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.HBoxContainer
        /// </summary>
        public HBoxContainer_1 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_1 _L_HBoxContainer;

        public MarginContainer_1(GearLibraryPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: GearLibrary.VBoxContainer.BottomBar
    /// </summary>
    public class BottomBar : UiNode<GearLibraryPanel, Godot.PanelContainer, BottomBar>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GearLibrary.VBoxContainer.MarginContainer
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

        public BottomBar(GearLibraryPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override BottomBar Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: GearLibrary.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<GearLibraryPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: GearLibrary.Content
        /// </summary>
        public Content L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content(UiPanel, Instance.GetNode<Godot.MarginContainer>("Content"));
                return _L_Content;
            }
        }
        private Content _L_Content;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GearLibrary.BottomBar
        /// </summary>
        public BottomBar L_BottomBar
        {
            get
            {
                if (_L_BottomBar == null) _L_BottomBar = new BottomBar(UiPanel, Instance.GetNode<Godot.PanelContainer>("BottomBar"));
                return _L_BottomBar;
            }
        }
        private BottomBar _L_BottomBar;

        public VBoxContainer(GearLibraryPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureButton"/>, 路径: GearLibrary.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<GearLibraryPanel, Godot.TextureButton, CloseBtn>
    {
        public CloseBtn(GearLibraryPanel uiPanel, Godot.TextureButton node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.TextureButton)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: GearLibrary.PanelContainer.MarginContainer.HBoxContainer.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: GearLibrary.PanelContainer.MarginContainer.HBoxContainer.AcidCoinsLabel
    /// </summary>
    public AcidCoinsLabel S_AcidCoinsLabel => L_PanelContainer.L_MarginContainer.L_HBoxContainer.L_AcidCoinsLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GearLibrary.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer2
    /// </summary>
    public VBoxContainer2 S_VBoxContainer2 => L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home.Goods.VBoxContainer3
    /// </summary>
    public VBoxContainer3 S_VBoxContainer3 => L_VBoxContainer.L_Content.L_Content.L_Home.L_Goods.L_VBoxContainer3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Home
    /// </summary>
    public Home S_Home => L_VBoxContainer.L_Content.L_Content.L_Home;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.UpGrade
    /// </summary>
    public UpGrade S_UpGrade => L_VBoxContainer.L_Content.L_Content.L_UpGrade;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.UiSkin
    /// </summary>
    public UiSkin S_UiSkin => L_VBoxContainer.L_Content.L_Content.L_UiSkin;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Animation
    /// </summary>
    public Animation S_Animation => L_VBoxContainer.L_Content.L_Content.L_Animation;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.GoodsItem.GoodsItemPanel"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Gear.Goods.GoodsItem3
    /// </summary>
    public GoodsItem3 S_GoodsItem3 => L_VBoxContainer.L_Content.L_Content.L_Gear.L_Goods.L_GoodsItem3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: GearLibrary.VBoxContainer.Content.Content.Gear
    /// </summary>
    public Gear S_Gear => L_VBoxContainer.L_Content.L_Content.L_Gear;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.HomeBtn
    /// </summary>
    public HomeBtn S_HomeBtn => L_VBoxContainer.L_BottomBar.L_MarginContainer.L_HBoxContainer.L_HomeBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.UpgradeBtn
    /// </summary>
    public UpgradeBtn S_UpgradeBtn => L_VBoxContainer.L_BottomBar.L_MarginContainer.L_HBoxContainer.L_UpgradeBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.UiSkinBtn
    /// </summary>
    public UiSkinBtn S_UiSkinBtn => L_VBoxContainer.L_BottomBar.L_MarginContainer.L_HBoxContainer.L_UiSkinBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.AnimationBtn
    /// </summary>
    public AnimationBtn S_AnimationBtn => L_VBoxContainer.L_BottomBar.L_MarginContainer.L_HBoxContainer.L_AnimationBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.GearBtn
    /// </summary>
    public GearBtn S_GearBtn => L_VBoxContainer.L_BottomBar.L_MarginContainer.L_HBoxContainer.L_GearBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar.MarginContainer.HBoxContainer.InventoryBtn
    /// </summary>
    public InventoryBtn S_InventoryBtn => L_VBoxContainer.L_BottomBar.L_MarginContainer.L_HBoxContainer.L_InventoryBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: GearLibrary.VBoxContainer.BottomBar
    /// </summary>
    public BottomBar S_BottomBar => L_VBoxContainer.L_BottomBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureButton"/>, 节点路径: GearLibrary.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_CloseBtn;

}
