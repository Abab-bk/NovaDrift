using DsUi;
using GDebugPanelGodot.Core;
using Godot;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Ui.ActionBtn;
using NovaDrift.Scripts.Ui.AnimationProgressBar;
using NovaDrift.Scripts.Ui.BuffIcon;
using NovaDrift.Scripts.Ui.PowerUpBtn;

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
		// ActionButton -> “按 R 闪现”
		if (Global.CurrentPlatform == GamePlatform.Desktop)
		{
			EventBus.AddActionButton += (prompt, action, function) =>
			{
				var node = S_ActionButtons.OpenNestedUi<ActionBtnPanel>(UiManager.UiName.ActionBtn);
				node.UpdateUi(prompt, action);
				node.Action = function;
				node.Show();
			};
		}

		EventBus.OnGameOver += Destroy;

		EventBus.OnGameStart += () =>
		{
			UiManager.Open_Slogan();
		};

		EventBus.OnPlayerGetPowerUp += power =>
		{
			S_PowerUps
				.OpenNestedUi<PowerUpBtnPanel>(UiManager.UiName.PowerUpBtn)
				.UpdateUi(power);
		};

		L_SettingBtn.Instance.Pressed += OnPressedEsc;

		_expBar = GetNode<AnimationProgressBarPanel>("%ExpProgressBar");
		_hpBar = GetNode<AnimationProgressBarPanel>("%HpProgressBar");
		_shieldBar = GetNode<AnimationProgressBarPanel>("%ShieldProgressBar");
		_shieldCooldownBar = GetNode<AnimationProgressBarPanel>("%ShieldCooldownProgressBar");
	}

	public void AddBuffIcon(Buff buff, float initValue = 0f)
	{
		// Animation
		var animationPanel = UiManager.Create_BuffIcon();
		animationPanel.SetProgressBarValue(initValue);
		animationPanel.UpdateUi(buff);
		animationPanel.ShowUi();
		animationPanel.UpdateUiWithAnimation(buff);
		
		BuffIconPanel panel = S_BuffIcons.OpenNestedUi<BuffIconPanel>(UiManager.UiName.BuffIcon);
		panel.UpdateProgressBar(initValue);
		panel.UpdateUi(buff);
	}

	public void RemoveBuffIcon(Buff buff)
	{
		foreach (var buffIcon in S_BuffIcons.Instance.GetChildren())
		{
			if (buffIcon is not BuffIconPanel buffIconPanel) continue;
			if (buffIconPanel.Buff == buff)
			{
				buffIconPanel.RemoveSelf();
			}
		}
	}

	public BuffIconPanel GetBuffIcon(Buff buff)
	{
		foreach (var buffIcon in S_BuffIcons.Instance.GetChildren())
		{
			if (buffIcon is not BuffIconPanel buffIconPanel) continue;
			if (buffIconPanel.Buff == buff) return buffIconPanel;
		}

		return null;
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
			OnPressedEsc();
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

	private void OnPressedEsc()
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
