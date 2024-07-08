using System;
using AcidWallStudio.Fmod;
using DwarfImpulse;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts;

public enum Layer
{
    None = 0,
    Player = 1,
    Mob = 2,
    PlayerHitBox = 3,
    PlayerHurtBox = 4,
    MobHitBox = 5,
    MobHurtBox = 6,
    Object = 7,
    PlayerBullet = 8,
    MobBullet = 9,
}

public enum GamePlatform
{
    Desktop,
    Mobile,
}

public enum InputDevice
{
    Keyboard,
    Joystick,
    VirtualJoystick,
}

public class GameContext
{
    public int Score;
    public bool IsGameOver;
    public int ReliveCount;
    private Node2D _camera;

    public enum FollowMode
    {
        None,
        Glued,
        Simple,
        Group,
        Path,
        Framed,
    }
    
    public void SetCamera(Node2D camera)
    {
        _camera = camera;
    }

    public void AppendFollowTarget(Node2D target)
    {
        if (_camera == null) return;
        _camera.Call("append_follow_targets", target);
    }

    public void RemoveFollowTarget(Node2D target)
    {
        if (_camera == null) return;
        _camera.Call("erase_follow_targets", target);
    }

    public void SetFollowMode(FollowMode followMode)
    {
        if (_camera == null) return;
        _camera.Set("follow_mode", (int)followMode);
    }

    public void SetZoom(Vector2 zoom)
    {
        if (_camera == null) return;
        var tween = _camera.CreateTween();
        tween.TweenProperty(_camera, "zoom", zoom, 0.5f).SetEase(Tween.EaseType.OutIn);
        // _camera.Call("set_zoom", zoom);
    }

    public void SetFollowTarget(Node2D target)
    {
        if (_camera == null) return;
        _camera.Call("set_follow_target", target);
    }
    
    public void SetLimits(float left, float right, float top, float bottom)
    {
        if (_camera == null) return;
        _camera.Call("set_limit_top", top);
        _camera.Call("set_limit_bottom", bottom);
        _camera.Call("set_limit_left", left);
        _camera.Call("set_limit_right", right);
    }

    public void PrintLimits()
    {
        if (_camera == null) return;
        Logger.Log($"""
                    [Camera Limits]:
                    Top: {_camera.Call("get_limit_top")}
                    Bottom: {_camera.Call("get_limit_bottom")}
                    Left: {_camera.Call("get_limit_left")}
                    Right: {_camera.Call("get_limit_right")}
                    """);
    }

    public GameContext()
    {
        EventBus.OnMobDied += @base =>
        {
            var info = @base.MobInfo;
            AddScore((int)(info.DangerFactor * info.Health));
        };
        EventBus.OnGameOver += () =>
        {
            IsGameOver = true;
        };
        EventBus.OnGameStart += Clear;
    }

    private void Clear()
    {
        Score = 0;
        ReliveCount = 0;
        IsGameOver = false;
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }
}

public static class Global
{
    // FIXME: 护盾半径好像无效
    // FIXME: 射击距离越远伤害越高的ability太强了
    
    public static event Action OnAcidCoinsChanged;
    
    public static event Action OnGamePaused;
    public static event Action OnGameResumed;
    
    public static GamePlatform CurrentPlatform = GamePlatform.Desktop;
    public static InputDevice CurrentInputDevice = InputDevice.Keyboard;
    
    public static Player Player;
    public static Node2D Something;
    public static GameWorld GameWorld;
    public static ShakeDirector2D ShakeDirector;
    public static FastNoiseLite Noise;
    public static WaveSpawnerController WaveSpawnerController;
    public static WorldEnvironment WorldEnvironment;
    public static readonly GameContext GameContext = new GameContext();

    public static int AcidCoins
    {
        get => _acidCoins;
        set
        {
            _acidCoins = value;
            OnAcidCoinsChanged?.Invoke();
        }
    }

    private static int _acidCoins;

    public static Constants.WorldColor WorldColor = Constants.Colors.Blue;
    
    public static HazardSpawner HazardSpawner;

    private static int _stopCount;

    public static SceneTree SceneTree
    {
        get => _sceneTree;
        set
        {
            _sceneTree = value;
            _sceneTree.NodeAdded += node =>
            {
                switch (node)
                {
                    case BaseButton button:
                        ConnectButtonSoundsSignal(button);
                        break;
                    case MobBase mobBase:
                        EventBus.EnteredMob(mobBase);
                        break;
                }
            };
        }
    }

    private static SceneTree _sceneTree;

    private static void ConnectButtonSoundsSignal(BaseButton button)
    {
        button.Pressed += () =>
        {
            SoundManager.PlayOneShotById("event:/ButtonClicked");
        };
    }

    public static void Shake(float strength, float duration = 0.5f)
    {
        ShakeDirector.Shake(
            NoiseShake.CreateWithNoise(Noise)
                .WithDuration(0.5f)
                .WithEulersAmount(new Vector3(strength, strength, 0.02f))
        );
    }

    public static void SetWorldColor(Constants.WorldColor color)
    {
        WorldColor = color;
        EventBus.OnWorldColorChanged();
    }

    public static void SetWorldCorrection(GradientTexture2D color)
    {
        WorldEnvironment.Environment.AdjustmentColorCorrection = color;
    }

    public static void CleanWorldCorrection()
    {
        WorldEnvironment.Environment.AdjustmentColorCorrection = null;
    }

    public static void StopGame()
    {
        _stopCount++;
        if (_stopCount > 0) OnGamePaused?.Invoke();
        GameWorld.GetTree().Paused = _stopCount > 0;
        Logger.Log($"[Global] Try Stop game. Stop count: {_stopCount}");
    }

    public static void ResumeGame()
    {
        _stopCount--;
        if (_stopCount <= 0) OnGameResumed?.Invoke();
        GameWorld.GetTree().Paused = _stopCount > 0;
        Logger.Log($"[Global] Try Resume game. Stop count: {_stopCount}");
    }

    public static int GetPlayerLevel()
    {
        if (Player == null) return 1;
        return Player.Stats.Level;
    }

    public static bool IsDebugMode()
    {
        if (OS.GetEnvironment("DebugMode") == "false" || OS.GetEnvironment("DebugMode") == "")
        {
            return false;
        }

        return true;
    }
}