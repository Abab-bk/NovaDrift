using System;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using FMOD.Studio;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class MathematiciansAi : MobAiComponent
{
    private Vector2 _corner;
    private Bank _bank;

    public override void _Ready()
    {
        base._Ready();
        SoundManager.LoadBank("Mathematicians.bank", out _bank);
    }

    protected override void OnMobDied()
    {
        _bank.unload();
        base.OnMobDied();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "MovingToCenter":
                Mob.SetTargetPosAndMove(Wizard.GetScreenCenter(), delta);
                if (Mob.GlobalPosition.DistanceTo(Wizard.GetScreenCenter()) <= 20)
                {
                    Machine.SetTrigger("Next");
                }
                break;
            case "Shoot":
                Mob.TryStop(delta);
                Mob.Rotate(Mathf.DegToRad(50 * delta));
                Mob.Shoot();
                break;
            case "MovingToCorner":
                Mob.SetTargetPosAndMove(_corner, delta);
                if (Mob.GlobalPosition.DistanceTo(_corner) <= 20)
                {
                    Mob.Velocity = Vector2.Zero;
                    Mob.LookAtPlayer(delta);
                    switch (Random.Shared.Next(0, 2))
                    {
                        case 0:
                            Machine.SetTrigger("Blink");
                            break;
                        case 1:
                            Machine.SetTrigger("CreateBlackHole");
                            break;
                        case 2:
                            Machine.SetTrigger("Beam");
                            break;
                    }
                }
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "MovingToCenter":
                Mob.PlaySound("event:/Mobs/Bosses/Mathematicians/Moving");
                break;
            
            case "Shoot":
                Mob.PlaySound("event:/Mobs/Bosses/Mathematicians/Shoot");
                break;
            
            case "MovingToCorner":
                Mob.PlaySound("event:/Mobs/Bosses/Mathematicians/Moving");
                _corner = Wizard.GetRandomMapCorner();
                break;
            
            case "Blink":
                Mob.LookAt(Global.Player.GlobalPosition);
                Color originalColor = Mob.Modulate;
                GTweenSequenceBuilder.New()
                    .Join(Mob.TweenModulate(new Color("ffffff00"), 0.1f))
                    .Join(Mob.TweenGlobalPosition(
                        Mob.GetForwardVector2(Mob.Stats.Speed.Value * 1.5f), 0.1f))
                    .Append(Mob.TweenModulate(originalColor, 0.1f))
                    .AppendCallback(() =>
                    {
                        Machine.SetTrigger("Next");
                    })
                    .Build()
                    .Play();
                break;
            case "CreateBlackHole":
                Mob.LookAt(Global.Player.GlobalPosition);
                var blackHole = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/BlackHole.tscn").Instantiate() as BlackHole;
                if (blackHole == null) return;
                
                Mob.PlaySound("event:/Mobs/Bosses/Mathematicians/CreateBlackHole");
                
                GetTree().Root.AddChild(blackHole);
                blackHole.GlobalPosition = Mob.GetForwardVector2(Mob.Stats.Speed.Value * 0.5f);
                
                GTweenSequenceBuilder.New()
                    .Join(blackHole.TweenRotation(360f, 5f))
                    .AppendCallback(() =>
                    {
                        Machine.SetTrigger("Next");
                        blackHole.QueueFree();
                    })
                    .Build()
                    .Play();
                
                break;
            case "Beam":
                Mob.LookAt(Global.Player.GlobalPosition);
                Mob.Shoot();
                Machine.SetTrigger("Next");
                break;
        }
    }
    
}
