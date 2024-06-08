using Godot;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Systems.Effects;

public class DeadlyWake : Effect
{
    private Vector2 _lastPos = Vector2.Zero;
    
    private readonly Timer _timer = new Timer()
    {
        WaitTime = 0.1f,
    };
    
    public override void OnCreate()
    {
        base.OnCreate();
        Target.AddChild(_timer);
        
        _timer.Timeout += () =>
        {
            if (Target.GlobalPosition == _lastPos) return;
            
            var mine = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/InvisibleMine.tscn").Instantiate() as InvisibleMine;
            if (mine == null) return;
            
            mine.Life = 2f;
            mine.Damage = 120f;
            mine.IsPlayer = Target.IsPlayer;
            mine.GlobalPosition = Target.GlobalPosition;
            _lastPos = Target.GlobalPosition;
            
            Global.Something.AddChild(mine);
        };
        
        _timer.Start();
    }
}