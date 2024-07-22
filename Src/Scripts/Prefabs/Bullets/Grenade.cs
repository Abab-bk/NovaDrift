using System;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.Pool;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Bullets;

public partial class Grenade : BulletBase
{
    public event Action<Vector2> OnBlast;
    
    private float _deceleration = 100f;
    private float _acceleration = 300f;
    private Vector2 _maxVelocity = new Vector2(300f, 300f);

    private Timer _timer;

    public override void _Ready()
    {
        base._Ready();
        _timer = new Timer
        {
            WaitTime = 3f,
            OneShot = true
        };
        
        AddChild(_timer);
        _timer.Start();
        
        _timer.Timeout += Blast;
    }
    
    protected override void Degenerate() { }

    protected override void OnHitHandle(Actor actor)
    {
        TakeOnHitEvent(actor);
        Blast();
    }

    protected override void OnHitOthersHandle()
    {
        Blast();
    }

    private void Blast()
    {
        var blast = Pool.BlastVfxPool.Get();
        blast.GlobalPosition = GlobalPosition;
        blast.SetBlastRadius(Target.Stats.BlastRadius.Value);
        blast.Show();
        blast.Play();
        
        OnBlast?.Invoke(GlobalPosition);
        
        QueueFree();
    }

    protected override void Move(double delta)
    {
        OnMove?.Invoke(GlobalPosition.DistanceTo(LastPosition));

        if (Velocity.Length() >= _maxVelocity.Length())
        {
            Velocity = Velocity.MoveToward(Vector2.Zero, _deceleration);
        }
        else
        {
            Velocity.MoveToward(_maxVelocity, _acceleration);
        }

        Position += Velocity * (float)delta;
        LastPosition = GlobalPosition;
    }
    
}
