using Godot;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class SiegeWeaponry : Effect
{
    private StatModifier _shootSpeedModifier;
    private StatModifier _shootKnockBacKModifier;

    private Timer _timer;
    
    public override void OnCreate()
    {
        base.OnCreate();
        _timer = new Timer()
        {
            WaitTime = 0.1f,
            OneShot = false
        };
        Target.AddChild(_timer);

        _shootSpeedModifier = new StatModifier(Values[0], StatModType.PercentAdd);
        _shootKnockBacKModifier = new StatModifier(Values[1], StatModType.PercentAdd);
        
        Target.StartShooting += () =>
        {
            Target.Stats.ShootSpeed.AddModifier(_shootSpeedModifier);
            Target.Stats.ShootKnockBack.AddModifier(_shootKnockBacKModifier);
            
            _timer.Start();
        };

        _timer.Timeout += () =>
        {
            Target.TakeDamage(Target.Stats.Damage.Value * 0.01f);
            if (_shootSpeedModifier.Value <= -1f) return;

            _shootSpeedModifier.Value += Values[0];
            Target.Stats.ShootSpeed.ForceCalculate();
        };

        Target.StopShooting += () =>
        {
            _timer.Stop();

            _shootSpeedModifier.Value = Values[0];
            
            Target.Stats.ShootSpeed.RemoveModifier(_shootSpeedModifier);
            Target.Stats.ShootKnockBack.RemoveModifier(_shootKnockBacKModifier);
        };
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _timer.QueueFree();
    }
}