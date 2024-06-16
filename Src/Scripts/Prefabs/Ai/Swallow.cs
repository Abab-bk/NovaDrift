using System.Collections.Generic;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Swallow : MobAiComponent
{
    private Vector2 _target;
    private (float, float) _xPoses;
    private float _padding = 20f;

    public override void _Ready()
    {
        base._Ready();

        _xPoses = new()
        {
            Item1 = _padding,
            Item2 = Wizard.GetMaxScreenX() - _padding,
        };
        
        SetTargetPos();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Rush":
                Mob.SetTargetPosAndMove(_target, delta);
                if (Mob.GlobalPosition.DistanceTo(_target) <= _padding)
                {
                    SetTargetPos();
                    Machine.SetTrigger("Next");
                }
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Turn":
                Mob.Velocity = Vector2.Zero;
                SetTargetPos();
                break;
        }
    }

    private void SetTargetPos()
    {
        if (Mob.GlobalPosition.X > Wizard.GetScreenCenterX())
        {
            _target = new Vector2(_xPoses.Item1, Mob.GlobalPosition.Y);
            return;
        }
        _target = new Vector2(_xPoses.Item2, Mob.GlobalPosition.Y);
    }
}
