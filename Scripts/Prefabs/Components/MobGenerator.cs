using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class MobGenerator : Node2D
{
    [Export] private bool _enabled = true;
    [Export] private float _spawnCd = 3f;
    private Timer _timer;

    public override void _Ready()
    {
        if (!_enabled)
        {
            return;
        }

        _timer = new Timer();
        AddChild(_timer);
        _timer.OneShot = false;
        _timer.WaitTime = _spawnCd;

        _timer.Timeout += SpawnAMob;
        _timer.Start();
    }

    private void SpawnAMob()
    {
        MobBuilder mobBuilder = new MobBuilder();
        MobBase mob = mobBuilder.Build();
        AddChild(mob);
        mob.GlobalPosition = GetRandomPosition();
    }

    private Vector2 GetRandomPosition()
    {
        Random rand = new Random();
        return new Vector2(rand.Next(0, 2560), rand.Next(0, 1440));
    }
}