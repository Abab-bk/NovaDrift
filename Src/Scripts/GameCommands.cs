using GDebugPanelGodot.Core;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Others;
using NovaDrift.Scripts.Systems.Debugs;

namespace NovaDrift.Scripts;

public class GameCommands
{
    private IDebugActionsSection _player;
    private IDebugActionsSection _world;
    
    public GameCommands()
    {
        EventBus.OnGameStart += Generate;
        // EventBus.OnGameOver += Remove;
        Logger.Log("[Ui] Init debug panel class.");
    }

    private void Generate()
    {
        if (_player != null) return;
        
        Logger.Log("[Ui] Generate debug panel");
        // Player
        _player = GDebugPanel.AddSection("Player", new PlayerCommands());

        _player.AddCustomStat();
        
        // World
        var worldCommand = new WorldCommands();
        var worldSection = GDebugPanel.AddSection("World", worldCommand);
        _world = worldSection;
		
        var worldColor = WorldCommands.WorldColors.Red;
		
        worldSection.AddEnum("ColorType", val =>
        {
            worldColor = val;

            switch (worldColor)
            {
                case WorldCommands.WorldColors.Red:
                    Global.SetWorldColor(Constants.Colors.Red);
                    break;
                case WorldCommands.WorldColors.Blue:
                    Global.SetWorldColor(Constants.Colors.Blue);
                    break;
            }
        }, () => worldColor);
    }

    private void Remove()
    {
        Logger.Log("[Ui] Remove debug panel");
        GDebugPanel.RemoveSection(_player);
        GDebugPanel.RemoveSection(_world);
    }
}

public sealed class PlayerCommands
{
    public int SomethingId { get; set; } = 1001;
    public void UseAbilityById() => DataBuilder.BuildAbilityById(SomethingId).Use();
    public void UseShooterById() => DataBuilder.BuildWeaponById(SomethingId).Use();
    public void UseBodyById() => DataBuilder.BuildBodyById(SomethingId).Use();
    public void UseShieldById() => DataBuilder.BuildShieldById(SomethingId).Use();
    public void LevelUp() => Global.Player.UpLevel();
    public void RemoveAllEffects() => Global.Player.Stats.EffectSystem.RemoveAllEffects();
    public void PrintAllAbilities()
    {
        foreach (var ability in Global.Player.Stats.EffectSystem.Abilities)
        {
            Logger.Log("[Player] Has ability: " + ability.Name);
        }
    }

    public void ApplyBuildById()
    {
        Global.Player.Stats.EffectSystem.RemoveAllEffects();
        Global.Player.Stats.BuffSystem.RemoveAllBuffs();
        var build = DataBuilder.Tables.TbPlayerBuild.Get(SomethingId);
        foreach (var abilityId in build.Abilities)
        {
            DataBuilder.BuildAbilityById(abilityId).Use();
        }
        DataBuilder.BuildShieldById(build.ShieldId).Use();
        DataBuilder.BuildWeaponById(build.ShooterId).Use();
        DataBuilder.BuildBodyById(build.BodyId).Use();
    }
}

public sealed class WorldCommands
{
    public int SomethingId { get; set; } = 1002;
    public void GenerateMobById() => Global.WaveSpawnerController.GenerateAMob(SomethingId);
    public void GenerateBossById() => Global.WaveSpawnerController.GenerateABoss(SomethingId);
    public void GenerateBossWaveById() => Global.WaveSpawnerController.GenerateBossWave(SomethingId);
    public void GenerateWave() => Global.WaveSpawnerController.GenerateWave();

    public void KillAllMobs()
    {
        Global.Player.GetTree().CallGroup("Mobs", "RemoveSelf");
    }

    public void ChangeWorldCorrection()
    {
        Global.SetWorldCorrection(GD.Load<GradientTexture2D>("res://Assets/Gradients/KnightEnvironment.tres"));
    }

    public void SpawnPowerUpEntity()
    {
        var powerUp = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/PowerUpEntity.tscn")
            .Instantiate<PowerUpEntity>();
        powerUp.PowerUp = DataBuilder.BuildPowerUpById(SomethingId);
        Global.GameWorld.AddChild(powerUp);
        powerUp.GlobalPosition = SpawnPoint.GetPoint(Constants.Points.Center);
    }

    public void GameOver()
    {
        Global.ResumeGame();
        EventBus.OnPlayerDead?.Invoke();
        EventBus.OnGameOver?.Invoke();
    }

    public HazardSpawner.HazardType HazardType { get; set; }
    public void SpawnHazard() => Global.HazardSpawner.SpawnHazard(HazardType);
    
    public enum WorldColors
    {
        Red,
        Blue,
    }
}
