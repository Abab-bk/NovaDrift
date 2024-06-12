using Godot;

namespace NovaDrift.Scripts.Ui.ScoreLabel;

public partial class ScoreLabelPanel : ScoreLabel
{
    public void SetContent(string title, string number)
    {
        S_TextLabel.Instance.Text = title;
        S_NumberLabel.Instance.Text = number;
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
