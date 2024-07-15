using System;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Systems.PowerUps;
using NovaDrift.Scripts.Ui.ActionBtn;

namespace NovaDrift.Scripts;

public static class EventBus
{
    public static Action<MobBase> OnMobDied;
    public static Action<int> OnPlayerUpLevel;
    public static Action OnPlayerDead;
    public static Action OnGameOver;
    public static Action OnGameInit;
    public static Action OnGameStart;
    public static Action<PowerUp> OnPlayerGetPowerUp;

    public static event Action<MobBase> OnMobEnteredTree;

    public static Action OnWorldColorChanged;

    public static Action<string, string, Action> AddActionButton;

    static EventBus()
    {
        OnGameOver += () =>
        {
            Logger.Log("[EventBus] Game Over.");
        };
    }

    public static void EnteredMob(MobBase mobBase)
    {
        OnMobDied?.Invoke(mobBase);
    }
}