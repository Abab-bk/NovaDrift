﻿using Godot;
using GodotStateCharts;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs;

[GlobalClass]
public partial class MobAiComponent : Node
{
    [Export] private MobBase _mob;
    private StateChart _stateChart;
    
    public override void _Ready()
    {;
        var stateChartNode = GetNode("%MobAiStateChart");
        _stateChart = StateChart.Of(stateChartNode);
        
        var idleState = StateChartState.Of(GetNode("%Idle"));
        var runningState = StateChartState.Of(GetNode("%Running"));
        
        idleState.Connect(StateChartState.SignalName.StateEntered, Callable.From(_OnIdleStateEntered));
        idleState.Connect(StateChartState.SignalName.StateProcessing, new Callable(this, MethodName._OnIdleProcess));
        
        runningState.Connect(StateChartState.SignalName.StateEntered, Callable.From(_OnRunningStateEntered));
        runningState.Connect(StateChartState.SignalName.StateProcessing, new Callable(this, MethodName._OnRunningProcess));
    }
    

    public virtual void _OnIdleProcess(float delta)
    {
        GD.Print("Mob is Idle");
    }

    public virtual void _OnRunningProcess(float delta)
    {
        _mob.SetTargetAndMove(Global.Player);
    }

    public virtual void _OnDeadProcess(float delta)
    {
    }
    
    
    public virtual void _OnIdleStateEntered()
    {
        GD.Print("Mob entered Idle");
        _stateChart.CallDeferred("send_event", "ToRunning");
    }

    public virtual void _OnRunningStateEntered()
    {
    }

    public virtual void _OnDeadStateEntered()
    {
    }


    public virtual void _OnIdleStateExited()
    {
    }

    public virtual void _OnRunningStateExited()
    {
    }

    public virtual void _OnDeadStateExited()
    {
    }
}