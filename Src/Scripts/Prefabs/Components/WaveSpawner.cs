using System;
using System.Collections.Generic;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using Godot;
using KaimiraGames;
using NovaDrift.addons.AcidUtilities;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

public partial class WaveSpawner : Node2D
{
    public int Cost;
    private static readonly List<MobInfo> FuncMobInfos = DataBuilder.Tables.TbMobInfo.DataMap.Keys
        .Select(DataBuilder.BuildMobInfoById)
        .ToList();
    private static readonly WeightedList<SpawnType> FuncSpawnTypeList = new (
        new List<WeightedListItem<SpawnType>>
        {
            new (new RectSpawnType(), 1),
            new (new CircleSpawnType(), 1),
            new (new SpiralSpawnType(), 1),
        });

    public override void _Ready()
    {
        RandomMove();
    }
    
    public void GenerateWave(Vector2 pos = default)
    {
        if (pos == default)
        {
            RandomMove();
        }
        else
        {
            GlobalPosition = pos;
        }
        
        List<MobInfo> generatedMobs = [];
        
        while (Cost > 0)
        {
            var mobInfo = FuncMobInfos.PickRandom();
            if (Cost - mobInfo.DangerFactor < 0) continue;
            
            generatedMobs.Add(mobInfo);
            Cost -= mobInfo.DangerFactor;
        }

        var spawnType = FuncSpawnTypeList.Next();
        spawnType.SetMobCount(generatedMobs.Count);
        
        foreach (var mobInfo in generatedMobs)
        {
            RandomMove();
            var mob = new MobBuilder(mobInfo).Build();
            mob.GlobalPosition = GlobalPosition;
            Global.GameWorld.CallDeferred(Node.MethodName.AddChild, mob);
            // Global.GameWorld.AddChild(mob);
        }

        Logger.Log($"[Wave Spawner] 敌人生成数量: {generatedMobs.Count}, 阵型：{spawnType.GetType().Name}");
        
        QueueFree();
    }

    public MobBase GenerateABoss(int id)
    {
        var mob = new MobBuilder(DataBuilder.BuildBossMobInfoById(id)).Build();
        Global.GameWorld.AddChild(mob);
        mob.GlobalPosition = Vector2.Zero;
        RandomMove();
        return mob;
    }

    private void RandomMove()
    {
        var pos = Wizard.GetRandomScreenPosition();
        
        switch (Random.Shared.Next(0, 4))
        {
            case 0:
                pos = SpawnPoint.GetPoint(Constants.Points.RandomLeft) + new Vector2(-200f, 0);
                break;
            case 1:
                pos = SpawnPoint.GetPoint(Constants.Points.RandomRight) + new Vector2(200f, 0);
                break;
            case 2:
                pos = SpawnPoint.GetPoint(Constants.Points.RandomUp) + new Vector2(0, -200f);
                break;
            case 3:
                pos = SpawnPoint.GetPoint(Constants.Points.RandomDown) + new Vector2(0, 200f);
                break;
        }
        
        GlobalPosition = pos;
        // Logger.Log($"[Wave Spawner] Random move to: {GlobalPosition}");
    }
}


public class SpawnType
{
    protected IShape Shape;
    
    public Vector2 GetSpawnPosition(int mobCount)
    {
        return Shape.GetPosByIndex(mobCount);
    }

    public List<Vector2> GetPoints()
    {
        return Shape.Points;
    }

    public virtual void SetMobCount(int mobCount)
    {
    }
}

public class RectSpawnType : SpawnType
{
    public override void SetMobCount(int mobCount)
    {
        Shape = new RectangleShape(mobCount, 400, 400);
    }
}

public class CircleSpawnType : SpawnType
{
    public override void SetMobCount(int mobCount)
    {
        Shape = new CircleShape(mobCount, 400);
    }
}

public class SpiralSpawnType : SpawnType
{
    public override void SetMobCount(int mobCount)
    {
        Shape = new SpiralShape(mobCount, 400, 400);
    }
}