using System.Linq;
using AcidJoystick;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using DsUi;
using DwarfImpulse;
using Godot;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems.Pool;
using Saveable;

namespace NovaDrift.Scripts;

public partial class GameWorld : Node2D
{
	[Export] private ShakeDirector2D _shakeDirector;
	[Export] private FastNoiseLite _noise;
	[Export] private Node2D _background;
	[Export] private CanvasLayer _hud;

	[GetNode("%ShootBtn")] private TouchScreenButton _shootBtn;
	
	private JoyKnob _moveJoystick;
	private JoyKnob _aimJoystick;
	
	// GameStart 时 Init，不要删除
	private GameCommands _gameCommands;
	
	public override void _Ready()
	{
		SoundManager.Initialize();
		
		_gameCommands = new GameCommands();
		
		AcidSaver.OnLoaded += () =>
		{
			SoundManager.MusicVolume = AcidSaver.HasSetting("Audios", "MusicVolume")
				? (float)AcidSaver.GetSetting("Audios", "MusicVolume")
				: 1f;
			SoundManager.SfxVolume = AcidSaver.HasSetting("Audios", "SoundVolume")
				? (float)AcidSaver.GetSetting("Audios", "SoundVolume")
				: 1f;
			SoundManager.UiSoundsVolume = AcidSaver.HasSetting("Audios", "Ui")
				? (float)AcidSaver.GetSetting("Audios", "Ui")
				: 1f;
			SoundManager.SetVolume();
		};

		AcidSaver.LoadAll();
		AudioServer.Lock();

		Global.SetPockAd(GetNode("/root/PockAD"));
		Global.GameWorld = this;
		Global.SceneTree = GetTree();
		Global.ShakeDirector = _shakeDirector;
		Global.Noise = _noise;
		Global.WorldEnvironment = GetNode<WorldEnvironment>("%WorldEnvironment");
		
		SoundManager.PlayMusic("event:/BackgroundMusic");
		
		_hud.Hide();
		
		EventBus.OnGameInit += Init;
		EventBus.OnGameOver += GameOver;
		EventBus.OnGameStart += GameStart;
		
		// Global.GameContext.SetCamera(GetNode<Node2D>("PhantomCamera2D"));
		
		AcidSaver.LoadAll();
		SaveSystem.LoadFile(Constants.SavePath, GetTree().Root, FileAccess.CompressionMode.Fastlz);

		Global.Something = GetNode<Node2D>("Something");
		
		Pool.Awake();
		
		if (!Global.IsDebugMode() || OS.HasFeature("template"))
		{
			Logger.Log("[Game] No debug mode or has export template, open start menu.");
			HideBackground();
			UiManager.Open_StartMenu();
			return;
		}
		
		Logger.Log("[Game] Debug mode, enter world.");
		EventBus.OnGameInit?.Invoke();
	}

	private void GameStart()
	{
	}

	private void ShowBackground()
	{
		_background.TweenModulateAlpha(1f, 0.2f).Play();
	}

	private void HideBackground()
	{
		_background.TweenModulateAlpha(0f, 0.2f).Play();
	}

	public override void _Notification(int what)
	{
		switch (what)
		{
			case (int)NotificationExitTree:
				SoundManager.Shutdown();
				AudioServer.Unlock();
				break;
			case (int)NotificationApplicationPaused:
				SoundManager.MixerSuspend();
				break;
			case (int)NotificationApplicationResumed:
				SoundManager.MixerResume();
				break;
		}
	}

	public override void _Process(double delta)
	{
		SoundManager.Update();
	}

	// 顺序是：GameInit => GameStart => GameOver
	private void Init()
	{
		// 更新能力池
		DataBuilder.BuildAbilityIdPool();
		
		_moveJoystick = GetNode<JoyKnob>("%MoveJoystick");
		_aimJoystick = GetNode<JoyKnob>("%AimJoystick");
		
		_moveJoystick.Visible = Global.CurrentPlatform != GamePlatform.Desktop;
		_aimJoystick.Visible = Global.CurrentPlatform != GamePlatform.Desktop;
		_shootBtn.Visible = Global.CurrentPlatform != GamePlatform.Desktop;
		GetNode<Sprite2D>("%JoyBackground").Visible = Global.CurrentPlatform != GamePlatform.Desktop;
		
		UiManager.Open_Hud();
		_hud.Show();
		
		Player player = GD.Load<PackedScene>("res://Scenes/Prefabs/Actors/Player.tscn").Instantiate<Player>();
		player.JoystickNode = _moveJoystick;
		player.GlobalPosition = SpawnPoint.GetPoint(Constants.Points.Center);
		AddChild(player);
		
		// Global.GameContext.SetFollowMode(GameContext.FollowMode.Group);
		// Global.GameContext.AppendFollowTarget(player);
		// Global.GameContext.SetZoom(new Vector2(0.7f, 0.7f));
		
		UiManager.Open_PausedMenu();
		UiManager.Hide_PausedMenu();
		
		ShowBackground();
		
		EventBus.OnGameStart?.Invoke();
	}
	
	public void StartTutorial()
	{
		UiManager.Get_Hud_Instance().First()?.StartTutorial(_moveJoystick.GlobalPosition, _shootBtn.GlobalPosition);
	}

	private async void GameOver()
	{
		if (Global.GameContext.IsGameOver) return;
		Global.GameContext.IsGameOver = true;
		Logger.Log("[GameWorld] Game over.");
        HideBackground();
        _hud.Hide();
        
        GetTree().CallGroup("Mobs", "RemoveSelf");
        GetTree().CallGroup("ExpBalls", "Release");

		await ToSignal(GetTree(), SceneTree.SignalName.PhysicsFrame);
		
		UiManager.Destroy_Hud();
		UiManager.Destroy_PausedMenu();
		
		// Global.GameContext.RemoveFollowTarget(Global.Player);
		// Global.GameContext.SetZoom(new Vector2(0.4f, 0.4f));
		// Global.GameContext.SetFollowMode(GameContext.FollowMode.None);
		
		Global.Player.RemoveSelf();
		
		Global.CleanWorldCorrection();
		
		UiManager.Open_GameOver();
	}
}
