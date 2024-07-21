using Godot;
using System;
using System.Collections.Generic;
using AcidWallStudio.Fmod;
using Godot.Collections;
using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.Pool;
using Attribute = NovaDrift.addons.AcidStats.Attribute;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class BaseShield : Node2D
{
    public event Action OnCharge;
    public event Action OnActive;
    public event Action OnBreak;
    public event Action<Node2D> OnHurtEvent;
    public event Action<Node2D> OnBodyEntered;
    public event Action<Node2D> OnBodyExited;
    
    public Func<float, float> LimitMaxValue = null; 
    
    protected CircleSprite2D CircleSprite2D;
    protected Area2D ShieldArea;
    protected PureHurtBox HurtBox;
    protected Timer CoolDownTimer;
    
    public bool IsActive;
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
        
        ShieldArea.BodyEntered += OnBodyEnteredMethod;
        ShieldArea.BodyExited += OnBodyExitedMethod;
        ShieldArea.AreaEntered += OnAreaEntered;
        ShieldArea.AreaExited += OnAreaExited;
        
        HurtBox.OnHurt += OnHurt;
        CoolDownTimer.Timeout += OnCoolDownTimeout;

        Global.Player.Modulate = new Color("a5a3ff");
        
        Active();
    }

    public void TakeDamage(float value, Node2D source)
    {
        OnHurt(value, source);
    }

    public virtual void Init()
    {
    }

    protected virtual void OnHurt(float value, Node2D node2D)
    {
        var realValue = LimitMaxValue?.Invoke(value) ?? value;
        // var shieldDamage = realValue * Target.Stats.ShieldAbsorptionRate.Value;
        // var actorDamage = realValue * (1f - Target.Stats.ShieldAbsorptionRate.Value);
        
        Health.Decrease(realValue);
        // Target.TakeDamage(actorDamage);
        
        OnHurtEvent?.Invoke(node2D);

        var vfx = Pool.BounceVfxPool.Get();
        vfx.GlobalPosition = GlobalPosition;
        vfx.Rotation = -Rotation;
        vfx.Modulate = Target.Modulate;
        vfx.Emitting = true;
        
        if (Health.BaseValue <= 0) Break();
    }

    protected virtual void Break()
    {
        OnBreak?.Invoke();
        IsActive = false;

        SoundManager.PlaySound("event:/Something/ShieldBreak");
        
        var tween = CreateTween();
        tween.TweenProperty(this, "modulate", Modulate with { A = 0f }, 0.2f);
        tween.Finished += Hide;
        
        ShieldArea.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Disabled);
        HurtBox.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Disabled);
        
        OnCharge?.Invoke();
        
        CoolDownTimer.Stop();
        CoolDownTimer.Start();
    }

    protected virtual void Active()
    {
        IsActive = true;
        
        Show();
        var tween = CreateTween();
        tween.TweenProperty(this, "modulate", Modulate with { A = 1f }, 0.2f);

        SoundManager.PlayUiSound("event:/Something/ShieldActive");
        
        Health.Replenish();
        ShieldArea.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Inherit);
        HurtBox.CallDeferred(Node.MethodName.SetProcessMode, (int)ProcessModeEnum.Inherit);
        
        OnActive?.Invoke();
    }

    protected virtual void OnCoolDownTimeout()
    {
        Active();
    }

    public virtual void SetPlayerColor()
    {
    }

    protected virtual void OnAreaEntered(Area2D area)
    {
    }
    
    protected virtual void OnAreaExited(Area2D area)
    {
    }
    
    protected virtual void OnBodyEnteredMethod(Node2D body)
    {
        OnBodyEntered?.Invoke(body);
    }
    
    protected virtual void OnBodyExitedMethod(Node2D body)
    {
        OnBodyExited?.Invoke(body);
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
