using DsUi;
using Godot;

namespace NovaDrift.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
    private TextureProgressBar _expBar;
    private TextureProgressBar _hpBar;
    
    public override void OnCreateUi()
    {
        _expBar = S_ExpProgressBar.Instance;
        _hpBar = S_HpProgressBar.Instance;

        Global.OnPlayerUpLevel += i =>
        {
            OpenNestedUi(UiManager.UiName.SelectAbility);
            Global.StopGame();
        };
        Global.OnGameOver += Destroy;
    }
    
    public void UpdateExpBar(float ratio)
    {
        _expBar.SetDeferred(Range.PropertyName.Value, ratio * 100f);
    }
    
    public void UpdateHpBar(float ratio)
    {
        _hpBar.SetDeferred(Range.PropertyName.Value, ratio * 100f);
    }

    public override void OnDestroyUi()
    {
        
    }
    
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Esc"))
        {
            if (UiManager.Get_PausedMenu_Instance().Length <= 0)
            {
                return;
            }

            if (UiManager.Get_PausedMenu_Instance()[0].Visible)
            {
                UiManager.Hide_PausedMenu();
            }
            else
            {
                UiManager.Get_PausedMenu_Instance()[0].ShowUi();
            }
        }
    }
}
