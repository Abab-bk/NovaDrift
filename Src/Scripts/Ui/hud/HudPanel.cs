using DsUi;
using GDebugPanelGodot.Core;
using GDebugPanelGodot.DebugActions.Containers;
using Godot;

namespace NovaDrift.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
    private TextureProgressBar _expBar;
    private TextureProgressBar _hpBar;
    
    private bool _isDebugPanelOpened = false;

    [Export] private Control _debugPanel;
    
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
        
        GenerateDebugPanel();
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
        if (@event.IsActionPressed("OpenConsole"))
        {
            _isDebugPanelOpened = !_isDebugPanelOpened;

            if (_isDebugPanelOpened)
            {
                Global.StopGame();
                GDebugPanel.Show(_debugPanel); return;
            }
            Global.ResumeGame();
            GDebugPanel.Hide();
        }
    }

    private void GenerateDebugPanel()
    {
        GDebugPanel.AddSection("Player", new PlayerCommands());
        GDebugPanel.AddSection("World", new WorldCommands());
    }
}
