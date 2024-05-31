using Godot;
using AcidWallStudio.AcidUtilities;

namespace NovaDrift.Scripts.Prefabs.Bullets;

public partial class BeamcasterBullet : BulletBase
{
    private Vector2 _targetPos = Vector2.Zero;
    private Vector2 _midPoint = Vector2.Zero;
    private float _t = 0f;
    private Vector2 _origin = Vector2.Zero;

    public float PosOffset = 600f;
    
    public override void _Ready()
    {
        _origin = GlobalPosition;
        _targetPos = this.GetForwardVector2(900f);
        _midPoint = (GlobalPosition + _targetPos) / 2;
        _midPoint.Y += PosOffset;
    }

    protected override void Move(double delta)
    {
        _t = Mathf.Min(1f, _t + (float)delta * 0.5f);
        GlobalPosition = Bezier(_origin, _midPoint, _targetPos, _t);
        Rotation = GlobalPosition.Angle();
        if (_t >= 1f) QueueFree();
    }

    private Vector2 Bezier(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        var q0 = p0.Lerp(p1, t);
        var q1 = p1.Lerp(p2, t);
        var r = q0.Lerp(q1, t);
        return r;
    }
}
