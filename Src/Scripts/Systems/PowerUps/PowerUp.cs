using System;
using cfg;

namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerUp
{
    public event Action OnDestroy;
    public PowerUpInfo PowerUpInfo;

    public void Use()
    {
    }
    
    public void Destroy()
    {
        OnDestroy?.Invoke();
    }
}