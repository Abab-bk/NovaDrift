using Godot;
using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using FMOD.Studio;
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
    
    private readonly Strategy[] _abilities = [
        new Strategy("Sword", 300f, @base => { @base.Ai.Machine.SetTrigger("ToSword"); }),
        new Strategy("Poet", 1000f, @base => { @base.Ai.Machine.SetTrigger("ToPoet"); }),
        new Strategy("Sprint", 600f, @base => { @base.Ai.Machine.SetTrigger("ToSprint"); }),
    ];

    private readonly Strategy[] _magics =
    [
        new Strategy("Fireball", 400f, @base =>
        {
            @base.Ai.Machine.SetTrigger("ToFireBall");
            Logger.Log("[Boss: The Knight] Fireball selected");
        }),
        new Strategy("Freezy", 800f, @base =>
        {
            @base.Ai.Machine.SetTrigger("ToFreezy");
            Logger.Log("[Boss: The Knight] Freezy selected");
        }),
        new Strategy("Call", 200f, @base =>
        {
            @base.Ai.Machine.SetTrigger("ToCall");
            Logger.Log("[Boss: The Knight] Call selected");
        }),
    ];
    
    private MagicCircleVfx _magicCircleVfx;
    
    private Bank _bank;
    
    public override void _Ready()
    {
        base._Ready();
        SoundManager.LoadBank("TheKnight.bank", out _bank);
        Mob.IsBoss = true;
        Mob.Shooter.GetBulletFunc = _ => new BulletBuilder()
            .SetBulletBase("res://Scenes/Prefabs/Bullets/FireBall2.tscn")
            .SetOwner(Mob)
            .SetIsPlayer(Mob.IsPlayer)
            .SetDamage(Mob.Stats.Damage.Value)
            .SetSpeed(Mob.Stats.BulletSpeed.Value)
            .SetSize(Mob.Stats.BulletSize.Value)
            .SetDegeneration(Mob.Stats.BulletDegeneration.Value)
            .SetSteering(Mob.Stats.Targeting.Value)
            .Build();
    }

    protected override void OnMobDied()
    {
        base.OnMobDied();
        _bank.unload();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "FireBall":
                Mob.Velocity = Vector2.Zero;
                Mob.LookAtPlayer(delta);
                Mob.Shoot();
                break;
            case "Freezy":
                Mob.Velocity = Vector2.Zero;
                Mob.LookAtPlayer(delta);
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Walking":
                JumpTo(Global.Player.GlobalPosition + Wizard.GetRandom8Dir() * 600f);
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
            case "Freezy":
                var laser = GD.Load<PackedScene>("res://Scenes/Vfx/LaserBeam.tscn").Instantiate() as LaserBeam;
                if (laser == null) return;
                laser.Life = Random.Shared.FloatRange(3f, 6f);
                laser.Width = 50f;
                Mob.AddChild(laser);
                laser.OnHitSomething += o =>
                {
                    if (o is not Player player) return;
                    player.TakeDamage(Mob.Stats.Damage.Value * 0.1f);
                };
                laser.OnAnimationEnd += () =>
                {
                    Machine.SetTrigger("ToPoetRecovery");
                };
                laser.GlobalPosition = _frontMarker.GlobalPosition with { X = _frontMarker.GlobalPosition.X - 200f };
                break;
            case "Call":
                Global.WaveSpawnerController.GenerateWaveWithoutWaveCountAndWithPos(_frontMarker.GlobalPosition);
                var callTimer = GetTree().CreateTimer(Random.Shared.FloatRange(3f, 5f));
                callTimer.Timeout += () =>
                {
                    Machine.SetTrigger("ToPoetRecovery");
                };
                break;
        }
    }

    private void JumpTo(Vector2 targetPos)
    {
        targetPos.X = MathF.Min(Wizard.GetMaxScreenX() - 200f, targetPos.X);
        targetPos.X = MathF.Max(200f, targetPos.X);
        targetPos.Y = MathF.Min(Wizard.GetMaxScreenY() - 200f, targetPos.Y);
        targetPos.Y = MathF.Max(200f, targetPos.Y);
        
        Logger.Log($"[Boss: The Knight] Jumping to {targetPos}");
        Mob.LookAt(targetPos);
        SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheKnight/Rora");
        GTweenSequenceBuilder.New()
            .Append(Mob.TweenRotationDegrees(-20f, 0.2f))
            .Append(Mob.TweenModulateAlpha(0f, 0.4f))
            .AppendTime(1f)
            .Append(Mob.TweenGlobalPosition(targetPos, 0.1f))
            .Append(Mob.TweenModulateAlpha(1f, 0.4f))
            .Append(Mob.TweenRotationDegrees(0f, 0.2f))
            .AppendCallback(TurnToAbility)
            .Build()
            .Play();
    }

    private void TurnToAbility()
    {
        SelectAbility().Execute(Mob);
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

        SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheKnight/SwordWave");
        GTweenSequenceBuilder.New()
            .Append(sword.TweenModulateAlpha(2f, 0.2f))
            .Append(sword.TweenRotationDegrees(45f, 0.2f))
                .Join(sword.TweenPosition(_swordMarker.Position + new Vector2(0f, 600f), 0.4f))
            .Append(sword.TweenModulateAlpha(0f, 0.4f))
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
            Global.Shake(10f);
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
            SelectMagic().Execute(Mob);
        };
        
        magicCircle.Appear();
    }

    private Strategy SelectAbility()
    {
//         Logger.Log($"""
//                     [Boss: The Knight] Scores:
//                     Sword: {swordScore}
//                     Poet: {poetScore}
//                     Spring: {springScore}
//                     """);

        var best = _abilities.MaxBy(x => x.GetAttackScore(Mob));
        return best;
    }
    
    private Strategy SelectMagic()
    {
        var best = _magics.MaxBy(x => x.GetAttackScore(Mob));
        return best;
    }
    
    private float GetAttackScore(float desiredDistance)
    {
        var distanceDifference = Math.Abs(desiredDistance - Mob.GetDistanceToPlayer());
        var normalizedDifference = distanceDifference / 10f;
        var abilityScore = 1 - normalizedDifference;
        return abilityScore;
    }
}
