using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts;

public sealed class PlayerCommands
{
    public int SomethingId { get; set; } = 1001;
    public void UseAbilityById() => DataBuilder.BuildAbilityById(SomethingId).Use();
    public void UseShooterById() => DataBuilder.BuildWeaponById(SomethingId).Use();
    public void UseBodyById() => DataBuilder.BuildBodyById(SomethingId).Use();
    public void UseShieldById() => DataBuilder.BuildShieldById(SomethingId).Use();
    public void LevelUp() => Global.Player.UpLevel();
    public void RemoveAllEffects() => Global.Player.Stats.EffectSystem.RemoveAllEffects();

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
    public int SomethingId { get; set; } = 1003;
    public void GenerateMobById() => Global.WaveSpawnerController.GenerateAMob(SomethingId);
    public void GenerateBossById() => Global.WaveSpawnerController.GenerateABoss(SomethingId);
    public void GenerateBossWaveById() => Global.WaveSpawnerController.GenerateBossWave(SomethingId);
    public void GenerateWave() => Global.WaveSpawnerController.GenerateWave();

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
