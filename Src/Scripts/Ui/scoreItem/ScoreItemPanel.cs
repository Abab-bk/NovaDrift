using Godot;
using GTweens.Easings;
using GTweens.Extensions;
using GTweens.Tweens;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.ScoreItem;

public partial class ScoreItemPanel : ScoreItem
{
    private string _text;
    
    private int _targetScore;
    private int _currentScore;
    
    private GTween _tween;

    public void SetContext(string text, int score)
    {
        _text = text;
        _targetScore = score;
        
        S_TextLabel.Instance.Text = _text;
        S_ScoreLabel.Instance.Text = _currentScore.ToString();
    }

    public void PlayAnimation()
    {
        _tween = GTweenExtensions.Tween(
            () => _currentScore,
            score =>
            {
                _currentScore = score;
                S_ScoreLabel.Instance.Text = _currentScore.ToString();
            },
            _targetScore,
            2f
            );
        _tween
            .SetEasing(Easing.OutCubic)
            .Play();
    }

    private void Skip()
    {
        _tween.Kill();
        S_ScoreLabel.Instance.Text = _targetScore.ToString();
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("Click"))
        {
            Skip();
        }
    }

    public override void OnDestroyUi()
    {
        
    }

}
