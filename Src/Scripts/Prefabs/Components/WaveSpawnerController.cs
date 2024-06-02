using System;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class WaveSpawnerController : Node2D
{
    public event Action<float> OnNextClockChanged;
    
    [Export] bool _enabled;
    
    private float _waitingClock;
    private Timer _clock;
    
    public override void _Ready()
    {
        Global.WaveSpawnerController = this;
        
        _clock = new Timer
        {
            WaitTime = 5f,
            OneShot = true,
        };
        
        _clock.Timeout += () =>
        {
            GenerateWave();
            _waitingClock = GetCost() * 2f; // Need more cal, maybe based on the score per min ratio ?
            _clock.WaitTime = _waitingClock;
            _clock.Start();
            OnNextClockChanged?.Invoke(_waitingClock);
            Logger.Log("Next wave: " + _waitingClock);
        };

        AddChild(_clock);

        EventBus.OnGameStart += () =>
        {
            if (!_enabled) return;
            _clock.Start();
        };
    }

    public void GenerateWave()
    {
        var waveSpawner = new WaveSpawner();
        waveSpawner.Cost = GetCost();
        AddChild(waveSpawner);
        waveSpawner.GenerateWave();
    }

    public void GenerateAMob(int id)
    {
        var mob = new MobBuilder(DataBuilder.BuildMobInfoById(id)).Build();
        Global.GameWorld.AddChild(mob);
        mob.GlobalPosition = Wizard.GetScreenCenter();
    }

    private int GetCost()
    {
        // 玩家等级 * 10
        return Global.Player.Stats.Level * 5;
    }
}