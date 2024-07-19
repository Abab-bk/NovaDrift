using System;
using System.Threading.Tasks;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Ui.Tutorial;

public partial class TutorialPanel : Tutorial
{
    private Action _drawCommands;

    public async void Launch(Func<Task>[] commands)
    {
        Global.StopGame();
        
        foreach (var command in commands)
        {
            await command();
        }

        await ShowLabelAndAwait("再次点击屏幕开始冒险！");

        var tween = CreateTween();
        tween.TweenProperty(this, "modulate", Modulate with { A = 0f }, 0.2f);
        await ToSignal(tween, Tween.SignalName.Finished);
        Destroy();
    }

    public override void OnCreateUi()
    {
        L_Label.Instance.Hide();
    }

    public override void OnDestroyUi()
    {
        AcidSaver.AddSetting("Game", "FinishedTutorial", true);
        AcidSaver.SaveAll();
        Global.ResumeGame();
    }

    public async Task ShowRect(Rect2 rect2, string text = "")
    {
        _drawCommands = () => DrawRect(rect2, Colors.White, false, 10f);
        QueueRedraw();
        if (text != "") ShowLabel(text);
        await AwaitPressed();
    }
    
    public void CleanDraw()
    {
        _drawCommands = null;
        QueueRedraw();
    }
    
    private async Task AwaitPressed() => await ToSignal(L_Button.Instance, BaseButton.SignalName.Pressed);

    private void ShowLabel(string text)
    {
        L_Label.Instance.Show();
        L_Label.Instance.Text = text;
    }

    public async Task ShowLabelAndAwait(string text)
    {
        ShowLabel(text);
        await AwaitPressed();
    }

    public override void _Draw()
    {
        _drawCommands?.Invoke();
    }
}
