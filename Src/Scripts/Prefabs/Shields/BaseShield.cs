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

    public Shield Shield;
    public Actor Target;
    public List<float> Values;
    
    public override void _Ready()
    {
        CircleSprite2D = GetNode("%CircleSprite2D") as CircleSprite2D;
        if (CircleSprite2D == null) throw new Exception("CirCleSprite2D 为 Null");
        
        Target.Stats.ShieldRadius.ValueChanged += CircleSprite2D.UpdateRadius;
        CircleSprite2D.UpdateRadius(Target.Stats.ShieldRadius.Value);
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
