using DsUi;
using GDebugPanelGodot.Core;
using GDebugPanelGodot.Extensions;
using Godot;
using NovaDrift.Scripts.Ui.ActionBtn;
using NovaDrift.Scripts.Ui.AnimationProgressBar;

namespace NovaDrift.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
	private AnimationProgressBarPanel _expBar;
	private AnimationProgressBarPanel _hpBar;
	private AnimationProgressBarPanel _shieldBar;
	private AnimationProgressBarPanel _shieldCooldownBar;
	
	private bool _isDebugPanelOpened;
	
	[Export] private Control _debugPanel;
	
	public override void OnCreateUi()
	{
		EventBus.OnPlayerUpLevel += _ =>
		{
			OpenNestedUi(UiManager.UiName.SelectAbility);
			Global.StopGame();
		};
		EventBus.AddActionButton += (prompt, action) =>
		{
			var node = S_ActionButtons.OpenNestedUi<ActionBtnPanel>(UiManager.UiName.ActionBtn);
			node.UpdateUi(prompt, action);
			node.Show();
			return node;
		};
		EventBus.OnGameOver += Destroy;

		_expBar = GetNode<AnimationProgressBarPanel>("%ExpProgressBar");
		_hpBar = GetNode<AnimationProgressBarPanel>("%HpProgressBar");
		_shieldBar = GetNode<AnimationProgressBarPanel>("%ShieldProgressBar");
		_shieldCooldownBar = GetNode<AnimationProgressBarPanel>("%ShieldCooldownProgressBar");
		
		GenerateDebugPanel();
	}
	
	public void UpdateShieldCooldownBar(float ratio)
	{
		_shieldCooldownBar.UpdateUi(ratio * 100f);
	}
	
	public void UpdateExpBar(float ratio)
	{
		_expBar.UpdateUi(ratio * 100f);
	}
	
	public void UpdateHpBar(float ratio)
	{
		_hpBar.UpdateUi(ratio * 100f);
	}
	
	public void UpdateShieldBar(float ratio)
	{
		_shieldBar.UpdateUi(ratio * 100f);
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
		// Player
		GDebugPanel.AddSection("Player", new PlayerCommands());

		
		// World
		var worldCommand = new WorldCommands();
		var worldSection = GDebugPanel.AddSection("World", worldCommand);

		var worldColor = WorldCommands.WorldColors.Red;
		
		worldSection.AddEnum("ColorType", val =>
		{
			worldColor = val;

			switch (worldColor)
			{
				case WorldCommands.WorldColors.Red:
					Global.SetWorldColor(Constants.Colors.Red);
					break;
				case WorldCommands.WorldColors.Blue:
					Global.SetWorldColor(Constants.Colors.Blue);
					break;
			}
		}, () => worldColor);
		
	}
}
