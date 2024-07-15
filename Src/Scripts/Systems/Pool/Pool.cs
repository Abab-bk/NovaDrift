using System.Collections.Generic;
using AcidWallStudio.ObjectPool;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Pool;

public static class Pool
{
    public static Dictionary<int, NodePool<MobBase>> MobPools;
    public static NodePool<DieVfx> DieVfxPool;

    public static int GetActiveMobCount()
    {
        var count = 0;
        
        foreach (var pool in MobPools.Values)
        {
            count += pool.CountActive;
        }

        return count;
    }

    public static void Awake()
    {
        MobPools = new();

        // 初始化 MobPools
        foreach (var key in DataBuilder.Tables.TbMobInfo.DataMap.Keys)
        {
            var pool = new NodePool<MobBase>(
                () => new MobBuilder(DataBuilder.BuildMobInfoById(key)).Build(),
                mob =>
                {
                    mob.SetProcessMode(Node.ProcessModeEnum.Inherit);
                    // mob.Show();
                    mob.PoolActive();
                },
                mob =>
                {
                    mob.CallDeferred(Node.MethodName.SetProcessMode, (int)Node.ProcessModeEnum.Disabled);
                    mob.Hide();
                },
                mob =>
                {
                    mob.QueueFree();
                },
                true,
                40,
                100
            );
            
            MobPools[key] = pool;
            Global.GameWorld.AddChild(pool);
        }
        foreach (var pool in MobPools.Values)
        {
            pool.Init(mob =>
            {
                mob.Pool = pool;
            });
        }

        DieVfxPool = new NodePool<DieVfx>(
            () => GD.Load<PackedScene>("res://Scenes/Vfx/DieVfx.tscn").Instantiate<DieVfx>(),
            dieVfx =>
            {
                dieVfx.SetProcessMode(Node.ProcessModeEnum.Inherit);
                dieVfx.Show();
                dieVfx.Restart();
            },
            dieVfx =>
            {
                dieVfx.SetProcessMode(Node.ProcessModeEnum.Disabled);
                dieVfx.Hide();
            },
            dieVfx =>
            {
                dieVfx.QueueFree();
            },
            true,
            80,
            200
            );
        Global.GameWorld.AddChild(DieVfxPool);
        DieVfxPool.Init();
    }
}