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
    
    public void GenerateWave()
    {
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
        
        var mobIndex = 0;
        
        foreach (var mobInfo in generatedMobs)
        {
            var mob = new MobBuilder(mobInfo).Build();
            Global.GameWorld.AddChild(mob);
            
            mob.GlobalPosition = ToGlobal(spawnType.GetSpawnPosition(mobIndex));

            mobIndex += 1;
        }
        RandomMove();
        Logger.Log($"[Wave Spawner] 敌人生成数量: {generatedMobs.Count}, 阵型：{spawnType.GetType().Name}");
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

        switch (Random.Shared.Next(1, 2))
        {
            case 1:
                // From random top or bottom
                var y = Wizard.GetRandomScreenY();
                pos.X = Wizard.GetRandomScreenX();
                pos.Y = pos.Y > y / 2f ? 0 - 100f : Wizard.GetMaxScreenY() + 100f;
                break;
            case 2:
                // From random left or right
                var x = Wizard.GetRandomScreenX();
                pos.Y = Wizard.GetRandomScreenY();
                pos.X = pos.X > x / 2f ? 0 - 100f : Wizard.GetMaxScreenX() + 100f;
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