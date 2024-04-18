using AcidJoystick;
using AcidWallStudio.AcidUtilities;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    public Joystick JoystickNode;
    
    public override void _Ready()
    {
        base._Ready();
        Global.Player = this;

        Global.OnMobDied += @base =>
        {
            Stats.Exp.Increase(50);
            UpdateUi();
        };
        Stats.Health.ValueChanged += (float value) =>
        {
            UpdateUi();
            if (value <= 0)
            {
                Die();
            }
        };
        
        UpdateUi();
    }

    protected override void InitStats()
    {
        Stats.SetDamage(10f).
            SetHealth(300f).
            SetSpeed(600f);

        Stats.Exp.ValueToMax += UpLevel;
        Stats.Exp.ValueChanged += UpdateUi;
        Stats.Health.ValueChanged += UpdateUi;
    }

    public override void Die()
    {
        Global.OnPlayerDead?.Invoke();
        Global.OnGameOver?.Invoke();
    }

    private void UpLevel(float value)
    {
        Stats.Exp.Clear();
        Stats.Exp.MaxValue.BaseValue += 100;
        UpdateUi();

        Global.OnPlayerUpLevel(Stats.Level);
    }

    private void UpdateUi(float value = 0)
    {
        UiManager.Get_Hud_Instance()[0].UpdateExpBar(Stats.Exp.BaseValue / Stats.Exp.MaxValue.Value);
        UiManager.Get_Hud_Instance()[0].UpdateHpBar(Stats.Health.BaseValue / Stats.Health.MaxValue.Value);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();

        if (Global.CurrentPlatform == GamePlatform.Desktop)
        {
            Rotation = RotationTo(GlobalPosition.AngleToPoint(mousePos), delta);
            if (Input.IsActionPressed("Click"))
            {
                if (GlobalPosition.DirectionTo(mousePos) != Vector2.Zero)
                {
                    TryMoveTo(GlobalPosition.DirectionTo(mousePos), delta);
                }
            }
            else
            {
                TryStop(delta);
            }
        }
        else
        {
            Rotation = RotationTo(JoystickNode.TargetPos.Angle(), delta);
            if (JoystickNode.TargetPos != Vector2.Zero)
            {
                TryMoveTo(JoystickNode.TargetPos, delta);
            }
            else
            {
                TryStop(delta);
            }
        }

        MoveAndSlide();

        if (Input.IsActionPressed("RClick"))
        {
            Shoot(GlobalPosition.DirectionTo(mousePos));
            IsShooting = true;
        }
        else
        {
            IsShooting = false;
        }
    }
}
