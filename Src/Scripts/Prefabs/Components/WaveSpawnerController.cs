using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class WaveSpawnerController : Node2D
{
    [Export] bool _enabled;

    public override void _Ready()
    {
        EventBus.OnGameStart += GenerateWave;
    }

    public void GenerateWave()
    {
        if (!_enabled) return;
        var waveSpawner = new WaveSpawner();
        waveSpawner.Cost = 10;
        AddChild(waveSpawner);
        waveSpawner.GenerateWave();
    }
}