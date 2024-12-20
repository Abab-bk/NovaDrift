﻿using System;
using System.Collections.Generic;
using System.Linq;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Systems;

public class Buff
{
    public Actor Target;
    public int Id;
    public string Name;
    public string IconPath;
    
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

    public virtual void Destroy()
    {
        _repeatTimer.Stop();
        _durationTimer.QueueFree();
        _repeatTimer.QueueFree();
        RemoveFromUi();
        OnDestroy?.Invoke(this);
    }
    
    protected void RemoveFromUi()
    {
        var hud = UiManager.Get_Hud_Instance().First();
        if (hud == null) return;
        hud.RemoveBuffIcon(this);
    }

    public virtual float GetRatio()
    {
        return 0f;
    }
    
    protected virtual void ShowToUi()
    {
    }
}