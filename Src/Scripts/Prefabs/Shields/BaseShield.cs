using Godot;
using System;
using System.Collections.Generic;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class BaseShield : Node2D
{
    protected CircleSprite2D CircleSprite2D;
    protected Area2D ShieldArea;
    
    public Shield Shield;
    public Actor Target;
    public List<float> Values;
    
    public override void _Ready()
    {
        CircleSprite2D = GetNode("%CircleSprite2D") as CircleSprite2D;
        if (CircleSprite2D == null) throw new Exception("CirCleSprite2D 为 Null");
        
        ShieldArea = GetNode<Area2D>("%ShieldArea");
        
        Target.Stats.ShieldRadius.ValueChanged += UpdateRadius;
        UpdateRadius(Target.Stats.ShieldRadius.Value);
        
        ShieldArea.BodyEntered += OnBodyEntered;
        ShieldArea.BodyExited += OnBodyExited;
        ShieldArea.AreaEntered += OnAreaEntered;
        ShieldArea.AreaExited += OnAreaExited;
    }

    protected virtual void OnAreaEntered(Area2D area)
    {
    }
    
    protected virtual void OnAreaExited(Area2D area)
    {
    }
    
    protected virtual void OnBodyEntered(Node2D body)
    {
    }
    
    protected virtual void OnBodyExited(Node2D body)
    {
    }

    private void UpdateRadius(float value)
    {
        CircleSprite2D.UpdateRadius(value);
        if (ShieldArea.GetChild<CollisionShape2D>(0).Shape is CircleShape2D shape)
        {
            shape.Radius = value;
        }
    }

    public virtual void Destroy()
    {
        Target.Stats.ShieldRadius.ValueChanged -= CircleSprite2D.UpdateRadius;
        QueueFree();
    }
    
    protected virtual void Charge(float delta)
    {
    }
}
