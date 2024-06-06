using AcidWallStudio.AcidUtilities;
using Godot;
using GTweens.Builders;
using GTweens.Extensions;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.BuffIcon;

public partial class BuffIconPanel : BuffIcon
{
    public Buff Buff;

    public void UpdateUi(Buff buff)
    {
        Buff = buff;
        L_Icon.Instance.Texture = GD.Load<Texture2D>(buff.IconPath);
    }

    public void UpdateProgressBar(float value)
    {
        UpdateProgress(value);
    }

    public void RemoveSelf(float value = 0f)
    {
        var instance = L_ProgressBar.Instance;
        GTweenSequenceBuilder.New()
            .Append(GTweenExtensions.Tween(
                () => (float)instance.Value,
                x => instance.Value = x,
                value,
                0.5f
            ))
            .Append(instance.TweenModulateAlpha(0f, 0.5f))
            .AppendCallback(QueueFree)
            .Build()
            .Play();
    }

    public void UpdateUiWithAnimation(Buff buff, float value = 0f, float initValue = 0f)
    {
        Modulate = new Color("ffffff00");
        L_ProgressBar.Instance.Value = initValue;
        Scale = new Vector2(2f, 2f);
        
        Buff = buff;
        GlobalPosition = new Vector2(Wizard.GetScreenCenterX() - 200f, 200f);
        
        var label = new Label();
        AddChild(label);
        label.Position = new Vector2(12, 110);
        label.Text = buff.Name;
        
        if (value > 0f)
        {
            this.TweenModulateAlpha(1f, 0.5f)
                .OnComplete(() => RemoveSelf(value))
                .Play();
            return;
        }

        GTweenSequenceBuilder.New()
            .Append(this.TweenModulateAlpha(1f, 0.5f))
            .AppendTime(2f)
            .Append(this.TweenModulateAlpha(0f, 0.5f))
            .AppendCallback(QueueFree)
            .Build()
            .Play();
    }

    private void UpdateProgress(float value)
    {
        var instance = L_ProgressBar.Instance;
        var animation = GTweenExtensions.Tween(
            () => (float)instance.Value,
            x => instance.Value = x,
            value,
            0.5f
        );
        animation.Play();
        // return animation.AwaitCompleteOrKill(new CancellationToken());
    }
    
    public void SetProgressBarValue(float value)
    {
        L_ProgressBar.Instance.Value = value;
    }

    public override void OnCreateUi()
    {
        L_ProgressBar.Instance.Value = 0f;
    }

    public override void OnDestroyUi()
    {
        
    }

}
