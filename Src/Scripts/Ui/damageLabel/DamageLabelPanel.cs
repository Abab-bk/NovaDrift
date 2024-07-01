using System.Globalization;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Ui.DamageLabel;

public partial class DamageLabelPanel : DamageLabel
{
    public override void OnCreateUi()
    {
        
    }

    public void ShowValue(float value,
        Vector2 pos,
        float duration = 2f,
        float spread = Mathf.Pi / 2,
        bool critical = false)
    {
        GlobalPosition = pos;
        Scale = Vector2.Zero;
        
        L_Label.Instance.Text = value.ToString("0.", CultureInfo.InvariantCulture);
        
        GTweenSequenceBuilder.New()
            .Append(this.TweenScale(Vector2.One, 0.1f))
            .AppendTime(0.5f)
            .Append(this.TweenScale(Vector2.Zero, 0.1f))
            .AppendCallback(QueueFree)
            .Build()
            .Play();

        // if (critical)
        // {
        //     Modulate = new Color(1, 0, 0);
        //     t.TweenProperty(this, "scale", Scale * 2, duration);
        // }
        //
        // t.Finished += QueueFree;
    }

    public override void OnDestroyUi()
    {
        
    }

}
