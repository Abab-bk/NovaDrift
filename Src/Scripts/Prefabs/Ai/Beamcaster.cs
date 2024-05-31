using System;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Beamcaster : MobAiComponent
{
    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "GoingToPlayer": _OnGoingToPlayerProcess(delta); break;
            case "Shoot": _OnShootStateProcess(delta); break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Idle": _OnIdleStateEntered(); break;
        }
    }
    
    
    private void _OnShootStateProcess(float delta)
    {
        Machine.SetBoolean("PlayerInShootRange", PlayerInShootRange());
        Mob.Shoot();
        
        Mob.Velocity = (Mob.GlobalPosition - Global.Player.GlobalPosition).Normalized().Rotated(MathF.PI / 2) *
                       Mob.Stats.Speed.Value;
        Mob.Rotation = Mob.RotationTo(Mob.Velocity.Angle(), delta);
    }
    private void _OnGoingToPlayerProcess(float delta)
    {
        Machine.SetBoolean("PlayerInShootRange", PlayerInShootRange());
        Mob.SetTargetAndMove(Global.Player, delta);
    }
    
    private void _OnIdleStateEntered()
    {
        Machine.SetBoolean("PlayerInShootRange", PlayerInShootRange());
    }
}