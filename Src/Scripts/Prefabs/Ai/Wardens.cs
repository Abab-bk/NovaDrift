using Godot;

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
        _chargeTimer.Timeout += () =>
        {
            Machine.SetTrigger("Charged");
            GetNode<Node2D>("%LightBall").Hide();
        };
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
                GetNode<Node2D>("%LightBall").Show();
                _chargeTimer.Start();
                break;
            }
            case "Attack":
            {
                Attack();
                break;
            }
            case "RunAway":
            {
                break;
            }
        }
    }

    private async void Attack()
    {
        Mob.Shoot();
        await ToSignal(GetTree(), "process_frame");
        Machine.SetTrigger("Attacked");
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
                    // Mob.TryStop(delta);
                    Mob.Velocity = Vector2.Zero;
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
                Mob.SetTargetPosAndMove(Vector2.Right.Rotated(Mob.GlobalRotation) * 10000, delta);
                break;
            }
        }
    }
}
