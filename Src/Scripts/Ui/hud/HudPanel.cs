using DsUi;
using Godot;

namespace NovaDrift.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
    private ProgressBar _expBar;
    private ProgressBar _hpBar;
    
    public override void OnCreateUi()
    {
        _expBar = S_ExpProgressBar.Instance;
        _hpBar = S_HpProgressBar.Instance;

        Global.OnPlayerUpLevel += i =>
        {
            OpenNestedUi(UiManager.UiName.SelectAbility);
            Global.StopGame();
        };
    }
    
    public void UpdateExpBar(float ratio)
    {
        _expBar.Value = ratio * 100f;
    }
    
    public void UpdateHpBar(float ratio)
    {
        _hpBar.Value = ratio * 100f;
    }

    public override void OnDestroyUi()
    {
        
    }
}
