using System;
using System.Threading;
using System.Threading.Tasks;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using FMOD.Studio;
using Godot;
using GTweens.Builders;
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
                    // Machine.SetTrigger("ToShockThepary1");
                    Machine.SetTrigger("ToShockThepary2");
                    break;
                case 1:
                    Machine.SetTrigger("ToShockThepary2");
                    // Machine.SetTrigger("ToShockThepary1");
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
                ShockThepary2();
                break;
        }
    }

    private void ShockThepary2()
    {
        void LineCallback(Polyline2D line, int i)
        {
            if (i == 0) Machine.SetTrigger("ToWalking");
            line.QueueFree();
        }

        Mob.LookAt(Global.Player.GlobalPosition);
        for (int i = 0; i < 8; i++)
        {
            var line = new Polyline2D();
            line.DefaultColor = new Color("7b1cf4");
            line.Width = 40f;
            Mob.AddChild(line);
            line.Area2D.SetIsPlayer(false);
            line.Modulate = new Color("7b1cf46a");

            var count = i;
            
            GTweenSequenceBuilder.New()
                .Append(line.TweenModulate(new Color("7b1cf4"), 1f).OnComplete(() =>
                {
                    // Need Play Sound
                    if (!line.Area2D.OverlapsBody(Global.Player)) return;
                    Global.Player.TakeDamageWithoutKnockBack(Mob.Stats.Damage.Value);
                }))
                .AppendTime(1.0f)
                .Append(line.TweenModulateAlpha(0f, 0.5f))
                .AppendCallback(() =>
                {
                    LineCallback(line, count);
                })
                .Build()
                .Play();
        }
    }

    private async void ShockThepary1()
    {
        await CreateDarkClouds();

        var rectCount = 4;
        var padding = 200f;
        
        Vector2 GetRectPosByIndex(int index, RectDangerZoneIndicator zone)
        {
            var pos = new Vector2(0, Wizard.GetMaxScreenY() / rectCount * (index + 1) - padding);
            pos.X = (zone.Scale * 100f / 2).X;
            return pos;
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
            zone.Size = new Vector2(Wizard.GetMaxScreenX(), 230f);
            zone.Time = 2f;
            
            Global.GameWorld.AddChild(zone);
            
            zone.GlobalPosition = GetRectPosByIndex(i, zone);
            
            zone.OnAnimationEnd += () =>
            {
                var lightning = GD.Load<PackedScene>("res://Scenes/Vfx/Lightning.tscn").Instantiate() as Lightning;
                if (lightning == null) return;

                lightning.Size = zone.Size;
                Global.GameWorld.AddChild(lightning);
                lightning.GlobalPosition = zone.GlobalPosition;
                    
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
