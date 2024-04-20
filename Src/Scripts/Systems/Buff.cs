using System;
using System.Collections.Generic;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class Buff
{
    public Actor Target;
    public int Id;
    public string Name;
    
    public event Action<Buff> OnDestroy;
    
    public float Duration;
    public float RepeatTime;
    
    private Timer _durationTimer;
    private Timer _repeatTimer;

    public List<float> Values = new List<float>();

    public virtual void OnCreate()
    {
        _durationTimer = Duration <= 0 ? _durationTimer : new Timer();
        _repeatTimer = RepeatTime <= 0 ? _repeatTimer : new Timer();

        if (_durationTimer != null)
        {
            Target.AddChild(_durationTimer);
            
            _durationTimer.WaitTime = Duration;
            _durationTimer.OneShot = true;
            _durationTimer.Timeout += Destroy;
            _durationTimer.Start();
        }

        if (_repeatTimer != null)
        {
            Target.AddChild(_repeatTimer);
            
            _repeatTimer.WaitTime = RepeatTime;
            _repeatTimer.OneShot = false;
            _repeatTimer.Timeout += Process;
            _repeatTimer.Start();
        }
    }

    protected virtual void Process()
    {
    }

    protected virtual void Destroy()
    {
        _repeatTimer.Stop();
        _durationTimer.QueueFree();
        _repeatTimer.QueueFree();
        OnDestroy?.Invoke(this);
    }
}