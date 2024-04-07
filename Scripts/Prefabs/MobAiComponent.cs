using Godot;
using GodotStateCharts;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Prefabs;

[GlobalClass]
public partial class MobAiComponent : Node
{
    public override void _Ready()
    {
        var idleState = StateChartState.Of(GetNode("%Idle"));
        
        idleState.Connect(StateChartState.SignalName.StateEntered, Callable.From(_OnIdleStateEntered));
        idleState.Connect(StateChartState.SignalName.StateProcessing, new Callable(this, MethodName._OnIdleProcess));
        
    }
    

    public virtual void _OnIdleProcess(float delta)
    {
        GD.Print("Mob is Idle");
    }

    public virtual void _OnRunningProcess()
    {
    }

    public virtual void _OnDeadProcess()
    {
    }
    
    
    public virtual void _OnIdleStateEntered()
    {
        GD.Print("Mob entered Idle");
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