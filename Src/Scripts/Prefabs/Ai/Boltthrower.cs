using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Boltthrower : MobAiComponent
{
    private Vector2 _targetPos = Vector2.Zero;
    private bool _shootDone = false;

    public override void _Ready()
    {
        base._Ready();
        Mob.OnShoot += @base => { 
            Machine.SetTrigger("ShootDone");
            _shootDone = true;
        };
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
        Mob.SetTargetPosAndMove(Wizard.ReverseVectorX(GetOppositePos()) + new Vector2(-GetOppositePos().X, 0), delta);
    }

    private void _OnShootStateProcess(float delta)
    {
        // 面向对面
        Mob.LookAt(GetOppositePos());
        Mob.Shoot();
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
                }

                Machine.SetTrigger("ArriveOpposite");
            }
            Mob.SetTargetPosAndMove(_targetPos, delta);
            return;
        }
        _targetPos = GetOppositePos();
        Mob.SetTargetPosAndMove(_targetPos, delta);
    }

    private Vector2 GetOppositePos()
    {
        Vector2 targetPos = new Vector2();
        if (Mob.GlobalPosition.X >= (float)DisplayServer.WindowGetSize().X / 2)
        {
            // 目前在右边，移动到左边
            targetPos.X = 100;
        } 
        else if (Mob.GlobalPosition.X <= (float)DisplayServer.WindowGetSize().X / 2)
        {
            // 目前在左边，移动到右边
            targetPos.X = (float)DisplayServer.WindowGetSize().X - 100;
        }

        if (Mob.GlobalPosition.Y >= (float)DisplayServer.WindowGetSize().Y / 2)
        {
            // 目前在下边，移动到上边
            targetPos.Y = 100;
        }
        else if (Mob.GlobalPosition.Y <= (float)DisplayServer.WindowGetSize().Y / 2)
        {
            // 目前在上边，移动到下边
            targetPos.Y = (float)DisplayServer.WindowGetSize().Y - 100;
        }
        return targetPos;
    }
}