using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class Mine : Node2D
{
    [Export] private PureHurtBox _hurtBox;
    [Export] protected Area2D MonitorArea;
    [Export] private Sprite2D _sprite;

    public bool IsPlayer;
    public float Health = 100f;
    public float Damage = 10f;
    public float Life = 0f;
    
    public override void _Ready()
    {
        _hurtBox.SetIsPlayer(IsPlayer);
        MonitorArea.SetIsPlayer(IsPlayer);
        
        _hurtBox.OnHurt += (value, _) =>
        {
            Health -= value;

            if (Health <= 0)
            {
                QueueFree();
            }
        };

        ConnectMonitorArea();
        
        if (Life <= 0) return;
        var timer = new Timer
        {
            WaitTime = Life
        };
        timer.Timeout += QueueFree;

        AddChild(timer);
        timer.Start();
    }

    protected virtual void ConnectMonitorArea()
    {
        MonitorArea.BodyEntered += body =>
        {
            if (IsPlayer)
            {
                if (body is not MobBase mobBase) return;
                mobBase.TakeDamage(Damage);
                QueueFree();
                return;
            }
            if (body is not Player player) return;
            player.TakeDamage(Damage);
            QueueFree();
        };
    }
}
