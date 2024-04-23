using System;

namespace NovaDrift.Scripts.Systems;

public class Ability : IItemInfo
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath { get; set; }
    public string ClassName;
    public Effect Effect;
    
    public event Action<Ability> OnDestroyed;
    
    public void Use()
    {
        Global.Player.Stats.AddEffect(this);
        Effect.OnDestroyed += effect => { OnDestroyed?.Invoke(this); };
    }
}