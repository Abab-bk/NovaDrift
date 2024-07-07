using Godot;

namespace NovaDrift.Scripts.Ui.Tip;

public partial class TipPanel : Tip
{
    public string Text
    {
        set => UpdateLabel(value);
    }

    public override void _Ready()
    {
        L_Timer.Instance.Timeout += QueueFree;
    }

    private void UpdateLabel(string text)
    {
        S_Label.Instance.Text = text;
    }

    public override void OnCreateUi()
    {
    }

    public override void OnDestroyUi()
    {
        
    }

}
