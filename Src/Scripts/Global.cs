using System;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts;

public enum Layer
{
    None = 0,
    Player = 1,
    Mob = 2,
    PlayerHitBox = 3,
    PlayerHurtBox = 4,
    MobHitBox = 5,
    MobHurtBox = 6,
}

public class Global
{
    public static Player Player;
    public static GameWorld GameWorld;

    public static Action<MobBase> OnMobDied;
    
    public static Action<int> OnPlayerUpLevel;
}