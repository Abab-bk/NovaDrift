using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Boltthrower : MobAiComponent
{
    private Vector2 _targetPos = Vector2.Zero;
    private bool _shootDone = false;
    
    static List<Boltthrower> _boltthrowers = new();

    public override void _Ready()
    {
        base._Ready();
        Mob.OnShoot += @base => { 
            Machine.SetTrigger("ShootDone");
            _shootDone = true;
        };
        Mob.OnDied += () => _boltthrowers.Remove(this);
        _boltthrowers.Add(this);
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Shoot": _OnShootStateProcess(delta); break;
            case "GoingToOpposite": _OnGoingToOppositeProcess(delta); break;
            case "RunAway": _OnRunAwayProcess(delta); break;
        }
    }

    private void _OnRunAwayProcess(float delta)
    {
        Mob.SetTargetPosAndMove(Vector2.Right.Rotated(Mob.GlobalRotation) * 10000, delta);
    }

    private void _OnShootStateProcess(float delta)
    {
        // 面向对面
        // Mob.LookAt(GetOppositePos());
        Mob.Shoot();
    }

    private void _OnGoingToOppositeProcess(float delta)
    {
        if (_targetPos != Vector2.Zero)
        {
            if (Mob.GlobalPosition.DistanceTo(_targetPos) < 20)
            {
                if (_shootDone) { Machine.SetTrigger("RunAway"); }

                Machine.SetTrigger("ArriveOpposite");
            }
            Mob.SetTargetPosAndMove(_targetPos, delta);
            return;
        }
        _targetPos = Wizard.GetMapCornerByIndex(_boltthrowers.IndexOf(this));
        GD.Print(_targetPos);
        Mob.SetTargetPosAndMove(_targetPos, delta);
    }
}