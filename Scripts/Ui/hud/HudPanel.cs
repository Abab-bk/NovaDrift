using Godot;

namespace NovaDrift.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
    private ProgressBar _expBar;
    
    public override void OnCreateUi()
    {
        _expBar = L_ExpProgressBar.Instance;
    }
    
    public void UpdateExpBar(float ratio)
    {
        _expBar.Value = ratio * 100f;
    }

    public override void OnDestroyUi()
    {
        
    }
}
