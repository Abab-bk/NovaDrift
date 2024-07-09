using Godot;

namespace NovaDrift.Scripts.Systems.Effects;

public class RegenerativeShields : Effect
{
    private Timer _timer;

    public override void OnCreate()
    {
        base.OnCreate();
        
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[0]), Target.Stats.Regeneration);
        
        _timer = new Timer();
        Target.AddChild(_timer);
        _timer.Timeout += () =>
        {
            if (Target.Shield.IsActive)
            {
                Target.Shield.Health.Increase(
                    (Target.Shield.Health.MaxValue.Value / 50 * Target.Stats.Regeneration.Value) * Values[1]);
                Target.Stats.Health.Increase(
                    (Target.Stats.Health.MaxValue.Value / 50 * Target.Stats.Regeneration.Value) * Values[2]);
                return;
            }
            Target.Stats.Health.Increase(
                (Target.Stats.Health.MaxValue.Value / 50 * Target.Stats.Regeneration.Value) * Values[3]);
        };
        _timer.Start();
    }
}