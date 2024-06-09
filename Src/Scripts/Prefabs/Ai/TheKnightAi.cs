using Godot;
using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;
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
    private MagicCircleVfx _magicCircleVfx;

    private const float SwordAtkDistance = 300f;
    private const float PoetAtkDistance = 1000f;
    private const float SprintAtkDistance = 600f;
    
    private const float FireBallAtkDistance = 100f;
    private const float FreezyAtkDistance = 100f;
    private const float CallAtkDistance = 100f;
    
    public override void _Ready()
    {
        base._Ready();
        Mob.IsBoss = true;
        Mob.Shooter.GetBulletFunc = (shooter) => new BulletBuilder()
            .SetBulletBase("res://Scenes/Prefabs/Bullets/FireBall2.tscn")
            .SetOwner(Mob)
            .SetIsPlayer(Mob.IsPlayer)
            .SetDamage(Mob.Stats.Damage.Value)
            .SetSpeed(Mob.Stats.BulletSpeed.Value)
            .SetSize(Mob.Stats.BulletSize.Value)
            .SetDegeneration(Mob.Stats.BulletDegeneration.Value)
            .SetSteering(Mob.Stats.Targeting.Value)
            .Build();
        
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
            case "FireBall":
                Mob.Velocity = Vector2.Zero;
                Mob.LookAtPlayer(delta);
                Mob.Shoot();
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
            case "PoetPreparation":
                PoetPreparation();
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
            case "FireBall":
                var timer = GetTree().CreateTimer(Random.Shared.FloatRange(3f, 5f));
                timer.Timeout += () =>
                {
                    Machine.SetTrigger("ToPoetRecovery");
                };
                break;
            case "PoetRecovery":
                if (_magicCircleVfx != null)
                {
                    _magicCircleVfx.OnDisappearEnd += () =>
                    {
                        Machine.SetTrigger("ToMoving");
                    };
                    _magicCircleVfx.Disappear();
                }
                break;
        }
    }

    private void JumpTo(Vector2 targetPos)
    {
        Mob.LookAt(targetPos);
        GTweenSequenceBuilder.New()
            .Append(Mob.TweenRotationDegrees(-20f, 0.2f))
            .Append(Mob.TweenModulateAlpha(0f, 0.4f))
            .AppendTime(1f)
            .Append(Mob.TweenModulateAlpha(1f, 0.4f))
            .Append(Mob.TweenRotationDegrees(0f, 0.2f))
            .Build()
            .Play();
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
        Mob.Velocity = Vector2.Zero;
        var magicCircle = GD.Load<PackedScene>("res://Scenes/Vfx/MagicCircleVfx.tscn").Instantiate<MagicCircleVfx>();
        magicCircle.Radius = 600f;
        
        Mob.AddChild(magicCircle);
        _magicCircleVfx = magicCircle;
        
        magicCircle.OnAppearEnd += () =>
        {
            Logger.Log("[Boss: The Knight] Poet ready");
            switch (SelectMagic())
            {
                case Magics.Fireball:
                    Machine.SetTrigger("ToFireBall");
                    Logger.Log("[Boss: The Knight] Fireball selected");
                    break;
                case Magics.Freezy:
                    Machine.SetTrigger("ToFreezy");
                    Logger.Log("[Boss: The Knight] Freezy selected");
                    break;
                case Magics.Call:
                    Machine.SetTrigger("ToCall");
                    Logger.Log("[Boss: The Knight] Call selected");
                    break;
            }
        };
        
        magicCircle.Appear();
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
        
        Logger.Log($"""
                    [Boss: The Knight] Scores:
                    Sword: {swordScore}
                    Poet: {poetScore}
                    Spring: {springScore}
                    """);
        
        return scores.MaxBy(x => x.Item2).Item1;
        // return Abilities.Poet;
    }
    
    private Magics SelectMagic()
    {
        var fireballScore = GetAttackScore(FireBallAtkDistance);
        var freezyScore = GetAttackScore(FreezyAtkDistance);
        var callScore = GetAttackScore(CallAtkDistance);
        
        var scores = new []
        {
            (Magics.Fireball, fireballScore),
            (Magics.Freezy, freezyScore),
            (Magics.Call, callScore),
        };
        
        // return scores.MaxBy(x => x.Item2).Item1;
        return Magics.Fireball;
    }

    private float GetAttackScore(float desiredDistance)
    {
        var distanceDifference = Math.Abs(desiredDistance - Mob.GetDistanceToPlayer());
        var normalizedDifference = distanceDifference / 10f;
        var abilityScore = 1 - normalizedDifference;
        return abilityScore;
    }
}
