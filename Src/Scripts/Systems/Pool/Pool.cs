using System.Collections.Generic;
using AcidWallStudio.ObjectPool.Classes;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Systems.Pool;

public static class Pool
{
    public static Dictionary<int, NodePool<MobBase>> MobPools;

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

        foreach (var key in DataBuilder.Tables.TbMobInfo.DataMap.Keys)
        {;
            var pool = new NodePool<MobBase>(
                () => new MobBuilder(DataBuilder.BuildMobInfoById(key)).Build(),
                mob =>
                {
                    mob.SetProcessMode(Node.ProcessModeEnum.Inherit);
                    mob.Show();
                    mob.PoolActive();
                },
                mob =>
                {
                    mob.SetProcessMode(Node.ProcessModeEnum.Disabled);
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
    }
}