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
}

public enum GamePlatform
{
    Desktop,
    Mobile,
}

public static class Global
{
    public static readonly GamePlatform CurrentPlatform = GamePlatform.Desktop;
    
    public static Player Player;
    public static Node2D PlayerStand;
    public static GameWorld GameWorld;
    public static ShakeDirector2D ShakeDirector;
    public static FastNoiseLite Noise;

    public static Constants.WorldColor WorldColor = Constants.Colors.Blue;
    
    public static HazardSpawner HazardSpawner;

    private static int _stopCount;

    public static SceneTree SceneTree
    {
        get => _sceneTree;
        set
        {
            _sceneTree = value;
            _sceneTree.NodeAdded += ConnectButtonSoundsSignal;
        }
    }

    private static SceneTree _sceneTree;

    public static void ConnectButtonSoundsSignal(Node node)
    {
        if (node is not BaseButton button) return;
        button.Pressed += () =>
        {
            SoundManager.PlayOneShotById("event:/ButtonClicked");
        };
    }

    public static void Init()
    {
    }

    public static void SetWorldColor(Constants.WorldColor color)
    {
        WorldColor = color;
        EventBus.OnWorldColorChanged();
    }

    public static void StopGame()
    {
        _stopCount++;
        GameWorld.GetTree().Paused = _stopCount > 0;
    }

    public static void ResumeGame()
    {
        _stopCount--;
        GameWorld.GetTree().Paused = _stopCount > 0;
    }

    public static int GetPlayerLevel()
    {
        if (Player == null) return 1;
        return Player.Stats.Level;
    }
}