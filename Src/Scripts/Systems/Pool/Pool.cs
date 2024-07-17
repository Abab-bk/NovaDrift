using System.Collections.Generic;
using AcidWallStudio.ObjectPool;
using Godot;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Pool;

public static class Pool
{
    public static Dictionary<int, NodePool<MobBase>> MobPools;
    public static Dictionary<int, NodePool<MobBase>> CloneMobPools;
    public static NodePool<DieVfx> DieVfxPool;
    public static NodePool<FocusParticles> FocusVfxPool;
    public static NodePool<BlastVfx> BlastVfxPool;
    public static NodePool<GpuParticles2D> BounceVfxPool;
    public static NodePool<ExpBall> ExpBallPool;

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
        CloneMobPools = new();

        // 初始化 MobPools
        foreach (var key in DataBuilder.Tables.TbMobInfo.DataMap.Keys)
        {
            var pool = new NodePool<MobBase>(
                () => new MobBuilder(DataBuilder.BuildMobInfoById(key)).Build(),
                mob =>
                {
                    mob.IsActive = true;
                    mob.IsDead = false;
                    mob.SetProcessMode(Node.ProcessModeEnum.Inherit);
                    // mob.Show();
                    mob.PoolActive();
                },
                mob =>
                {
                    mob.IsActive = false;
                    mob.Ai.Release();
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
            
            var clonePool = new NodePool<MobBase>(
                () =>
                {
                    var mob = new MobBuilder(DataBuilder.BuildMobInfoById(key)).Build();
                    var ai = new MobAiComponent();
                    ai.SetScript(GD.Load<GodotObject>("res://Scripts/Prefabs/Ai/CloneMobAi.cs"));
                    mob.Ai = ai;
                    return mob;
                },
                mob =>
                {
                    mob.IsActive = true;
                    mob.IsDead = false;
                    mob.SetProcessMode(Node.ProcessModeEnum.Inherit);
                    mob.PoolActive();
                },
                mob =>
                {
                    mob.IsActive = false;
                    mob.Ai.Release();
                    mob.CallDeferred(Node.MethodName.SetProcessMode, (int)Node.ProcessModeEnum.Disabled);
                    mob.Hide();
                    mob.Scale = Vector2.One;
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
            CloneMobPools[key] = clonePool;
            Global.GameWorld.AddChild(pool);
            Global.GameWorld.AddChild(clonePool);
        }
        foreach (var pool in MobPools.Values)
        {
            pool.Init(mob =>
            {
                mob.Pool = pool;
            });
        }
        foreach (var pool in CloneMobPools.Values)
        {
            pool.Init(mob =>
            {
                mob.Pool = pool;
                mob.Ai.Reparent(mob);
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
        
        FocusVfxPool = new NodePool<FocusParticles>(
            () => GD.Load<PackedScene>("res://Scenes/Vfx/FocusParticles.tscn").Instantiate<FocusParticles>(),
            particles =>
            {
                particles.SetProcessMode(Node.ProcessModeEnum.Pausable);
                particles.Show();
            },
            particles =>
            {
                particles.SetProcessMode(Node.ProcessModeEnum.Disabled);
                particles.Hide();
            },
            particles =>
            {
                particles.QueueFree();
            },
            true,
            80,
            200
        );
        
        BlastVfxPool = new NodePool<BlastVfx>(
            () => GD.Load<PackedScene>("res://Scenes/Vfx/Blast.tscn").Instantiate<BlastVfx>(),
            particles =>
            {
                particles.SetProcessMode(Node.ProcessModeEnum.Inherit);
                particles.Show();
            },
            particles =>
            {
                particles.SetProcessMode(Node.ProcessModeEnum.Disabled);
                particles.Hide();
            },
            particles =>
            {
                particles.QueueFree();
            },
            true,
            80,
            200
        );
        
        BounceVfxPool = new NodePool<GpuParticles2D>(
            () =>
            {
                var vfx = GD.Load<PackedScene>("res://Scenes/Vfx/BounceVfx.tscn").Instantiate<GpuParticles2D>();
                vfx.Finished += () => { BounceVfxPool.Release(vfx); };
                return vfx;
            },
            particles =>
            {
                particles.SetProcessMode(Node.ProcessModeEnum.Inherit);
                particles.Show();
            },
            particles =>
            {
                particles.SetProcessMode(Node.ProcessModeEnum.Disabled);
                particles.Hide();
                particles.Emitting = false;
            },
            particles =>
            {
                particles.QueueFree();
            },
            true,
            80,
            200
        );
        
        ExpBallPool = new NodePool<ExpBall>(
            () =>
            {
                var node = GD.Load<PackedScene>("res://Scenes/Vfx/ExpBall.tscn").Instantiate<ExpBall>();
                return node;
            },
            node =>
            {
                node.IsActive = true;
                node.SetProcessMode(Node.ProcessModeEnum.Inherit);
                node.Show();
            },
            node =>
            {
                node.IsActive = false;
                node.SetProcessMode(Node.ProcessModeEnum.Disabled);
                node.Hide();
            },
            node =>
            {
                node.QueueFree();
            },
            true,
            400,
            400
        );

        Global.GameWorld.AddChild(ExpBallPool);
        ExpBallPool.Init();
        
        Global.GameWorld.AddChild(BounceVfxPool);
        BounceVfxPool.Init();
        
        Global.GameWorld.AddChild(DieVfxPool);
        DieVfxPool.Init();
        
        // Global.GameWorld.AddChild(FocusVfxPool);
        // FocusVfxPool.Init();
        //
        // Global.GameWorld.AddChild(BlastVfxPool);
        // BlastVfxPool.Init();
    }
}