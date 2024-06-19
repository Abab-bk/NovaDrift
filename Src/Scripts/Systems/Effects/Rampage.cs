using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Systems.Effects;

public class Rampage : Effect
{
    private bool _rage;
    private Timer _timer;
    
    public override void OnCreate()
    {
        base.OnCreate();

        _timer = new Timer()
        {
            WaitTime = Values[1],
            OneShot = true
        };
        
        Target.AddChild(_timer);
        
        EventBus.OnMobDied += _ =>
        {
            if (Wizard.GetChance() <= Values[0])
            {
                if (_rage) return; 
                _rage = true;
            }

            if (!_rage) return;
            
            AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
                Values[2]), Target.Stats.Damage);
            
            _timer.Start();
        };

        _timer.Timeout += () =>
        {
            if (!_rage) return;
            _rage = false;
            RemoveAllModifierFromTarget();
        };
    }
}