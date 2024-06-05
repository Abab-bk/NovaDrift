using AcidWallStudio.AcidUtilities;
using Godot;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.BuffIcon;

public partial class BuffIconPanel : BuffIcon
{

    public void UpdateUi(Buff buff)
    {
    }

    public void UpdateUiWithAnimation(Buff buff)
    {
        GlobalPosition = new Vector2(Wizard.GetScreenCenterX(), 200f);
        
        var label = new Godot.Label();
        AddChild(label);
        label.Position = new Vector2(12, 110);
        label.Text = buff.Name;
        
        this.TweenScale(new Vector2(2f, 2f), 1.0f)
            .OnComplete(QueueFree)
            .Play();
    }
    
    public override void OnCreateUi()
    {
        L_ProgressBar.Instance.Hide();
    }

    public override void OnDestroyUi()
    {
        
    }

}
