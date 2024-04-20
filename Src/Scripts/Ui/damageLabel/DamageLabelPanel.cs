using System.Globalization;
using Godot;

namespace NovaDrift.Scripts.Ui.DamageLabel;

public partial class DamageLabelPanel : DamageLabel
{
    public override void OnCreateUi()
    {
        
    }

    public void ShowValue(float value,
        Vector2 pos,
        Vector2 travel = default,
        float duration = 2f,
        float spread = Mathf.Pi / 2,
        bool critical = false)
    {
        GlobalPosition = pos;

        travel = new Vector2(0, -80);
        
        L_Label.Instance.Text = value.ToString(CultureInfo.CurrentCulture);
        Vector2 movement = travel.Rotated((float)GD.RandRange( (double)-spread / 2f, (double)spread / 2f));
        
        Tween t = CreateTween();
        t.TweenProperty(this, "global_position", GlobalPosition + movement, duration);
        t.TweenProperty(this, "modulate:a", 0.0, duration);

        if (critical)
        {
            Modulate = new Color(1, 0, 0);
            t.TweenProperty(this, "scale", Scale * 2, duration);
        }
        
        t.Finished += QueueFree;
    }

    public override void OnDestroyUi()
    {
        
    }

}
