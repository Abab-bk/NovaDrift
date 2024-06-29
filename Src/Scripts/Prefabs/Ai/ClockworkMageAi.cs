using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class ClockworkMageAi : MobAiComponent
{
    [Export] private DragonController _dragonController;
    [Export] private Node2D _laserPoints;

    public override void _Ready()
    {
        base._Ready();
        Mob.DragonController = _dragonController;
        Mob.Tags.Add(Constants.Tags.IsDragonBone);
    }
    
    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Walking":
                _dragonController.Play("Idle");
                break;
            case "Magic":
                CreateMagics();
                break;
            case "Laser":
                foreach (var point in _laserPoints.GetChildren())
                {
                    if (point is not Marker2D marker) continue;
                    var laser = GD.Load<PackedScene>("res://Scenes/Vfx/LaserBeam.tscn").Instantiate<LaserBeam>();
                    laser.Life = 5f;
                    laser.Width = 70f;
                    
                    laser.OnHitSomething += o =>
                    {
                        if (o is not Player player) return;
                        player.TakeDamage(Mob.Stats.Damage.Value * 0.1f);
                    };
                    laser.OnAnimationEnd += () =>
                    {
                        Machine.SetTrigger("GoToWalking");
                    };
                    
                    _laserPoints.AddChild(laser);
                    laser.LookAt(marker.GlobalPosition);
                    laser.GlobalPosition = marker.GlobalPosition;
                }
                break;
        }
    }

    private async void CreateMagics()
    {
        for (int i = 0; i < 5; i++)
        {
            var magicCircle = GD.Load<PackedScene>("res://Scenes/Vfx/MagicCircleVfx.tscn")
                .Instantiate<MagicCircleVfx>();
            magicCircle.IsPlayer = false;
            magicCircle.Duration = 0.5f;
            magicCircle.GlobalPosition = Global.Player.GlobalPosition;
            AddChild(magicCircle);

            magicCircle.OnAppearEnd += () =>
            {
                if (magicCircle.GetOverlayBodies().Contains(Global.Player))
                {
                    Global.Player.TakeDamageWithoutKnockBack(Mob.Stats.Damage.Value);
                }
                magicCircle.Disappear();
            };

            magicCircle.Appear();
            
            await ToSignal(GetTree().CreateTimer(0.5f), Timer.SignalName.Timeout);
        }
        Machine.SetTrigger("GoToLaser");
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Walking":
                _dragonController.Play("Idle");
                Mob.SetTargetAndMove(Global.Player, delta);
                if (Mob.GetDistanceToPlayer() > 600f) break;
                Machine.SetTrigger("GoToMagic");
                break;
            case "Magic":
                Mob.TryStop(delta);
                break;
            case "Laser":
                Mob.TryStop(delta);
                // _laserPoints.Rotation = Mathf.LerpAngle(Mathf.DegToRad(0f), Mathf.DegToRad(360f), delta);
                _laserPoints.RotationDegrees += 1f;
                break;
        }
    }
}
