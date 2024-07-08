using Godot;

namespace NovaDrift.Scripts.Ui.ScoreItem;

public partial class ScoreItemPanel : ScoreItem
{
    public string Text;
    public int Score;

    public override void OnCreateUi()
    {
        SetProcess(false);
        S_TextLabel.Instance.Text = Text;
        S_ScoreLabel.Instance.Text = "0";
    }

    public void PlayAnimation()
    {
        SetProcess(true);
    }

    public override void Process(float delta)
    {
        var currentValue = int.Parse(S_ScoreLabel.Instance.Text);
        if (currentValue > Score) return;
        
        currentValue++;
        S_ScoreLabel.Instance.Text = currentValue.ToString();
    }

    public void Skip()
    {
        SetProcess(false);
        S_ScoreLabel.Instance.Text = Score.ToString();
    }

    public override void OnDestroyUi()
    {
        
    }

}
