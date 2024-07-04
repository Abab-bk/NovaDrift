using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs;

[GlobalClass]
public partial class DroneAiComponent : Node
{
    [Export] private bool _enabled = true;
    [Export] protected DroneBase Drone;
    public HFSM Machine;
    
    public override void _Ready()
    {
        if (!_enabled) return;
        
        Machine = HFSMUtils.TryConvert<HFSM>(GetNode("%HFSM"));
        if (Machine == null) return;

        Machine.Entered += ConnectEnteredSignals;
        Machine.Exited += ConnectExitedSignals;
        Machine.PhysicUpdated += ConnectProcessSignals;
        Machine.Transited += ConnectTransitedSignals;
        
        Drone.OnDied += OnMobDied;
    }

    protected virtual void OnMobDied()
    {
        Machine.Active = false;
    }

    protected virtual void ConnectTransitedSignals(State from, State to)
    {
        if (from == null || to == null) return;
    }

    protected virtual void ConnectEnteredSignals(State state)
    {
        if (state == null) return;
    }
    
    protected virtual void ConnectExitedSignals(State state)
    {
        if (state == null) return;
    }
    
    protected virtual void ConnectProcessSignals(State state, float delta)
    {
        if (state == null) return;
    }
}