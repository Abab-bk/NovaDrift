using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Effects;

public class Discharge : Effect
{
    private ElectricArc _arc;
    
    // Note: Shield Power should affect arc width.
    public override void OnCreate()
    {
        base.OnCreate();

        Target.OnShooting += () =>
        {
            Target.Shield.TakeDamage(Target.Stats.Damage.Value * Values[1], Target);
            if (_arc != null) return;
            CreateArc();
        };
        Target.StopShooting += DestroyArc;
        
        // Target.Stats.ShieldRadius.ValueChanged += f => { ReCalculateArc(); };
        // Target.Stats.ShieldPower.ValueChanged += f => { ReCalculateArc(); };
    }

    private void CreateArc()
    {
        var arc = GD.Load<PackedScene>("res://Scenes/Vfx/ElectricArc.tscn").Instantiate() as ElectricArc;
        if (arc == null) return;
        arc.IsPlayer = true;
        _arc = arc;
        Target.AddChild(arc);
        ReCalculateArc();
        arc.OnBodyEntered += TakeDamage;
    }
    
    private void DestroyArc()
    {
        if (_arc == null) return;
        _arc.OnBodyEntered -= TakeDamage;
        _arc.QueueFree();
        _arc = null;
    }

    private void TakeDamage(Node2D body)
    {
        if (body is not MobBase mobBase) return;
        mobBase.TakeDamageWithoutKnockBack(Target.Stats.Damage.Value * Values[0]);
    }

    private void ReCalculateArc()
    {
        if (_arc == null) return;
        _arc.Radius = Target.Stats.ShieldRadius.Value * (1f + Target.Stats.ShieldPower.Value);
    }
}