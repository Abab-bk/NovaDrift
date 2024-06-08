using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Effects;

public class VolatileShields : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        Target.Shield.OnBreak += () =>
        {
            var arc = GD.Load<PackedScene>("res://Scenes/Vfx/ElectricArc.tscn").Instantiate() as ElectricArc;
            if (arc == null) return;
            arc.IsPlayer = true;
            arc.Radius = Target.Stats.ShieldRadius.Value * (1f + Target.Stats.ShieldPower.Value);
            Target.AddChild(arc);
            
            var radius = Target.Stats.ShieldRadius.Value * (1f + Target.Stats.ShieldPower.Value);
            var scale = new Vector2(radius / 100f, radius / 100f);

            GTweenSequenceBuilder.New()
                .Append(arc.TweenScale(scale, 0.5f))
                .AppendTime(0.2f)
                .AppendCallback(() =>
                {
                    foreach (var body in arc.GetOverLappingBodies())
                    {
                        if (body is not MobBase mobBase) continue;
                        mobBase.TakeDamage(Values[0]);
                    }
                    arc.QueueFree();
                })
                .Build()
                .Play();
        };
        AddModifierToTarget(DataBuilder.BuildPercentAddModifier(
            Values[1]), Target.Stats.MaxShield);
    }
}