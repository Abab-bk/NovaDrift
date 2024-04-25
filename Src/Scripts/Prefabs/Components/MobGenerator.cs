using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class MobGenerator : Node2D
{
    [Export] private bool _enabled = true;
    [Export] private int _maxMobs = 1;
    [Export] private float _spawnCd = 3f;
    private Timer _timer;

    /*
     * 1. 选择需要生成的敌人（mob） -> 通过加权列表选择生成哪个敌人
     * 2. 查找 mob 的不同生成类型，并根据权重选择其中一种（有些生成类型比其他类型更常见）。
     *    生成类型（SpawnType）：决定了敌人生成的位置和顺序，以及它们是否有跟随者，如果有的话，跟随者的行为方式是怎样的。
     * 3. 选择 mob 入口
     * 4. 决定生成 mob 数量：有许多因素决定生成多少敌人。
     *    首先 使用三角分布从生成信息中的低值、均值和高值中获得一个基础值。
     *    然后，它添加一些随机因素，并根据玩家的进度进行缩放。
     *    接下来，确定是否将生成一波配对的敌人。配对的敌人意味着同时发生两个动态生成，每个生成中的敌人数量都减少。
     * 5. 敌方追随者生成：
     *    为了形成编队，首先需要确定敌人跟随者的数量，使用的方法与确定领导者数量的方法相同。
     *    跟随者还可以具有级联动作的能力。
     *    例如，如果一个编队生成时，有一个被8个守卫（Wardens）环绕的领导者，它们可能会依次发射，稍微错开时间，而不是同时发射。这样做会使游戏变得更有趣。
     *    此外，跟随者可能决定逐个脱离他们的领导者。驱动这些行为的值也在这里定义。
     * 6. 生成敌人
     */
    
    public override void _Ready()
    {
        if (!_enabled)
        {
            return;
        }

        Global.OnGameOver += () =>
        {
            _timer.Stop();
            _enabled = false;
        };

        Global.OnGameInit += () =>
        {
            _enabled = true;
            _timer.Start();
        };

        _timer = new Timer();
        AddChild(_timer);
        _timer.OneShot = false;
        _timer.WaitTime = _spawnCd;

        _timer.Timeout += SpawnAMob;
        _timer.Start();
    }
    
    private void SpawnAMob()
    {
        if (!_enabled) return;
        
        if (GetChildren().Count - 1 >= _maxMobs)
        {
            return;
        }

        MobBuilder mobBuilder = new MobBuilder();
        
        MobBase mob = mobBuilder
                        .SetMobInfo(DataBuilder.BuildMobInfoById(DataBuilder.GetRandomMobId()))
                        .Build();
        
        AddChild(mob);
        mob.GlobalPosition = GetRandomPosition();
    }

    private Vector2 GetRandomPosition()
    {
        Random rand = new Random();
        return new Vector2(rand.Next(0, 2560), rand.Next(0, 1440));
    }
}