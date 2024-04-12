using AcidJoystick;
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
        
        UpdateUi();
    }

    protected override void InitStats()
    {
        Stats.SetDamage(30f).
            SetHealth(300f).
            SetSpeed(300f);

        Stats.Exp.ValueToMax += UpLevel;
        Stats.Exp.ValueChanged += UpdateUi;
    }

    private void UpLevel(float value)
    {
        GD.Print("升级");
        Stats.Exp.Clear();
        Stats.Exp.MaxValue.BaseValue += 100;
        UpdateUi();

        Global.OnPlayerUpLevel(Stats.Level);
    }

    private void UpdateUi(float value = 0)
    {
        UiManager.Get_Hud_Instance()[0].UpdateExpBar(Stats.Exp.BaseValue / Stats.Exp.MaxValue.Value);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();
        LookAt(mousePos);
        
        Velocity = JoystickNode.TargetPos * Stats.Speed.Value;
        MoveAndSlide();

        if (Input.IsActionPressed("RClick"))
        {
            Shoot(GlobalPosition.DirectionTo(mousePos));
        }
    }
}
