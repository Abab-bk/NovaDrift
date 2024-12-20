using System;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using FMOD;
using FMOD.Studio;
using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class MathematiciansAi : MobAiComponent
{
    private Bank _bank;
    private Node2D _mapCorner;

    public override async void _Ready()
    {
        base._Ready();
        Mob.IsBoss = true;
        await ToSignal(Owner, Node.SignalName.Ready);
        SetMapCorner();
        SoundManager.LoadBank("Mathematicians.bank", out _bank);
    }

    protected override void OnMobDied()
    {
        _bank.unload();
        _mapCorner.QueueFree();
        base.OnMobDied();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "MovingToCenter":
                Mob.SetTargetPosAndMove(SpawnPoint.GetPoint(Constants.Points.Center), delta);
                if (Mob.GlobalPosition.DistanceTo(Wizard.GetScreenCenter()) <= 40)
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
                Mob.SetTargetAndMove(_mapCorner, delta);
                if (Mob.GlobalPosition.DistanceTo(_mapCorner.GlobalPosition) <= 40)
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
                            Machine.SetTrigger("Beam"); // TODO: Add beam behavior.
                            break;
                    }
                }
                break;
            case "Blink":
                Mob.TryStop(delta);
                break;
            case "CreateBlackHole":
                Mob.TryStop(delta);
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "MovingToCenter":
                SoundManager.PlaySound("event:/Mobs/Bosses/Mathematicians/Moving");
                break;
            
            case "Shoot":
                SoundManager.PlaySound("event:/Mobs/Bosses/Mathematicians/Shoot");
                break;
            
            case "MovingToCorner":
                SetRandomMapCorner();
                SoundManager.PlaySound("event:/Mobs/Bosses/Mathematicians/Moving");
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
                
                SoundManager.PlaySound("event:/Mobs/Bosses/Mathematicians/CreateBlackHole");
                
                blackHole.ExceptActors.Add(Mob);
                blackHole.Life = 5;
                GetTree().Root.AddChild(blackHole);
                blackHole.GlobalPosition = Mob.GetForwardVector2(Mob.Stats.Speed.Value * 0.5f);

                blackHole.OnDead += () =>
                {
                    Machine.SetTrigger("Next");
                    blackHole.QueueFree();
                };

                blackHole.OnActorEnter += actor =>
                {
                    actor.TakeDamageWithoutKnockBack(10f);
                };

                break;
            case "Beam":
                Mob.LookAt(Global.Player.GlobalPosition);
                Mob.Shoot();
                Machine.SetTrigger("Next");
                break;
        }
    }

    private void SetMapCorner()
    {
        _mapCorner = new Node2D();
        Global.GameWorld.AddChild(_mapCorner);
        SetRandomMapCorner();
    }
    
    private void SetRandomMapCorner()
    {
        _mapCorner.GlobalPosition = SpawnPoint.GetPoint(Constants.Points.RandomCorner);
    }
}
