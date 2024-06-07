using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;
using Array = Godot.Collections.Array;
using Attribute = NovaDrift.addons.AcidStats.Attribute;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class BaseShield : Node2D
{
    public event Action OnCharge;
    public event Action OnActive;
    public event Action OnBreak;
    public event Action<Node2D> OnHurtEvent;
    public Func<float, float> LimitMaxValue = null; 
    
    protected CircleSprite2D CircleSprite2D;
    protected Area2D ShieldArea;
    protected PureHurtBox HurtBox;
    protected Timer CoolDownTimer;
    
    public Shield Shield;
    public Actor Target;
    public List<float> Values;
    public Attribute Health = new Attribute(0, 100);
    public float CoolDown = 6.5f;

    public Array<Node2D> GetTargetsInRange()
    {
        return ShieldArea.GetOverlappingBodies();
    }

    public float GetCooldownRatio()
    {
        return 1f - (CoolDownTimer.TimeLeft != 0 ? (float)CoolDownTimer.TimeLeft / CoolDown : 0f);
    }

    public override void _Ready()
    {
        CircleSprite2D = GetNode("%CircleSprite2D") as CircleSprite2D;
        HurtBox = GetNode("%PureHurtBox") as PureHurtBox;
        ShieldArea = GetNode<Area2D>("%ShieldArea");
        
        if (CircleSprite2D == null) throw new Exception("CirCleSprite2D 为 Null");
        if (HurtBox == null) throw new Exception("HurtBox 为 Null");
        if (ShieldArea == null) throw new Exception("ShieldArea 为 Null");

        CoolDownTimer = new Timer
        {
            WaitTime = CoolDown,
            OneShot = true,
        };
        
        AddChild(CoolDownTimer);
        
        Target.Stats.ShieldRadius.ValueChanged += UpdateRadius;
        UpdateRadius(Target.Stats.ShieldRadius.Value);
        
        ShieldArea.BodyEntered += OnBodyEntered;
        ShieldArea.BodyExited += OnBodyExited;
        ShieldArea.AreaEntered += OnAreaEntered;
        ShieldArea.AreaExited += OnAreaExited;
        
        HurtBox.OnHurt += OnHurt;
        CoolDownTimer.Timeout += OnCoolDownTimeout;
    
        Init();
        
        Active();
    }

    public void TakeDamage(float value, Node2D source)
    {
        OnHurt(value, source);
    }

    protected virtual void Init()
    {
    }

    protected virtual void OnHurt(float value, Node2D node2D)
    {
        var realValue = LimitMaxValue?.Invoke(value) ?? value;
        Health.Decrease(realValue);
        OnHurtEvent?.Invoke(node2D);

        if (Health.BaseValue <= 0)
        {
            Hide();
            OnBreak?.Invoke();
            Break();
        }
        
        CoolDownTimer.Stop();
        CoolDownTimer.Start();
    }

    protected virtual void Break()
    {
        ShieldArea.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Disabled);
        HurtBox.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Disabled);
        OnCharge?.Invoke();
    }

    protected virtual void Active()
    {
        OnActive?.Invoke();
    }

    protected virtual void OnCoolDownTimeout()
    {
        Show();
        Health.Replenish();
        ShieldArea.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Inherit);
        HurtBox.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Inherit);
        Active();
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
}
