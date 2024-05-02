namespace NovaDrift.Scripts.Ui.SelectAbility;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class SelectAbility : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: SelectAbility.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((SelectAbilityPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: SelectAbility.Content
    /// </summary>
    public Content L_Content
    {
        get
        {
            if (_L_Content == null) _L_Content = new Content((SelectAbilityPanel)this, GetNode<Godot.PanelContainer>("Content"));
            return _L_Content;
        }
    }
    private Content _L_Content;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: SelectAbility.Indicator
    /// </summary>
    public Indicator L_Indicator
    {
        get
        {
            if (_L_Indicator == null) _L_Indicator = new Indicator((SelectAbilityPanel)this, GetNode<Godot.TextureRect>("Indicator"));
            return _L_Indicator;
        }
    }
    private Indicator _L_Indicator;


    public SelectAbility() : base(nameof(SelectAbility))
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_Content.L_VBoxContainer.L_Content.L_Mods.L_CenterContainer;
        RecordNestedUi(inst1.L_AbilityTree.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_AbilityTree.Instance.OnCreateUi();
        inst1.L_AbilityTree.Instance.OnInitNestedUi();

        var inst2 = L_Content.L_VBoxContainer.L_Content;
        RecordNestedUi(inst2.L_AbilityPanel.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_AbilityPanel.Instance.OnCreateUi();
        inst2.L_AbilityPanel.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: SelectAbility.ColorRect
    /// </summary>
    public class ColorRect : UiNode<SelectAbilityPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(SelectAbilityPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items.ItemRow1
    /// </summary>
    public class ItemRow1 : UiNode<SelectAbilityPanel, Godot.HBoxContainer, ItemRow1>
    {
        public ItemRow1(SelectAbilityPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override ItemRow1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items.ItemRow2
    /// </summary>
    public class ItemRow2 : UiNode<SelectAbilityPanel, Godot.HBoxContainer, ItemRow2>
    {
        public ItemRow2(SelectAbilityPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override ItemRow2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items.ItemRow3
    /// </summary>
    public class ItemRow3 : UiNode<SelectAbilityPanel, Godot.HBoxContainer, ItemRow3>
    {
        public ItemRow3(SelectAbilityPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override ItemRow3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items
    /// </summary>
    public class Items : UiNode<SelectAbilityPanel, Godot.VBoxContainer, Items>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.ItemRow1
        /// </summary>
        public ItemRow1 L_ItemRow1
        {
            get
            {
                if (_L_ItemRow1 == null) _L_ItemRow1 = new ItemRow1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("ItemRow1"));
                return _L_ItemRow1;
            }
        }
        private ItemRow1 _L_ItemRow1;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.ItemRow2
        /// </summary>
        public ItemRow2 L_ItemRow2
        {
            get
            {
                if (_L_ItemRow2 == null) _L_ItemRow2 = new ItemRow2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("ItemRow2"));
                return _L_ItemRow2;
            }
        }
        private ItemRow2 _L_ItemRow2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.ItemRow3
        /// </summary>
        public ItemRow3 L_ItemRow3
        {
            get
            {
                if (_L_ItemRow3 == null) _L_ItemRow3 = new ItemRow3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("ItemRow3"));
                return _L_ItemRow3;
            }
        }
        private ItemRow3 _L_ItemRow3;

        public Items(SelectAbilityPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Items Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods.CenterContainer.AbilityTree
    /// </summary>
    public class AbilityTree : UiNode<SelectAbilityPanel, NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel, AbilityTree>
    {
        public AbilityTree(SelectAbilityPanel uiPanel, NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel node) : base(uiPanel, node) {  }
        public override AbilityTree Clone()
        {
            var uiNode = new AbilityTree(UiPanel, (NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.CenterContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods.CenterContainer
    /// </summary>
    public class CenterContainer : UiNode<SelectAbilityPanel, Godot.CenterContainer, CenterContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.AbilityTree
        /// </summary>
        public AbilityTree L_AbilityTree
        {
            get
            {
                if (_L_AbilityTree == null) _L_AbilityTree = new AbilityTree(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel>("AbilityTree"));
                return _L_AbilityTree;
            }
        }
        private AbilityTree _L_AbilityTree;

        public CenterContainer(SelectAbilityPanel uiPanel, Godot.CenterContainer node) : base(uiPanel, node) {  }
        public override CenterContainer Clone() => new (UiPanel, (Godot.CenterContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content.Mods
    /// </summary>
    public class Mods : UiNode<SelectAbilityPanel, Godot.VBoxContainer, Mods>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Items
        /// </summary>
        public Items L_Items
        {
            get
            {
                if (_L_Items == null) _L_Items = new Items(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Items"));
                return _L_Items;
            }
        }
        private Items _L_Items;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.CenterContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.CenterContainer
        /// </summary>
        public CenterContainer L_CenterContainer
        {
            get
            {
                if (_L_CenterContainer == null) _L_CenterContainer = new CenterContainer(UiPanel, Instance.GetNode<Godot.CenterContainer>("CenterContainer"));
                return _L_CenterContainer;
            }
        }
        private CenterContainer _L_CenterContainer;

        public Mods(SelectAbilityPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Mods Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 路径: SelectAbility.Content.VBoxContainer.Content.AbilityPanel
    /// </summary>
    public class AbilityPanel : UiNode<SelectAbilityPanel, NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel, AbilityPanel>
    {
        public AbilityPanel(SelectAbilityPanel uiPanel, NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel node) : base(uiPanel, node) {  }
        public override AbilityPanel Clone()
        {
            var uiNode = new AbilityPanel(UiPanel, (NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer.Content
    /// </summary>
    public class Content_1 : UiNode<SelectAbilityPanel, Godot.HBoxContainer, Content_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Mods
        /// </summary>
        public Mods L_Mods
        {
            get
            {
                if (_L_Mods == null) _L_Mods = new Mods(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Mods"));
                return _L_Mods;
            }
        }
        private Mods _L_Mods;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: SelectAbility.Content.VBoxContainer.AbilityPanel
        /// </summary>
        public AbilityPanel L_AbilityPanel
        {
            get
            {
                if (_L_AbilityPanel == null) _L_AbilityPanel = new AbilityPanel(UiPanel, Instance.GetNode<NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel>("AbilityPanel"));
                return _L_AbilityPanel;
            }
        }
        private AbilityPanel _L_AbilityPanel;

        public Content_1(SelectAbilityPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Content_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: SelectAbility.Content.VBoxContainer.CloseBtn
    /// </summary>
    public class CloseBtn : UiNode<SelectAbilityPanel, Godot.Button, CloseBtn>
    {
        public CloseBtn(SelectAbilityPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: SelectAbility.Content.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<SelectAbilityPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.Content
        /// </summary>
        public Content_1 L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Content"));
                return _L_Content;
            }
        }
        private Content_1 _L_Content;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: SelectAbility.Content.CloseBtn
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

        public VBoxContainer(SelectAbilityPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: SelectAbility.Content
    /// </summary>
    public class Content : UiNode<SelectAbilityPanel, Godot.PanelContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.VBoxContainer
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

        public Content(SelectAbilityPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: SelectAbility.Indicator
    /// </summary>
    public class Indicator : UiNode<SelectAbilityPanel, Godot.TextureRect, Indicator>
    {
        public Indicator(SelectAbilityPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Indicator Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: SelectAbility.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items.ItemRow1
    /// </summary>
    public ItemRow1 S_ItemRow1 => L_Content.L_VBoxContainer.L_Content.L_Mods.L_Items.L_ItemRow1;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items.ItemRow2
    /// </summary>
    public ItemRow2 S_ItemRow2 => L_Content.L_VBoxContainer.L_Content.L_Mods.L_Items.L_ItemRow2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items.ItemRow3
    /// </summary>
    public ItemRow3 S_ItemRow3 => L_Content.L_VBoxContainer.L_Content.L_Mods.L_Items.L_ItemRow3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.Items
    /// </summary>
    public Items S_Items => L_Content.L_VBoxContainer.L_Content.L_Mods.L_Items;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityTree.AbilityTreePanel"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.CenterContainer.AbilityTree
    /// </summary>
    public AbilityTree S_AbilityTree => L_Content.L_VBoxContainer.L_Content.L_Mods.L_CenterContainer.L_AbilityTree;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.CenterContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods.CenterContainer
    /// </summary>
    public CenterContainer S_CenterContainer => L_Content.L_VBoxContainer.L_Content.L_Mods.L_CenterContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.Mods
    /// </summary>
    public Mods S_Mods => L_Content.L_VBoxContainer.L_Content.L_Mods;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="NovaDrift.Scripts.Ui.AbilityPanel.AbilityPanelPanel"/>, 节点路径: SelectAbility.Content.VBoxContainer.Content.AbilityPanel
    /// </summary>
    public AbilityPanel S_AbilityPanel => L_Content.L_VBoxContainer.L_Content.L_AbilityPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: SelectAbility.Content.VBoxContainer.CloseBtn
    /// </summary>
    public CloseBtn S_CloseBtn => L_Content.L_VBoxContainer.L_CloseBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: SelectAbility.Content.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_Content.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: SelectAbility.Indicator
    /// </summary>
    public Indicator S_Indicator => L_Indicator;

}
