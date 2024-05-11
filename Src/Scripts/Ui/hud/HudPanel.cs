using System;
using DsUi;
using GDebugPanelGodot.Core;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;
using Godot;
using Range = Godot.Range;

namespace NovaDrift.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
	private TextureProgressBar _expBar;
	private TextureProgressBar _hpBar;
	private TextureProgressBar _shieldBar;
	
	private bool _isDebugPanelOpened = false;

	[Export] private Control _debugPanel;
	
	public override void OnCreateUi()
	{
		_expBar = S_ExpProgressBar.Instance;
		_hpBar = S_HpProgressBar.Instance;
		_shieldBar = S_ShieldProgressBar.Instance;

		EventBus.OnPlayerUpLevel += i =>
		{
			OpenNestedUi(UiManager.UiName.SelectAbility);
			Global.StopGame();
		};
		EventBus.OnGameOver += Destroy;
		
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
	
	public void UpdateShieldBar(float ratio)
	{
		_shieldBar.SetDeferred(Range.PropertyName.Value, ratio * 100f);
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
