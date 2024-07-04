using System;
using cfg;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerUp
{
    public event Action OnDestroy;
    public PowerUpInfo PowerUpInfo;

    public virtual void Use()
    {
    }
    
    public void Destroy()
    {
        OnDestroy?.Invoke();
    }
}