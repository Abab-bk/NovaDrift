using Godot;
using System;
using AcidWallStudio.AcidUtilities;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class IncineratorBeam : Node2D
{
    public override void _Ready()
    {
        for (int i = 0; i < 5; i++)
        {
            var pos = new Vector2(
                Random.Shared.FloatRange(-600f, 600f),
                Random.Shared.FloatRange(-600f, 600f)
                );
            var trail = GD.Load<PackedScene>("res://Scenes/Vfx/RotationTrail.tscn").Instantiate<RotationTrail>();
            if (trail == null) continue;

            trail.StartPos = ToGlobal(pos);
            trail.TargetPos = GlobalPosition;
            trail.MiddlePos = trail.StartPos + (trail.TargetPos - trail.StartPos) * 10f;

            AddChild(trail);

            GTweenSequenceBuilder.New()
                .Append(trail.TweenRotationDegrees(MathF.Max(180f, trail.RotationDegrees), 1f))
                .Build()
                .Play();
        }
    }
}
