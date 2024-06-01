using System;
using System.Collections.Generic;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using Godot;
using KaimiraGames;
using NovaDrift.addons.AcidUtilities;
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
    
    public void GenerateWave()
    {
        List<MobInfo> generatedMobs = new List<MobInfo>();
        
        while (Cost > 0)
        {
            var mobInfo = FuncMobInfos.PickRandom();
            if (Cost - mobInfo.DangerFactor < 0) continue;
            
            generatedMobs.Add(mobInfo);
            Cost -= mobInfo.DangerFactor;
        }

        var spawnType = FuncSpawnTypeList.Next();
        spawnType.SetMobCount(generatedMobs.Count);
        
        var mobIndex = 0;
        
        foreach (var mobInfo in generatedMobs)
        {
            var mobBuilder = new MobBuilder(mobInfo);
            var mob = mobBuilder.Build();
            Global.GameWorld.AddChild(mob);
            
            mob.GlobalPosition = ToGlobal(spawnType.GetSpawnPosition(mobIndex));

            mobIndex += 1;
        }
        
        Logger.Log($"敌人生成数量: {generatedMobs.Count}, 阵型：{spawnType.GetType().Name}");
    }
    
    private void RandomMove()
    {
        var pos = Vector2.Zero;

        switch (Random.Shared.Next(1, 2))
        {
            case 1:
                var y = Wizard.GetRandomScreenY();
                pos.X = Wizard.GetRandomScreenX();
                pos.Y = y > y / 2f ? 0 + 100f : 0 - 100f;
                break;
            case 2:
                var x = Wizard.GetRandomScreenX();
                pos.Y = Wizard.GetRandomScreenY();
                pos.X = x > x / 2f ? 0 + 100f : 0 - 100f;
                break;
        }
        
        GlobalPosition = pos;
    }
}


public class SpawnType
{
    protected IShape Shape;
    
    public Vector2 GetSpawnPosition(int mobCount)
    {
        return Shape.GetPosByIndex(mobCount);
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