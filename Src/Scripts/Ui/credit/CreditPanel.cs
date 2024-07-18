using System.Linq;
using DsUi;
using Godot;

namespace NovaDrift.Scripts.Ui.Credit;

public partial class CreditPanel : Credit
{
    private readonly string[][] _infos = [
        ["编程", "花神", "AcidWallStudio", "B-TO-THE-R"],
        ["美术", "花神", "AcidWallStudio", "B-TO-THE-R"],
        ["设计", "花神", "AcidWallStudio", "B-TO-THE-R"],
        ["音频", "Atelier Magicae @Itch","abstractionmusic.com", "WangleLine @patreon", "花神", "AcidWallStudio", "B-TO-THE-R"],
        ["市场", "花神", "AcidWallStudio", "B-TO-THE-R"],
        ["特殊鸣谢",
            "Riria/Ririsaurus",
            "忘忧の Daylily-Zelee",
            "Microsoft",
            "Advanced Micro Devices",
            "Godot Engine",
        ]
    ];

    public override void _Ready()
    {
        GenerateUi();
        S_CloseBtn.Instance.Pressed += () =>
        {
            this.ChangeTo(UiManager.Create_StartMenu());
        };
        PlayAnimation();
    }

    private async void PlayAnimation()
    {
        await ToSignal(GetTree().CreateTimer(1.0f), Timer.SignalName.Timeout);

        var tween = CreateTween();
        tween.TweenProperty(
            S_Scroll.Instance,
            "scroll_vertical",
            (float)S_Scroll.Instance.GetVScrollBar().MaxValue,
            20f);
    }

    private void GenerateUi()
    {
        var titleSetting = GD.Load<LabelSettings>("res://Assets/LabelSettings/SubTitleWhite.tres");
        var contentSetting = GD.Load<LabelSettings>("res://Assets/LabelSettings/BoldGray44.tres");
        
        foreach (var info in _infos)
        {
            var container = new Godot.VBoxContainer();
            container.Set("theme_override_constants/separation", 30f);
            S_Items.AddChild(container);

            var title = new Godot.Label()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                LabelSettings = titleSetting,
                Text = info[0],
            };
            
            container.AddChild(title);
            
            foreach (var item in info.Skip(1))
            {
                var content = new Godot.Label()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LabelSettings = contentSetting,
                    Text = item,
                };
                
                container.AddChild(content);
            }
        }
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
