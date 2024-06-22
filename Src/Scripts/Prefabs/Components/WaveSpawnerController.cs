using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
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

    private int _sawBossCount = 1;
    private int[] _bossIds;
    private bool _nextIsBoss;

    private int GetCurrentBossId()
    {
        return _bossIds[(_sawBossCount - 1) % _bossIds.Length];
    }

    public override void _Ready()
    {
        _bossIds = DataBuilder.Tables.TbBossMobInfo.DataMap.Keys.ToArray();
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
                GenerateBossWave(GetCurrentBossId());
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
            _clock.Stop();
            _waitingClock = 5f;
            _clock.WaitTime = _waitingClock;
            _nextIsBoss = false;
            _sawBossCount = 1;
        };
    }

    public void GenerateWave()
    {
        if (GetTree().GetNodesInGroup("Mobs").Count >= 20) return;
        var waveSpawner = new WaveSpawner();
        waveSpawner.Cost = GetCost();
        AddChild(waveSpawner);
        waveSpawner.GenerateWave();
        AddWaveCount();
    }

    public void GenerateWaveWithoutWaveCountAndWithPos(Vector2 pos)
    {
        var waveSpawner = new WaveSpawner();
        waveSpawner.Cost = GetCost();
        AddChild(waveSpawner);
        waveSpawner.GenerateWave();
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
            if (!_enabled) return;
            _sawBossCount += 1;
            _nextIsBoss = false; 
            _clock.Start();
            Logger.Log("[Wave Spawner] Boss wave end, start clock.");
        };
        
        waveSpawner.QueueFree();
        
        Logger.Log($"[Wave Spawner] Boss wave spawned: {boss.MobInfo.Name}");
    }

    private void AddWaveCount()
    {
        if (!_enabled) return;

        Logger.Log("[Wave Spawner] Add wave count.");
        _waveCount += 1;

        // 每 20 关为一个 Boss 关
        if (_waveCount == _sawBossCount * 20)
        {
            Logger.Log("[Wave Spawner] Next wave is boss wave.");
            _nextIsBoss = true;
        }
        
        _clock.Start();
    }

    public MobBase GenerateAMob(int id, Vector2 pos = default)
    {
        var mob = new MobBuilder(DataBuilder.BuildMobInfoById(id)).Build();
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, mob);
        // Global.GameWorld.AddChild(mob);
        mob.GlobalPosition = pos == default ? Wizard.GetScreenCenter() : pos;
        return mob;
    }
    
    public MobBase GenerateAMob(MobInfo mobInfo, Vector2 pos = default)
    {
        var mob = new MobBuilder(mobInfo).Build();
        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, mob);
        // Global.GameWorld.AddChild(mob);
        mob.GlobalPosition = pos == default ? Wizard.GetScreenCenter() : pos;
        return mob;
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