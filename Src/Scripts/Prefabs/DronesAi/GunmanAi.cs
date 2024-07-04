using Godot;

namespace NovaDrift.Scripts.Prefabs.DronesAi;

public partial class GunmanAi : DroneAiComponent
{
    public override void _Ready()
    {
        base._Ready();
        Drone.GlobalPosition = Global.Player.GlobalPosition;
        Global.Player.StartShooting += () => { Machine.SetTrigger("ToShoot"); };
        Global.Player.StopShooting += () => { Machine.SetTrigger("ToRunning"); };
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Shoot":
                FollowPlayer(delta);
                Drone.Shoot();
                break;
            case "Running":
                FollowPlayer(delta);
                break;
        }
    }

    private void FollowPlayer(float delta)
    {
        // Drone.SetTargetPosAndMove(_targetPos, delta);
        if (Drone.GlobalPosition.DistanceTo(Global.Player.GlobalPosition) >= 300f)
        {
            Drone.SetTargetPosAndMove(Global.Player.GlobalPosition, delta);
        }

        Drone.Rotation = Global.Player.Rotation;
    }
}
