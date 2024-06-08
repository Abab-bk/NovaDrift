using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Systems.Effects;

public class AdrenalModule : Effect
{
    private StatModifier _modifier;
    
    public override void OnCreate()
    {
        base.OnCreate();
        _modifier = DataBuilder.BuildPercentAddModifier(0f);
        
        foreach (var node in Global.SceneTree.GetNodesInGroup("Mobs"))
        {
            if (node is not MobBase mobBase) continue;
            mobBase.Stats.InjuryFactor.AddModifier(_modifier);
        }
        
        EventBus.OnMobEnteredTree += (mob) =>
        {
            mob.Stats.InjuryFactor.AddModifier(_modifier);
        };

        Target.Stats.Health.ValueChanged += f =>
        {
            SetModifierValue();
        };
        
        Target.Shield.Health.ValueChanged += f =>
        {
            SetModifierValue();
        };
    }

    private void SetModifierValue()
    {
        var shieldRatio = Target.Shield.Health.BaseValue / Target.Shield.Health.MaxValue.Value;
        var healthRatio = Target.Stats.Health.BaseValue / Target.Stats.Health.MaxValue.Value;
        _modifier.Value = Mathf.Min(Values[0], (shieldRatio + healthRatio) / 2f);
    }
}