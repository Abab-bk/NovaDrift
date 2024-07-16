using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Swallow : MobAiComponent
{
    private Vector2 _target;
    private Vector2 _leftPoint;
    private Vector2 _rightPoint;
    private float _padding = 40f;

    public override void Active()
    {
        base.Active();
        _leftPoint = SpawnPoint.GetPoint(Constants.Points.RandomLeft);
        _rightPoint = SpawnPoint.GetPoint(Constants.Points.RandomRight);

        _leftPoint.X += _padding;
        _rightPoint.X -= _padding;
        
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
            // 在右侧，往左走
            _target = _leftPoint;
            return;
        }

        // 在左侧，往右走
        _target = _rightPoint;
    }
}
