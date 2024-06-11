using DsUi;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts;

public static class UiBaseExtension
{
    public static void ChangeTo(this UiBase source, UiBase to)
    {
        to.Modulate = to.Modulate with { A = 0f };
        to.ShowUi();
        
        GTweenSequenceBuilder.New()
            .Append(source.TweenModulateAlpha(0f, 0.2f))
            .Append(to.TweenModulateAlpha(1f, 0.2f))
            .AppendCallback(source.HideUi)
            .Build()
            .Play();
    }
}