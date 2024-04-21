using System;
using Godot;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Effects;

public class Warpath : Effect
{
    private int _token = 0;
    private float _addKnockBack = 0;
    private float _addShootSpeed = 0;
    private Timer _timer = null;
    
    public override void OnCreate()
    {
        base.OnCreate();
        Global.OnMobDied += _ =>
        {
            if (_token == 0) { _timer.Start(); }
            _token += 1;
            UpdateStats();
        };
        
        _timer = new Timer();
        _timer.WaitTime = Values[2];
        _timer.Timeout += delegate
        {
            _token -= 1;
            if (_token == 0) { _timer.Stop(); }
            UpdateStats();
        };
        
        Target.AddChild(_timer);
        
        UpdateStats();
    }

    // TODO: 如果给 Shooter 加换了武器就没了，所以换武器的时候写个继承
    private void UpdateStats()
    {
        Target.Stats.ShootKnockBack.RemoveAllModifiersFromSource(this);
        Target.Stats.ShootSpeed.RemoveAllModifiersFromSource(this);
     
        if (_token == 0) return;
        
        _addKnockBack = Math.Min(Values[1], _token * Values[0]);
        _addShootSpeed = Math.Min(Values[1], _token * Values[0]);
        
        AddModifierToTarget(new StatModifier(
            _addKnockBack, StatModType.PercentAdd), Target.Stats.ShootKnockBack);
        
        AddModifierToTarget(new StatModifier(
            -_addShootSpeed, StatModType.PercentAdd), Target.Stats.ShootSpeed);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _timer.Stop();
        _timer.QueueFree();
    }
}