using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Effects;

public class Distortion : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        EventBus.OnMobDied += mob =>
        {
            if (Wizard.GetChance() > Values[0]) return;
            var circleBlast = GD.Load<PackedScene>("res://Scenes/Vfx/CircleBlast.tscn").Instantiate<CircleBlast>();
            circleBlast.IsPlayer = Target.IsPlayer;
            circleBlast.Radius = 100f;
            circleBlast.GlobalPosition = mob.GlobalPosition;
            
            circleBlast.OnSomeThingHit += node2D =>
            {
                if (node2D is not MobBase mobBase) return;
                mobBase.Stats.AddBuff(DataBuilder.BuildBuffById(1004));
            };
            
            Global.GameWorld.AddChild(circleBlast);
        };
    }
}