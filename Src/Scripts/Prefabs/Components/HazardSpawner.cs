using System;
using AcidWallStudio.AcidUtilities;
using GDebugPanelGodot.Core;
using Godot;
using NovaDrift.Scripts.Prefabs.Hazards;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class HazardSpawner : Node2D
{
    [Export] private bool _enabled = true;
    
    public enum HazardType
    {
        AsteroidSmall,
        AsteroidMedium,
        AsteroidLarge,
        Train,
    }
    
    private Timer _timer;

    public override void _Ready()
    {
        Global.HazardSpawner = this;
        
        _timer = new Timer
        {
            OneShot = false,
            WaitTime = 20f,
        };
        AddChild(_timer);

        _timer.Timeout += () =>
        {
            if (!_enabled) return;
            SpawnHazard(GetRandomHazardType());
        };
        
        if (!_enabled) return;
        SpawnHazard(GetRandomHazardType());
        _timer.Start();
    }

    public void SpawnHazard(HazardType type)
    {
        IHazard hazard = GetHazard(type);

        if (hazard is not Node2D node) return;
        
        AddChild(node);
        node.GlobalPosition = Wizard.GetRandomScreenPosition();
    }

    private HazardType GetRandomHazardType() { return Random.Shared.GetRandomEnum<HazardType>(); }

    private IHazard GetHazard(HazardType type)
    {
        switch (type)
        {
            case HazardType.AsteroidSmall:
                return GD.Load<PackedScene>("res://Scenes/Prefabs/Hazards/AsteroidSmall.tscn").Instantiate<AsteroidBase>();
            case HazardType.AsteroidMedium:
                return GD.Load<PackedScene>("res://Scenes/Prefabs/Hazards/AsteroidMedium.tscn").Instantiate<AsteroidBase>();
            case HazardType.AsteroidLarge:
                return GD.Load<PackedScene>("res://Scenes/Prefabs/Hazards/AsteroidLarge.tscn").Instantiate<AsteroidBase>();
            case HazardType.Train:
                return GD.Load<PackedScene>("res://Scenes/Prefabs/Others/Train.tscn").Instantiate<Train>();
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}