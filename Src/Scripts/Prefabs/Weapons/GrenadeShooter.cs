using System;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Bullets;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Others;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class GrenadeShooter : Shooter
{
    private PackedScene _mine = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/NormalMine.tscn");
    
    public override void Init()
    {
        base.Init();

        OnShoot += bullet =>
        {
            if (bullet is not Grenade grenade) return;
            grenade.OnBlast += pos =>
            {
                for (int i = 0; i < 3; i++)
                {
                    var mine = _mine.Instantiate<Mine>();
                    mine.RotationDegrees = Random.Shared.FloatRange(-360f, 360f);
                    mine.IsPlayer = true;
                    mine.GlobalPosition = pos + new Vector2(
                        Random.Shared.FloatRange(-Actor.Stats.BlastRadius.Value, Actor.Stats.BlastRadius.Value),
                        Random.Shared.FloatRange(-Actor.Stats.BlastRadius.Value, Actor.Stats.BlastRadius.Value)
                        );
                    mine.Life = 5f;
                    Global.GameWorld.CallDeferred(Node.MethodName.AddChild, mine);
                }
            };
        };
    }

    public override void SetShootCd(float value)
    {
        base.SetShootCd(ClampShootCd(value * 4f));
    }

    public override void _Ready()
    {
        GetBulletFunc = _ => new BulletBuilder(BulletBuilder.BulletType.Grenade)
            .SetIsPlayer(IsPlayer)
            .SetOwner(Actor)
            .SetDamage(Actor.Stats.Damage.Value)
            .SetDegeneration(Actor.Stats.BulletDegeneration.Value)
            .SetSize(Actor.Stats.Size.Value)
            .SetSpeed(Actor.Stats.BulletSpeed.Value * 0.5f)
            .SetSteering(Actor.Stats.Targeting.Value)
            .Build();
        Init();
    }
}
