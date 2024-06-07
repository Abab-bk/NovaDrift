using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class BreakableItem : Node2D
{
    public event Action OnBreak;
    
    public float Health = 100f;
    public bool IsPlayer;
    
    [GetNode("Sprite2D")] private Sprite2D _sprite2D;
    private PureHurtBox _pureHurtBox;

    public override void _Ready()
    {
        _pureHurtBox = GetNode("PureHurtBox") as PureHurtBox;
        if (_pureHurtBox == null) return;
        
        _pureHurtBox.SetIsPlayer(IsPlayer);
        _pureHurtBox.OnHurt += (value, _) =>
        {
            Health -= value;
            if (Health > 0) return;
            
            OnBreak?.Invoke();
            QueueFree();
        };
    }
}
