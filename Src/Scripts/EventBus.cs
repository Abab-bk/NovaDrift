using System;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts;

public static class EventBus
{
    public static Action<MobBase> OnMobDied;
    public static Action<int> OnPlayerUpLevel;
    public static Action OnPlayerDead;
    public static Action OnGameOver;
    public static Action OnGameInit;
    public static Action OnGameStart;

    public static Action OnWorldColorChanged;
}