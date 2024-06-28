using Godot;
using System;
using NovaDrift.Scripts.Prefabs;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class ClockworkMageAi : MobAiComponent
{
    [Export] private DragonController _dragonController;

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Walking":
                _dragonController.Play("Idle");
                break;
            case "Magic":
                CreateMagics();
                break;
        }
    }

    private async void CreateMagics()
    {
        for (int i = 0; i < 5; i++)
        {
            var magicCircle = GD.Load<PackedScene>("res://Scenes/Vfx/MagicCircleVfx.tscn")
                .Instantiate<MagicCircleVfx>();
            magicCircle.Duration = 0.5f;
            magicCircle.GlobalPosition = Global.Player.GlobalPosition;
            AddChild(magicCircle);

            magicCircle.OnAnimationEnd += () =>
            {
                
            };

            magicCircle.Appear();
            
            await ToSignal(GetTree().CreateTimer(0.5f), Timer.SignalName.Timeout);
        }
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Walking":
                Mob.SetTargetAndMove(Global.Player, delta);
                if (Mob.GetDistanceToPlayer() > 300f) break;
                Machine.SetTrigger("GoToMagic");
                break;
        }
    }
}
