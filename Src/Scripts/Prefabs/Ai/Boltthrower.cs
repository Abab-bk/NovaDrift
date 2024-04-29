using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Boltthrower : MobAiComponent
{
    private Vector2 _targetPos = Vector2.Zero;
    private bool _shootDone = false;
    
    static List<Boltthrower> _boltthrowers = new();

    private Timer _chargeTimer;
    private Node2D _lightBall;

    public override void _Ready()
    {
        base._Ready();

        _lightBall = GetNode<Node2D>("%LightBall");
        
        _chargeTimer = new Timer
        {
            WaitTime = 3f,
            OneShot = true,
        };
        AddChild(_chargeTimer);
        _chargeTimer.Timeout += () =>
        {
            _lightBall.Hide();
            Mob.Shoot();
            _shootDone = true;
            Machine.SetTrigger("ShootDone");
            _boltthrowers.Remove(this);
        };
        
        _boltthrowers.Add(this);
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Shoot": Mob.LookAt(Global.Player.GlobalPosition); break;
            case "GoingToOpposite": _OnGoingToOppositeProcess(delta); break;
            case "RunAway": _OnRunAwayProcess(delta); break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Shoot":
            {
                _lightBall.Show();
                _chargeTimer.Start();
                break;
            }
        }
    }

    private void _OnRunAwayProcess(float delta)
    {
        Mob.SetTargetPosAndMove(Vector2.Right.Rotated(Mob.GlobalRotation) * 10000, delta);
    }

    private void _OnGoingToOppositeProcess(float delta)
    {
        if (_targetPos != Vector2.Zero)
        {
            if (Mob.GlobalPosition.DistanceTo(_targetPos) < 20)
            {
                if (_shootDone)
                {
                    Machine.SetTrigger("RunAway");
                    return;
                }
                Mob.Velocity = Vector2.Zero;
                Machine.SetTrigger("ArriveOpposite");
            }
            Mob.SetTargetPosAndMove(_targetPos, delta);
            return;
        }
        _targetPos = Wizard.GetMapCornerByIndex(_boltthrowers.IndexOf(this));
        
        Mob.SetTargetPosAndMove(_targetPos, delta);
    }
}