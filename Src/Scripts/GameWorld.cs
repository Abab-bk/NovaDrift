using AcidJoystick;
using AcidWallStudio.Fmod;
using DsUi;
using DwarfImpulse;
using Godot;
using NovaDrift.addons.AcidUtilities;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts;

public partial class GameWorld : Node2D
{
	[Export] ShakeDirector2D _shakeDirector;
	[Export] FastNoiseLite _noise;
	
	private Joystick _moveJoystick;
	private Joystick _aimJoystick;
	
	public override void _Ready()
	{
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
		SoundManager.Initialize();

		Global.SceneTree = GetTree();
		Global.ShakeDirector = _shakeDirector;
		Global.Noise = _noise;
		
		SoundManager.PlayMusic(AudioEvents.BackgroundMusic);
		
		GetNode<Joystick>("%MoveJoystick").Hide();
		GetNode<Joystick>("%AimJoystick").Hide();
		
		EventBus.OnGameInit += Init;
		EventBus.OnGameOver += GameOver;
		
		Global.Init();
		AcidSaver.LoadAll();
		
		if (Global.CurrentPlatform != GamePlatform.Desktop)
		{
			EventBus.OnGameInit?.Invoke();
			return;
		}
		
		if (OS.GetEnvironment("ShowStartMenu") == "true")
		{
			UiManager.Open_StartMenu();
			return;
		}
		
		EventBus.OnGameInit?.Invoke();
	}

	public override void _Notification(int what)
	{
		if (what == NotificationExitTree)
		{
			AudioServer.Unlock();
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
		
		_moveJoystick = GetNode<Joystick>("%MoveJoystick");
		_aimJoystick = GetNode<Joystick>("%AimJoystick");
		
		_moveJoystick.Visible = Global.CurrentPlatform != GamePlatform.Desktop;
		_aimJoystick.Visible = Global.CurrentPlatform != GamePlatform.Desktop;
		
		UiManager.Open_Hud();
		
		Global.GameWorld = this;
		
		Player player = GD.Load<PackedScene>("res://Scenes/Prefabs/Actors/Player.tscn").Instantiate<Player>();
		player.JoystickNode = _moveJoystick;
		AddChild(player);

		MoveActorToScreenCenter mover = new MoveActorToScreenCenter(player);
		AddChild(mover);
		
		// UiManager.Get_Hud_Instance()[0].OpenNestedUi(UiManager.UiName.StatsMonitor);
		
		UiManager.Open_PausedMenu();
		UiManager.Hide_PausedMenu();
		
		EventBus.OnGameStart?.Invoke();
		
		Global.SetWorldColor(Constants.Colors.Red);
	}

	private async void GameOver()
	{
		GetTree().CallGroup("Mobs", Node.MethodName.QueueFree);
		
		UiManager.Destroy_Hud();
		UiManager.Destroy_PausedMenu();
		
		Global.Player.CallDeferred(Node.MethodName.QueueFree);
		UiManager.Open_GameOver();
	}
}
