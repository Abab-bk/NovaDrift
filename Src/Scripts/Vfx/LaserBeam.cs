using System;
using AcidWallStudio.Fmod;
using FMOD.Studio;
using Godot;
using GTweens.Extensions;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class LaserBeam : BaseVfx
{
    public event Action<GodotObject> OnHitSomething;
    
    [GetNode("%Line2D")] private Line2D _line;
    [GetNode("%RayCast2D")] private RayCast2D _cast;

    public float Life = 4f;
    public float Width = 20f;

    private EventInstance _sound;
    
    public override async void _Ready()
    {
        _line.Width = 20f;
        _line.Points[1] = Vector2.Zero;
        Appear();
        await ToSignal(GetTree().CreateTimer(Life), Timer.SignalName.Timeout);
        Disappear();
    }

    public override void _ExitTree()
    {
        _sound.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void Appear()
    {
        _sound = SoundManager.PlaySound("event:/Weapons/Laser/Laser");
        GTweenExtensions.Tween(
            () => _line.Width,
            w => _line.Width = w,
            Width,
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
        _cast.ForceRaycastUpdate();

        if (_cast.IsColliding())
        {
            var collider = _cast.GetCollider();
            OnHitSomething?.Invoke(collider);
            castPoint = ToLocal(_cast.GetCollisionPoint());
        }

        _line.SetPointPosition(1, castPoint);
    }
}
