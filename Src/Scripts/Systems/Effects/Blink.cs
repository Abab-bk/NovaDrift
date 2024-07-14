using AcidWallStudio.AcidUtilities;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Systems.Effects;

public class Blink : Effect
{
    private Timer _timer;
    private bool _isCoolDown = false;
    
    public override void OnCreate()
    {
        base.OnCreate();

        _timer = new Timer
        {
            WaitTime = Values[1],
            OneShot = true,
        };
        
        EventBus.AddActionButton.Invoke("R to Blink", "R", Action);
        Target.AddChild(_timer);
        
        _timer.Timeout += () => _isCoolDown = false;
    }

    private void Action()
    {
        if (_isCoolDown) return;
        _isCoolDown = true;
        Color originalColor = Target.Modulate;
        GTweenSequenceBuilder.New()
            .Join(Target.TweenModulate(new Color("ffffff00"), 0.1f))
            .Join(Target.TweenGlobalPosition(
                Target.GetForwardVector2(Target.Stats.Speed.Value * 0.5f), 0.1f))
            .Append(Target.TweenModulate(originalColor, 0.1f))
            .AppendCallback(() =>
            {
                foreach (var target in Target.Shield.GetTargetsInRange())
                {
                    if (target is not MobBase mob) return;
                    mob.TakeDamageWithoutKnockBack(Values[0]);
                }
                _timer.Start();
            })
            .Build()
            .Play();
    }
}