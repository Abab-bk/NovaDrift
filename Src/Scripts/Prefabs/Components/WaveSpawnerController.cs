using System;
using Godot;

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
            _waitingClock = GetCost() * 5f;
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

    private int GetCost()
    {
        // 玩家等级 * 10
        return Global.Player.Stats.Level * 5;
    }
}