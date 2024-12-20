using Godot;
using System;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class ForceField : BaseShield
{
    private StatModifier _accelerationModifier;
    private StatModifier _damageModifier;
    
    public override void SetPlayerColor()
    {
        base.SetPlayerColor();
        Global.GameContext.SetPlayerColor(new Color("a9ffa3"));
    }

    protected override void OnBodyEnteredMethod(Node2D body)
    {
        base.OnBodyEnteredMethod(body);
        UpdateDamage();
    }

    protected override void OnBodyExitedMethod(Node2D body)
    {
        base.OnBodyExitedMethod(body);
        UpdateDamage();
    }

    private void UpdateDamage()
    {
        var threatCount = ShieldArea.GetOverlappingBodies().Count;
        _damageModifier.Value = MathF.Min(
            _damageModifier.Value + Values[0] * threatCount, Values[1] + Target.Stats.ShieldPower.Value
        );
        _accelerationModifier.Value = MathF.Min(
            _accelerationModifier.Value + Values[0] * threatCount, Values[1] + Target.Stats.ShieldPower.Value
        );
        Target.Stats.Damage.ForceCalculate();
    }

    protected override void Active()
    {
        base.Active();
        
        _damageModifier = new StatModifier(Values[0], StatModType.PercentAdd, this);
        _accelerationModifier = new StatModifier(Values[0], StatModType.PercentAdd, this);
        
        Target.Stats.Acceleration.AddModifier(_accelerationModifier);
        Target.Stats.Damage.AddModifier(_damageModifier);
    }

    protected override void Break()
    {
        base.Break();
        Target.Stats.Acceleration.RemoveAllModifiersFromSource(this);
        Target.Stats.Damage.RemoveAllModifiersFromSource(this);
    }
}
