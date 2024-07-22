using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Effects;

public class Discharge : Effect
{
    private ElectricArc _arc;

    private readonly PackedScene _scene = GD.Load<PackedScene>("res://Scenes/Vfx/ElectricArc.tscn");
    
    public override void OnCreate()
    {
        base.OnCreate();

        Target.OnShooting += () =>
        {
            if (!Target.Shield.IsActive) return;
            Target.Shield.TakeDamage(Target.Stats.Damage.Value * Values[1], Target);
        };
        
        Target.StopShooting += DestroyArc;
        Target.StartShooting += () =>
        {
            if (!Target.Shield.IsActive) return;
            CreateArc();
        };
    }

    private void CreateArc()
    {
        var arc = _scene.Instantiate<ElectricArc>();
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