using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;
using KaimiraGames;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

    /*
     * 1. 选择需要生成的敌人（mob） -> 通过加权列表选择生成哪个敌人
     * 2. 查找 mob 的不同生成类型，并根据权重选择其中一种（有些生成类型比其他类型更常见）。
     *    生成类型（SpawnType）：决定了敌人生成的位置和顺序，以及它们是否有跟随者，如果有的话，跟随者的行为方式是怎样的。
     * 3. 决定生成 mob 数量：有许多因素决定生成多少敌人。
     *    首先 使用三角分布从生成信息中的低值、均值和高值中获得一个基础值。
     *    然后，它添加一些随机因素，并根据玩家的进度进行缩放。
     *    接下来，确定是否将生成一波配对的敌人。配对的敌人意味着同时发生两个动态生成，每个生成中的敌人数量都减少。
     * 4. 敌方追随者生成：
     *    为了形成编队，首先需要确定敌人跟随者的数量，使用的方法与确定领导者数量的方法相同。
     *    跟随者还可以具有级联动作的能力。
     *    例如，如果一个编队生成时，有一个被8个守卫（Wardens）环绕的领导者，它们可能会依次发射，稍微错开时间，而不是同时发射。这样做会使游戏变得更有趣。
     *    此外，跟随者可能决定逐个脱离他们的领导者。驱动这些行为的值也在这里定义。
     * 5. 生成敌人
     */

[GlobalClass]
public partial class MobSpawner : Node2D
{
    [Export] bool _enabled = true;

    private WaveInfo _waveInfo;
    private Timer _timer;
    
    public override void _Ready()
    {
        if (!_enabled) return;
        _timer = new Timer
        {
            WaitTime = 2f,
            OneShot = true,
            Autostart = false,
        };
        AddChild(_timer);
        _timer.Timeout += GenerateMob;
        _timer.Start();
    }

    private WaveInfo NewWaveInfo()
    {
        WeightedList<int> mobList = new WeightedList<int>();
        mobList.Add(1001, 1);
        mobList.Add(1002, 2);
        
        WeightedList<SpawnType> spawnTypeList = new WeightedList<SpawnType>();
        spawnTypeList.Add(new StandardSpawnType(), 1);
        spawnTypeList.Add(new ArcSpawnType(), 1);
        
        return new WaveInfo(mobList, spawnTypeList);
    }

    private void GenerateMob()
    {
        _waveInfo = NewWaveInfo();
        SpawnMob(_waveInfo.SelectSpawnType());
    }

    private void SpawnMob(SpawnType spawnType)
    {
        MobInfo mobInfo = _waveInfo.SelectMob();
        int mobCount = _waveInfo.SelectMobCount(spawnType);

        GD.Print($"预备生成{mobCount}个敌人");
        for (int i = 1; i <= mobCount; i++)
        {
            GD.Print("生成第 " + i + " 个敌人");
            
            MobBuilder mobBuilder = new MobBuilder();
            mobBuilder.SetMobInfo(mobInfo);
            var mob = mobBuilder.Build();
            
            if (mob == null) return;
            
            AddChild(mob);
            mob.Position = spawnType.GetSpawnPosition(i);   
        }
    }
    
    private void SpawnAMobPair()
    {
    }
}


public class WaveInfo
{
    private readonly WeightedList<int> _mobList;
    private readonly WeightedList<SpawnType> _spawnTypeList;

    public MobInfo SelectMob() { return DataBuilder.BuildMobInfoById(_mobList.Next()); }
    public SpawnType SelectSpawnType() { return _spawnTypeList.Next(); }

    public WaveInfo(WeightedList<int> mobList, WeightedList<SpawnType> spawnTypeList)
    {
        _mobList = mobList;
        _spawnTypeList = spawnTypeList;
    }

    public int SelectMobCount(SpawnType spawnType)
    {
        return (int)Wizard.GetTriangularSample(
            spawnType.MaxMobCount,
            spawnType.MinMobCount,
            spawnType.ModeMobCount);
    }
}


// 生成类型（SpawnType）：决定了敌人生成的位置和顺序，以及它们是否有跟随者，如果有的话，跟随者的行为方式是怎样的。
public class SpawnType
{
    public int MaxMobCount;
    public int MinMobCount;
    public int ModeMobCount;
    
    protected bool HasFollowers;

    public virtual Vector2 GetSpawnPosition(int mobCount) { return Vector2.Zero; }
}

public class StandardSpawnType : SpawnType
{
    public StandardSpawnType()
    {
        MaxMobCount = 4;
        MinMobCount = 1;
        ModeMobCount = 2;
        HasFollowers = false;
    }

    public override Vector2 GetSpawnPosition(int mobCount)
    {
        switch (mobCount)
        {
            case 1:
                return new Vector2(-100, -100);
            case 2:
                return new Vector2(100, -100);
            case 3:
                return new Vector2(100, 100);
            case 4:
                return new Vector2(-100, 100);
            default:
                return new Vector2(0, 0);
        }
    }
}

public class ArcSpawnType : SpawnType
{
    public ArcSpawnType()
    {
        MaxMobCount = 6;
        MinMobCount = 3;
        ModeMobCount = 3;
        HasFollowers = true;
    }

    public override Vector2 GetSpawnPosition(int mobCount)
    {
        switch (mobCount)
        {
            case 1:
                return new Vector2(-100, -100);
            case 2:
                return new Vector2(100, -100);
            case 3:
                return new Vector2(100, 100);
            case 4:
                return new Vector2(-100, 100);
            case 5:
                return new Vector2(0, 0);
            case 6:
                return new Vector2(0, 0);
            default:
                return new Vector2(0, 0);
        }
    }
}