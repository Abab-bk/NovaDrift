using Godot;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class Regeneration : Effect
{
    private Timer _timer;
    
    public override void OnCreate()
    {
        _timer = new Timer
        {
            WaitTime = 1.0f,
            OneShot = true
        };
        Target.AddChild(_timer);

        _timer.Timeout += () =>
        {
            AddModifierToTarget(
                new StatModifier(
                Target.Stats.Health.BaseValue / Target.Stats.Health.MaxValue.Value, StatModType.PercentAdd, _timer),
                Target.Stats.Regeneration
            );
            _timer.WaitTime = Mathf.Max(0.1, _timer.WaitTime - 0.1);
            _timer.Start();
        };

        Target.Stats.Health.ValueToMax += f =>
        {
            Target.Stats.Regeneration.RemoveAllModifiersFromSource(_timer);
        };

        base.OnCreate();
        AddModifierToTarget(
            DataBuilder.BuildPercentAddModifier(Values[0]), Target.Stats.Regeneration);
        
        _timer.Start();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _timer.QueueFree();
    }
}