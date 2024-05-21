using Godot;
using NovaDrift.Scripts.Prefabs.IDamageableObjects;

namespace NovaDrift.Scripts.Systems.Effects;

public class ReflexiveShields : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        Target.Shield.OnHurtEvent += (node) =>
        {
            var wave = new ShockWave
            {
                IsPlayer = Target.IsPlayer
            };
            wave.SetDamage(Target.Stats.BlastDamage.Value);
            Global.GameWorld.AddChild(wave);
            wave.GlobalPosition = Target.GlobalPosition;
            wave.Emit(Target.GlobalPosition.DirectionTo(node.GlobalPosition));
        };
    }
}