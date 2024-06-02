using Godot;
using GTweens.Builders;
using GTweens.Extensions;
using GTweensGodot.Extensions;

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
        GTweenSequenceBuilder.New()
            .Append(GTweenExtensions.Tween(
                () => (float)_easedBar.Value,
                v => _easedBar.Value = v,
                value,
                0.3f
            ))
            .Build()
            .Play();
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
