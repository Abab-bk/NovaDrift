using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs;

[GlobalClass]
public partial class MobAiComponent : Node
{
    [Export] private bool _enabled = true;
    [Export] private MobBase _mob;
    private HFSM _stateMachine;

    public override void _Ready()
    {
        if (!_enabled) return;
        
        _stateMachine = HFSMUtils.TryConvert<HFSM>(GetNode("%HFSM"));
        if (_stateMachine == null) return;

        _stateMachine.Entered += _ConnectEnteredSignals;
        _stateMachine.Exited += _ConnectExitedSignals;
        _stateMachine.PhysicUpdated += _ConnectProcessSignals;
        _stateMachine.Transited += _ConnectTransitedSignals;
    }

    protected virtual void _ConnectTransitedSignals(State from, State to)
    {
    }

    protected virtual void _ConnectEnteredSignals(State state)
    {
        if (state == null) return;
        switch (state.GetName())
        {
            case "Idle": _OnIdleStateEntered(); break;
            case "GoingToPlayer": _OnGoingToPlayerStateEntered(); break;
            case "Dead": _OnDeadStateEntered(); break;
            case "Shoot": _OnShootStateEntered(); break;
        }
    }
    
    protected virtual void _ConnectExitedSignals(State state)
    {
    }
    
    protected virtual void _ConnectProcessSignals(State state, float delta)
    {
        if (state == null) return;
        switch (state.GetName())
        {
            case "Idle": _OnIdleProcess(delta); break;
            case "GoingToPlayer": _OnGoingToPlayerProcess(delta); break;
            case "Dead": _OnDeadProcess(delta); break;
            case "Shoot": _OnShootStateProcess(delta); break;
        }
    }

    protected virtual void _OnShootStateEntered()
    {
    }
    
    protected virtual void _OnShootStateProcess(float delta)
    {
        _stateMachine.SetBoolean("PlayerInShootRange", PlayerInShootRange());
        _mob.Shoot();
    }

    protected virtual void _OnIdleProcess(float delta)
    {
    }
    
    protected virtual void _OnGoingToPlayerProcess(float delta)
    {
        _stateMachine.SetBoolean("PlayerInShootRange", PlayerInShootRange());
        _mob.SetTargetAndMove(Global.Player, delta);
    }
    
    protected virtual void _OnDeadProcess(float delta)
    {
    }
    
    
    protected virtual void _OnIdleStateEntered()
    {
        _stateMachine.SetBoolean("PlayerInShootRange", PlayerInShootRange());
    }
    
    protected virtual void _OnGoingToPlayerStateEntered()
    {
    }
    
    protected virtual void _OnDeadStateEntered()
    {
    }
    
    
    protected virtual void _OnIdleStateExited()
    {
    }
    
    protected virtual void _OnRunningStateExited()
    {
    }
    
    protected virtual void _OnDeadStateExited()
    {
    }

    protected bool PlayerInShootRange()
    {
        return Global.Player.GlobalPosition.DistanceTo(_mob.GlobalPosition) < 300;
    }
}