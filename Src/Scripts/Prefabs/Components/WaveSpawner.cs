using System.Collections.Generic;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

public partial class WaveSpawner : Node2D
{
    public int Cost;
    private static readonly List<MobInfo> FuncMobInfos = DataBuilder.Tables.TbMobInfo.DataMap.Keys
        .Select(DataBuilder.BuildMobInfoById)
        .ToList();

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

        foreach (var mobInfo in generatedMobs)
        {
            var mobBuilder = new MobBuilder(mobInfo);
            var mob = mobBuilder.Build();
            Global.GameWorld.AddChild(mob);
            mob.GlobalPosition = ToGlobal(Vector2.Zero);
        }
    }
    
    private void RandomMove()
    {
        GlobalPosition = Wizard.GetRandomScreenPosition();
    }
}