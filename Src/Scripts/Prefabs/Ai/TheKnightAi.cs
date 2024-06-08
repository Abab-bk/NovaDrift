using Godot;
using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using GTweens.Builders;
using GTweens.Easings;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class TheKnightAi : MobAiComponent
{
    [Export] private Marker2D _swordMarker;
    [Export] private Marker2D _frontMarker;
    
    private enum Abilities
    {
        Sword,
        Poet,
        Sprint,
    }
    
    private enum Magics
    {
        Fireball,
        Freezy,
        Call,
    }
    
    private Timer _walkingTimer;

    private const float SwordAtkDistance = 100f;
    private const float PoetAtkDistance = 100f;
    private const float SprintAtkDistance = 100f;
    
    public override void _Ready()
    {
        base._Ready();
        Mob.IsBoss = true;
        
        _walkingTimer = new Timer()
        {
            OneShot = true
        };
        
        Mob.CallDeferred(Node.MethodName.AddChild, _walkingTimer);
        
        _walkingTimer.Timeout += () =>
        {
            switch (SelectAbility())
            {
                case Abilities.Sword:
                    Machine.SetTrigger("ToSword");
                    break;
                case Abilities.Poet:
                    Machine.SetTrigger("ToPoet");
                    break;
                case Abilities.Sprint:
                    Machine.SetTrigger("ToSprint");
                    break;
            }
        };
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Walking":
                if (Mob.GetDistanceToPlayer() <= 600)
                {
                    Mob.CleanTarget();
                    Mob.Velocity = Vector2.Zero;
                    return;
                }
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
            case "Sprint":
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Walking":
                _walkingTimer.WaitTime = Random.Shared.FloatRange(2f, 4f);
                _walkingTimer.Start();
                break;
            case "Sword":
                Sword();
                break;
            case "Sprint":
                Mob.LookAt(Global.Player.GlobalPosition);
                var sword = GetSwordVfx();
                Mob.AddChild(sword);
                sword.Modulate = sword.Modulate with { A = 0f };
                sword.GlobalPosition = _frontMarker.GlobalPosition;
                
                GTweenSequenceBuilder.New()
                    .Append(sword.TweenModulateAlpha(1f, 0.2f))
                    .Append(Mob.TweenGlobalPosition(Mob.GetForwardVector2(2000f), 0.6f))
                    .Append(sword.TweenModulateAlpha(0f, 0.2f))
                    .AppendCallback(() =>
                    {
                        sword.QueueFree();
                        Machine.SetTrigger("ToMoving");
                    })
                    .Build()
                    .Play();
                
                break;
        }
    }

    private void Sword()
    {
        Mob.Velocity = Vector2.Zero;
        Mob.LookAt(Global.Player.GlobalPosition);

        var sword = GetSwordVfx();
        
        Mob.AddChild(sword);
        
        sword.Modulate = sword.Modulate with { A = 0f };
        sword.GlobalPosition = _swordMarker.GlobalPosition;
        
        sword.RotationDegrees = -45f;

        GTweenSequenceBuilder.New()
            .Append(sword.TweenModulateAlpha(1f, 0.2f))
            .Append(sword.TweenRotationDegrees(45f, 0.4f))
                .Join(sword.TweenPosition(_swordMarker.Position + new Vector2(0f, 600f), 0.4f))
            .Append(sword.TweenModulateAlpha(0f, 0.2f))
            .AppendCallback(() =>
                {
                    sword.QueueFree();
                    Machine.SetTrigger("ToMoving");
                }
            )
            .Build()
            .Play();
    }

    private SwordVfx GetSwordVfx()
    {
        var sword = GD.Load<PackedScene>("res://Scenes/Vfx/SwordVfx.tscn").Instantiate<SwordVfx>();
        sword.IsPlayer = Mob.IsPlayer;
        
        sword.Area2D.BodyEntered += (body) =>
        {
            if (body is not Player player) return;
            player.TakeDamageWithoutKnockBack(Mob.Stats.Damage.Value);
        };
        
        return sword;
    }


    private void PoetPreparation()
    {
        
    }

    private Abilities SelectAbility()
    {
        var swordScore = GetAttackScore(SwordAtkDistance);
        var poetScore = GetAttackScore(PoetAtkDistance);
        var springScore = GetAttackScore(SprintAtkDistance);
        
        var scores = new []
        {
            (Abilities.Sword, swordScore),
            (Abilities.Poet, poetScore),
            (Abilities.Sprint, springScore),
        };
        
        // return scores.MaxBy(x => x.Item2).Item1;
        return Abilities.Sprint;
    }

    private float GetAttackScore(float desiredDistance)
    {
        var distance = Mob.GetDistanceToPlayer();
        var distanceDifference = Mathf.Abs(desiredDistance - distance);
        var closeness = 1 - distanceDifference;
        return Mathf.Clamp(closeness, 0f, 1f);
    }
}
