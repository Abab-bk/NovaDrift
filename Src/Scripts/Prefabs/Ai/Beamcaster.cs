using System.Collections.Generic;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Beamcaster : MobAiComponent
{
    [Export] private CircleSprite2D _circleSprite;
    [Export] private Area2D _area;
    [Export] private Timer _healingTimer;
    
    private readonly Dictionary<MobBase, LineVfx> _lines = new ();
    
    public override void _Ready()
    {
        base._Ready();
        _circleSprite.UpdateRadius(200f);
        _area.BodyEntered += body =>
        {
            if (body == Mob) return;
            if (body is not MobBase mobBase) return;
            if (mobBase.Ai is Beamcaster) return;

            var lineVfx = new LineVfx();
            lineVfx.Target = mobBase;
            lineVfx.Width = 10f;
            Mob.AddChild(lineVfx);
            
            _lines.Add(mobBase, lineVfx);
        };

        _area.BodyExited += body =>
        {
            if (body == Mob) return;
            if (body is not MobBase mobBase) return;
            if (mobBase.Ai is Beamcaster) return;

            if (_lines.ContainsKey(mobBase) == false) return;
            _lines[mobBase].QueueFree();
            _lines.Remove(mobBase);
        };

        _healingTimer.Timeout += () =>
        {
            foreach (var line in _lines)
            {
                line.Key.Stats.Health.Increase(line.Key.Stats.Health.MaxValue.Value * 0.015f);
            }
        };
        
        _healingTimer.Start();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Moving":
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
            case "Idle":
                Mob.TryStop(delta);
                break;
        }
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Moving":
                break;
            case "Idle":
                break;
        }
    }
}