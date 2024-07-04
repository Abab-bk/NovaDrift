using Godot;

namespace NovaDrift.Scripts.Prefabs.DronesAi;

public partial class GunmanAi : DroneAiComponent
{
    public override void _Ready()
    {
        base._Ready();
        Global.Player.StartShooting += () => { Machine.SetTrigger("ToShoot"); };
        Global.Player.StopShooting += () => { Machine.SetTrigger("ToRunning"); };
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Shoot":
                Drone.TryMoveToPlayer(delta);
                Drone.Rotation = Global.Player.Rotation;
                Drone.Shoot();
                break;
            case "Running":
                Drone.TryMoveToPlayer(delta);
                Drone.Rotation = Global.Player.Rotation;
                break;
        }
    }
}
