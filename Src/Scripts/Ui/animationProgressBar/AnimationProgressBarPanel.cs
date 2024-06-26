using Godot;

namespace NovaDrift.Scripts.Ui.AnimationProgressBar;

[NoAutoGetNodes]
public partial class AnimationProgressBarPanel : AnimationProgressBar
{
    [Export] private Texture2D _progressTexture;
    [GetNode("%Bar")] private TextureProgressBar _bar;
    [GetNode("%EasedBar")] private TextureProgressBar _easedBar;

    public override void _Ready()
    {
        base._Ready();
        GetNodes();
        _bar.TextureProgress = _progressTexture;
        _easedBar.TextureProgress = _progressTexture;
    }

    public void UpdateUi(float value)
    {
        if (_bar == null) return;
        _bar.Value = value;

        var tween = CreateTween();
        tween.TweenProperty(_easedBar, "value", value, 0.1f);
        tween.Play();
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
