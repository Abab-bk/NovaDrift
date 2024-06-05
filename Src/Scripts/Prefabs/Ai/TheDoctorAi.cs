using System;
using AcidWallStudio.AcidUtilities;
using Godot;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class TheDoctorAi : MobAiComponent
{
    private Timer _shockTimer;
    private int _movePointIndex;
    
    public override async void _Ready()
    {
        base._Ready();
        await ToSignal(Owner, Node.SignalName.Ready);
        Mob.Spring.RemoveTargetPoint(Global.Player);
        SetMovePoint();

        _shockTimer = new Timer
        {
            WaitTime = 3.0,
            OneShot = true
        };
        Mob.AddChild(_shockTimer);
        _shockTimer.Timeout += () =>
        {
            _shockTimer.WaitTime = Random.Shared.Next(3, 6);
            switch (Random.Shared.Next(0, 1))
            {
                case 0:
                    Machine.SetTrigger("ToShockThepary1");
                    break;
                case 1:
                    Machine.SetTrigger("ToShockThepary2");
                    break;
            }
        };
        
        SetNewPos();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "WalkingOnEdge":
                Mob.SetTargetAndMove(MovePoint, delta);
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
                for (int i = 0; i < 4; i++)
                {
                    var damageArea = GD.Load<PackedScene>("res://Scenes/Vfx/DamageAreaIndicator.tscn").Instantiate() as DamageAreaIndicator;
                    if (damageArea == null) continue;
                    damageArea.GlobalPosition = new Vector2(0, 0 + i * 100);
                    damageArea.PreparationTime = 3f;
                    damageArea.Width = 10f;
                    AddChild(damageArea);
                    if (i == 0)
                    {
                        damageArea.OnAnimationEnd += () =>
                        {
                            Machine.SetTrigger("ToWalking");
                        };
                    }
                }
                break;
            case "ShockThepary2":
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
