using Godot;
using AcidWallStudio.AcidUtilities;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.DronesAi;

public partial class CollectorAi : DroneAiComponent
{
    [GetNode("%Area2D")] private Area2D _area;
 
    private ExpBall _target;
    
    public override void _Ready()
    {
        base._Ready();
        Drone.GlobalPosition = Global.Player.GlobalPosition;
        
        _area.AreaEntered += area =>
        {
            if (area.Owner is not ExpBall expBall) return;

            expBall.Get();
            FindTarget();
        };
        
        FindTarget();
    }

    private void FindTarget()
    {
        _target = Drone.GetClosestTarget("ExpBalls") as ExpBall;
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Running":
                if (!IsInstanceValid(_target))
                {
                    FindTarget();
                    Drone.TryStop(delta);
                    break;
                }

                Drone.SetTargetPosAndMove(_target.GlobalPosition, delta);
                
                break;
        }
    }
}
