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

    private int _waveCount;
    
    private float _waitingClock;
    private Timer _clock;

    private bool _nextIsBoss;
    private int _currentBossId = 1001;
    
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
            _waitingClock = Mathf.Min(Global.Player.Stats.Level * 2f, 20f); // Need more cal, maybe based on the score per min ratio ?
            _clock.WaitTime = _waitingClock;
            
            if (_nextIsBoss)
            {
                GenerateBossWave(_currentBossId);
            }
            else
            {
                GenerateWave();
            }
            
            OnNextClockChanged?.Invoke(_waitingClock);
            Logger.Log($"[WaveSpawner] Next wave clock: {_waitingClock}s");
        };

        AddChild(_clock);

        EventBus.OnGameStart += () =>
        {
            if (!_enabled) return;
            _clock.Start();
        };
        EventBus.OnGameOver += () =>
        {
            _waitingClock = 5f;
            _clock.WaitTime = _waitingClock;
            _nextIsBoss = false;
            _currentBossId = 1001;
            _clock.Stop();
        };
    }

    public void GenerateWave()
    {
        var waveSpawner = new WaveSpawner();
        waveSpawner.Cost = GetCost();
        AddChild(waveSpawner);
        waveSpawner.GenerateWave();
        AddWaveCount();
    }

    public void GenerateBossWave(int id)
    {
        _clock.Stop();
        Logger.Log("[Wave Spawner] Boss wave started, stop clock.");
        
        var waveSpawner = new WaveSpawner();
        
        AddChild(waveSpawner);
        
        var boss = waveSpawner.GenerateABoss(id);
        boss.OnDied += () =>
        {
            _currentBossId += 1;
            _nextIsBoss = false; 
            _clock.Start();
            Logger.Log("[Wave Spawner] Boss wave end, start clock.");
        };
        
        Logger.Log($"[Wave Spawner] Boss wave spawned: {boss.MobInfo.Name}");
    }

    private void AddWaveCount()
    {
        _waveCount += 1;
        
        switch (_waveCount)
        {
            case 2:
                Logger.Log("[Wave Spawner] Next wave is boss wave.");
                _nextIsBoss = true;
                break;
            case 40:
                _nextIsBoss = true;
                break;
        }
        
        _clock.Start();
    }

    public void GenerateAMob(int id)
    {
        var mob = new MobBuilder(DataBuilder.BuildMobInfoById(id)).Build();
        Global.GameWorld.AddChild(mob);
        mob.GlobalPosition = Wizard.GetScreenCenter();
    }
    
    public void GenerateABoss(int id)
    {
        var mob = new MobBuilder(DataBuilder.BuildBossMobInfoById(id)).Build();
        Global.GameWorld.AddChild(mob);
        mob.GlobalPosition = Wizard.GetScreenCenter();
    }

    private int GetCost()
    {
        // 玩家等级 * 10
        return Global.Player.Stats.Level * 5;
    }
}