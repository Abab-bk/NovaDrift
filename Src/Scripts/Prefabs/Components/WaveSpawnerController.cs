using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.Pool;
using NovaDrift.Scripts.Vfx;

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
            Logger.Log($"[Wave Spawner] Next wave clock: {_waitingClock}s");
        };

        AddChild(_clock);

        EventBus.OnMobDied += _ =>
        {
            if (GetTree().GetNodesInGroup("Mobs").Count <= 0)
            {
                GenerateWave();
            }
        };

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
        if (Pool.GetActiveMobCount() >= DataBuilder.Tables.TbConstants.MaxMobCount)
        {
            Logger.Log("[Wave Spawner] Max mobs reached, stop spawn and add clock.");
            _clock.Start();
            return;
        }
        
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
        
        Logger.Log("[Wave Spawner] Play boss appear animation.");

        var animation = GD.Load<PackedScene>("res://Scenes/Vfx/BossAppearVfx.tscn").Instantiate<BossAppearVfx>();
        animation.Title = DataBuilder.Tables.TbBossMobInfo.DataMap[id].Name;

        var info = DataBuilder.Tables.TbBossMobInfo.DataMap[id];
        if (info.DragonBone != "")
        {
            animation.DragonPath = $"res://Assets/Textures/Mobs/DragonBones/{info.DragonBone}.dbfactory";
        }
        else
        {
            animation.IconPath = $"res://Assets/Textures/Mobs/{DataBuilder.Tables.TbBossMobInfo.DataMap[id].SceneName}.png";
        }
        
        UiManager.GetUiLayer(UiLayer.Pop).AddChild(animation);
        Global.StopGame();

        animation.OnAnimationEnd += () =>
        {
            Global.ResumeGame();
            
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
        };
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