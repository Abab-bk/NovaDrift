using System;
using System.Collections.Generic;

namespace NovaDrift.Scripts.Systems;

public class Ability : IItemInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string IconPath { get; set; }
    public string IconPath2 { get; set; }
    public string ClassName;
    public Effect Effect;
    public AbilityTree Tree;
    
    public event Action<Ability> OnDestroyed;
    
    public void Use()
    {
        Global.Player.Stats.AddEffect(this);
        
        DataBuilder.AbilityIdPool.Remove(Id);
        
        // 记录已经获得的 Ability
        if (Id == Tree.StartAbilityId)
        {
            DataBuilder.AbilityIdPool.Add(Tree.MiddleAbilityIds[0]);
            DataBuilder.AbilityIdPool.Add(Tree.MiddleAbilityIds[1]);
            DataBuilder.AbilityIdPool.Add(Tree.EndAbilityId);
        } else if (Id == Tree.MiddleAbilityIds[0])
        {
            DataBuilder.AbilityIdPool.Add(Tree.EndAbilityId);
            DataBuilder.AbilityIdPool.Remove(Tree.MiddleAbilityIds[1]);
        } else if (Id == Tree.MiddleAbilityIds[1])
        {
            DataBuilder.AbilityIdPool.Add(Tree.EndAbilityId);
            DataBuilder.AbilityIdPool.Remove(Tree.MiddleAbilityIds[0]);
        }
        
        Effect.OnDestroyed += effect => { OnDestroyed?.Invoke(this); };
    }
}