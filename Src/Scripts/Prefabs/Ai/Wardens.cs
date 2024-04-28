using Godot;
using System;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Wardens : MobAiComponent
{
    private Timer _chargeTimer;

    public override void _Ready()
    {
        base._Ready();
        _chargeTimer = new Timer
        {
            WaitTime = 2f,
            OneShot = true
        };
        AddChild(_chargeTimer);
        _chargeTimer.Timeout += () => { Machine.SetTrigger("Charged"); };
    }

    protected override void ConnectEnteredSignals(State state)
    {
        switch (state.GetName())
        {
            case "GoingToPlayer":
            {
                break;
            }
            case "Charge":
            {
                _chargeTimer.Start();
                break;
            }
            case "Attack":
            {
                Mob.Shoot();
                Machine.SetTrigger("Attacked");
                break;
            }
            case "RunAway":
            {
                break;
            }
        }
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        switch (state.GetName())
        {
            case "GoingToPlayer":
            {
                Mob.SetTargetAndMove(Global.Player, delta);
                if (Mob.GlobalPosition.DistanceTo(Global.Player.GlobalPosition) < 400)
                {
                    Mob.TryStop(delta);
                    Machine.SetTrigger("ArrivedPlayer");
                }
                break;
            }
            case "Charge":
            {
                Mob.LookAt(Global.Player.GlobalPosition);
                break;
            }
            case "Attack":
            {
                break;
            }
            case "RunAway":
            {
                Mob.SetTargetPosAndMove(new Vector2(-300, -300), delta);
                break;
            }
        }
    }
}
