using Godot;
using GTweens.Extensions;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class LaserBeam : BaseVfx
{
    [GetNode("%Line2D")] private Line2D _line;
    [GetNode("%RayCast2D")] private RayCast2D _cast;

    public float Life = 4f;
    
    public override async void _Ready()
    {
        _line.Points[1] = Vector2.Zero;
        Appear();
        await ToSignal(GetTree().CreateTimer(Life), Timer.SignalName.Timeout);
        Disappear();
    }

    private void Appear()
    {
        GTweenExtensions.Tween(
            () => _line.Width,
            w => _line.Width = w,
            50f,
            0.2f)
            .Play();
    }

    private void Disappear()
    {
        GTweenExtensions.Tween(
            () => _line.Width,
            w => _line.Width = w,
            0f,
            0.2f)
            .OnComplete(() =>
            {
                OnAnimationEnd?.Invoke();
                QueueFree();
            })
            .Play();
    }

    public override void _PhysicsProcess(double delta)
    {
        var castPoint = _cast.TargetPosition;
        // _cast.ForceRaycastUpdate();

        // if (_cast.IsColliding())
        // {
        //     castPoint = ToLocal(_cast.GetCollisionPoint());
        // }

        _line.SetPointPosition(1, castPoint);
    }
}
