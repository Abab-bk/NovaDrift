using AcidWallStudio.AcidUtilities;
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

	public void StartTutorial(Vector2 knobPos, Vector2 shootPos)
	{
		if (!AcidSaver.HasSetting("Game", "FinishedTutorial") 
		    || (bool)AcidSaver.GetSetting("Game", "FinishedTutorial") == false)
		{
			Global.StopGame();
			UiManager.Open_Popup()
				.SetConfig(
					"新手教程",
					"你看起来是第一次玩《双子座的最后一口气》，要查看教程吗？",
					true,
					() =>
					{
						AcidSaver.AddSetting("Game", "FinishedTutorial", true);
						AcidSaver.SaveAll();
						Global.ResumeGame();
					},
					() =>
					{
						Global.ResumeGame();
						var panel = UiManager.Open_Tutorial();
						panel.Launch([
							() => panel.ShowRect(
								new Rect2(S_ExpProgressBar.Instance.GlobalPosition, S_ExpProgressBar.Instance.Size),
								"这个表示你的经验，当然现在你看不到，因为你还没有经验"),
							() =>
							{
								panel.CleanDraw();
								return panel.ShowLabelAndAwait("""
								                               当经验值足够时，会升级，你每升 1 级，就会获得一次选择能力的机会
								                               但同时，你所面对的敌人也会更加强大，请务必小心！
								                               """);
							},
							() => panel.ShowRect(
								new Rect2(S_HpProgressBar.Instance.GlobalPosition, S_HpProgressBar.Instance.Size), 
								"这个表示你的血量"),
							() => panel.ShowRect(
								new Rect2(S_ShieldProgressBar.Instance.GlobalPosition, S_ShieldProgressBar.Instance.Size), 
								"这个表示你的护盾"),
							() => panel.ShowRect(
								new Rect2(S_ShieldCooldownProgressBar.Instance.GlobalPosition, S_ShieldCooldownProgressBar.Instance.Size), 
								"这个表示你的护盾充能"),
							() => panel.ShowCircle(knobPos, 240f, "你可以使用这个移动"),
							() => panel.ShowCircle(shootPos, 150f, "你可以使用这个射击"),
							() =>
							{
								panel.CleanDraw();
								return panel.ShowLabelAndAwait("怪物会源源不断地出现，你必须努力活下去！");
							},
							() => panel.ShowLabelAndAwait("再次点击屏幕开始冒险！")
						]);
					}
				);
		}
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
