using System;
using System.Threading;
using System.Threading.Tasks;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using FMOD.Studio;
using Godot;
using GTweens.Extensions;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems.Buffs;
using NovaDrift.Scripts.Vfx;
using Timer = Godot.Timer;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class TheDoctorAi : MobAiComponent
{
    private Timer _shockTimer;
    private int _movePointIndex;

    private Node2D _darkClouds;
    private Bank _bank;
    
    public override async void _Ready()
    {
        base._Ready();
        await ToSignal(Owner, Node.SignalName.Ready);
        Mob.Spring.RemoveTargetPoint(Global.Player);
        SetMovePoint();

        SoundManager.LoadBank("TheDoctor.bank", out _bank);
        
        _shockTimer = new Timer
        {
            WaitTime = 3.0,
            OneShot = true
        };
        Mob.AddChild(_shockTimer);
        _shockTimer.Timeout += () =>
        {
            _shockTimer.WaitTime = Random.Shared.Next(3, 6);
            switch (Random.Shared.Next(0, 2))
            {
                case 0:
                    Machine.SetTrigger("ToShockThepary1");
                    break;
                case 1:
                    // Machine.SetTrigger("ToShockThepary2");
                    Machine.SetTrigger("ToShockThepary1");
                    break;
            }
        };
        
        SetNewPos();
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
            case "WalkingOnEdge":
                Mob.SetTargetAndMove(MovePoint, delta);
                if (Mob.Position.DistanceTo(MovePoint.GlobalPosition) < 25)
                {
                    SetNewPos();
                }

                break;
        }
    }
    
    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "WalkingOnEdge":
                SetNewPos();
                _shockTimer.Start();
                break;
            case "ShockThepary1":
                ShockThepary1();
                break;
            case "ShockThepary2":
                Mob.LookAt(Global.Player.GlobalPosition);
                for (int i = 0; i < 4; i++)
                {
                    var line = new Polyline2D();
                    Mob.AddChild(line);
                    if (i == 0)
                    {
                        line.OnAnimationEnded += () =>
                        {
                            Machine.SetTrigger("ToWalking");
                        };
                    }
                }
                
                break;
        }
    }

    private async void ShockThepary1()
    {
        await CreateDarkClouds();

        var rectCount = 4;
        var padding = 100f;
        
        Vector2 GetRectPosByIndex(int index)
        {
            return new Vector2(0, Wizard.GetMaxScreenY() / rectCount - padding);
        }
        
        async void ToWalkingFromShockThepary1()
        {
            await DestroyDarkClouds();
            Machine.SetTrigger("ToWalking");
        }
        
        for (int i = 0; i < 4; i++)
        {
            var zone =
                GD.Load<PackedScene>("res://Scenes/Vfx/RectDangerZoneIndicator.tscn").Instantiate() as
                    RectDangerZoneIndicator;
            if (zone == null) return;

            zone.IsPlayer = false;
            zone.Size = new Vector2(Wizard.GetMaxScreenX(), 400f);
            zone.Time = 2f;
            
            Global.GameWorld.AddChild(zone);

            zone.GlobalPosition = GetRectPosByIndex(i) * (i + 1);
            
            if (i == 0)
            {
                zone.OnAnimationEnd += () =>
                {
                    if (zone.Area2D.OverlapsBody(Global.Player))
                    {
                        Global.Player.TakeDamageWithoutKnockBack(Mob.Stats.Damage.Value);
                        var checkBuff = Global.Player.Stats.BuffSystem.HasBuffById(1002);
                        if (checkBuff != null && checkBuff is Madness madness)
                        {
                            madness.Strength += 1;
                            return;
                        }
                        Global.Player.Stats.AddBuff(DataBuilder.BuildBuffById(1002));
                    }

                    ToWalkingFromShockThepary1();
                };
            }
        }
    }

    private Task CreateDarkClouds()
    {
        _darkClouds = GD.Load<PackedScene>("res://Scenes/Vfx/DarkClouds.tscn").Instantiate() as Node2D;
        if (_darkClouds == null) throw new Exception("DarkClouds is null");
        
        _darkClouds.GlobalPosition = new Vector2(-300, Wizard.GetScreenCenterY());
        AddChild(_darkClouds);
        _darkClouds.RotationDegrees = 90f;

        var tw = _darkClouds.TweenGlobalPositionX(175, 2f);
        tw.Play();
        
        return tw.AwaitCompleteOrKill(new CancellationToken());
    }

    private Task DestroyDarkClouds()
    {
        var tw = _darkClouds.TweenGlobalPositionX(-175, 2f);
        tw.Play();
        return tw.AwaitCompleteOrKill(new CancellationToken());
    }

    protected override void ConnectExitedSignals(State state)
    {
        base.ConnectExitedSignals(state);
        switch (state.GetName())
        {
            case "WalkingOnEdge":
                Mob.CleanTarget();
                Mob.Velocity = Vector2.Zero;
                break;
        }
    }

    private void SetNewPos()
    {
        MovePoint.GlobalPosition = Wizard.GetMapCornerByIndex(_movePointIndex);
        _movePointIndex += 1;
        if (_movePointIndex > 3) _movePointIndex = 0;
    }
}
