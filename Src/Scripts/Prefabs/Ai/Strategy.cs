using System;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs.Ai;

public class Strategy(string name, float desireDistance, Action<MobBase> action)
{
    public string Name => name;
    private float DesireDistance => desireDistance;
    private Action<MobBase> Action => action;

    private float _modifier;

    public void Execute(MobBase mob)
    {
        Action?.Invoke(mob);
        _modifier += 20;
    }

    public float GetAttackScore(MobBase mob)
    {
        var distanceDifference = Math.Abs(DesireDistance - mob.GetDistanceToPlayer());
        var normalizedDifference = distanceDifference / 10f;
        var abilityScore = 1 - normalizedDifference - _modifier;
        
        Logger.Log($"[Strategy: {Name}] Score: {abilityScore} Modifier: {_modifier}");
        
        return abilityScore;
    }
}