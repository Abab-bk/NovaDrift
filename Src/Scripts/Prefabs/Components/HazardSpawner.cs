using System;
using AcidWallStudio.AcidUtilities;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Hazards;
using NovaDrift.Scripts.Prefabs.Others;
using NovaDrift.Scripts.Vfx;

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
        // var pos = new Vector2(
        //     Random.Shared.FloatRange(
        //         SpawnPoint.GetPoint(Constants.Points.LeftUpLimit).X,
        //         SpawnPoint.GetPoint(Constants.Points.RightUpLimit).X
        //         ),
        //     Random.Shared.FloatRange(
        //         SpawnPoint.GetPoint(Constants.Points.LeftUpLimit).Y,
        //         SpawnPoint.GetPoint(Constants.Points.LeftDownLimit).Y
        //     )
        //     );
        var pos = Wizard.GetRandomScreenPosition();
        
        IHazard hazard = GetHazard(type);

        if (hazard is not Node2D node) return;
        
        AddChild(node);
        node.GlobalPosition = pos;
        
        return;
        var warning = GD.Load<PackedScene>("res://Scenes/Vfx/WarningVfx.tscn").Instantiate<WarningVfx>();
        // UiManager.Get_Hud_Instance()[0].AddChild(warning);
        UiManager.GetUiLayer(UiLayer.Middle).AddChild(warning);
        warning.GlobalPosition = pos;
        warning.OnAnimationEnd += () =>
        {
            IHazard hazard = GetHazard(type);

            if (hazard is not Node2D node) return;
            
            AddChild(node);
            node.GlobalPosition = pos;
        };
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
                var train = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/Train.tscn").Instantiate<Train>();
                train.Rotation = Random.Shared.NextSingle() * MathF.Tau;
                return train;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}