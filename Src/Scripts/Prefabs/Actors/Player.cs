using System;
using AcidJoystick;
using AcidWallStudio.Fmod;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Others;
using NovaDrift.Scripts.Prefabs.Shields;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    [GetNode("%RegenerationTimer")] private Timer _regenerationTimer;
    [GetNode("ExpBallMonitor")] private Area2D _expBallMonitor;
    [GetNode("PowerUpMonitor")] private Area2D _powerUpMonitor;

    public event Action OnCharging;
    public event Action OnStopCharging;
    
    private HFSM _movementMachine;
    private HFSM _actionMachine;

    private bool _updateShieldCooldown;
    
    public JoyKnob JoystickNode;

    // 为了 ChargedShot Ability 添加的，Hack
    public bool IsCharge = false;
    
    public override void _Ready()
    {
        base._Ready();
        Init();
        Global.Player = this;

        DataBuilder.BuildBodyById(1000).Use();
        DataBuilder.BuildWeaponById(1000).Use();
        DataBuilder.BuildShieldById(1000).Use();
        
        EventBus.OnMobDied += _ => { UpdateUi(); };
        EventBus.OnWorldColorChanged += ChangeColor;
        ChangeColor();
        
        Stats.Health.ValueChanged += value =>
        {
            UpdateUi();
            
            // Logger.Log("[Player] Player health changed: " + value);
            
            if (value <= Stats.Health.MaxValue.Value * 0.5f && (int)SoundManager.GetMusicParameter(AudioParams.Stage) != (int)BackgroundMusicStage.Stage1)
            {
                SoundManager.SetMusicParameter(AudioParams.Stage, (int)BackgroundMusicStage.Stage2);
            }
            else if (value <= Stats.Health.MaxValue.Value * 0.2f && (int)SoundManager.GetMusicParameter(AudioParams.Stage) != (int)BackgroundMusicStage.Stage3)
            {
                SoundManager.SetMusicParameter(AudioParams.Stage, (int)BackgroundMusicStage.Stage3);
            }

            if (value <= 0)
            {
                Die();
            }
        };
        
        _movementMachine = HFSMUtils.TryConvert<HFSM>(GetNode("%MovementMachine"));
        _actionMachine = HFSMUtils.TryConvert<HFSM>(GetNode("%ActionMachine"));
        if (_movementMachine == null) throw new("MovementMachine is Null");
        if (_actionMachine == null) throw new("ActionMachine is Null");
        
        _movementMachine.Entered += ConnectMovementMachineEnter;
        _actionMachine.Entered += ConnectActionMachineEnter;
        _movementMachine.PhysicUpdated += ConnectMovementMachineProcess;
        _actionMachine.PhysicUpdated += ConnectActionMachineProcess;
        
        Shield.OnCharge += () => _updateShieldCooldown = true;
        Shield.OnActive += () => _updateShieldCooldown = true;

        Scale = new Vector2(Stats.Size.Value, Stats.Size.Value);
        
        _regenerationTimer.Timeout += () =>
        {
            Stats.Health.Increase(
                Stats.Health.MaxValue.Value / 50 * Stats.Regeneration.Value);
        };
        _regenerationTimer.Start();

        _expBallMonitor.AreaEntered += area =>
        {
            if (area.Owner is not ExpBall expBall) return;
            expBall.Active();
        };
        
        _powerUpMonitor.AreaEntered += area =>
        {
            if (area.Owner is not PowerUpEntity powerUp) return;
            powerUp.Get();
        };

        Global.GameContext.SetCamera(GetNode<Node2D>("PhantomCamera2D"));
        
        UpdateUi();
    }
    
    private void ConnectMovementMachineEnter(State state)
    {
    }

    private void ConnectActionMachineEnter(State state)
    {
        switch (state.GetName())
        {
            case "Idle":
                StopShooting?.Invoke();
                break;
            case "Shooting":
                StartShooting?.Invoke();
                break;
        }
    }
    
    private void ConnectMovementMachineProcess(State state, float delta)
    {
        switch (state.GetName())
        {
            case "Idle":
                TryStop(delta);
                break;
            case "Running":
                switch (Global.CurrentPlatform)
                {
                    case GamePlatform.Desktop:
                        var mousePos = GetGlobalMousePosition();
                        if (GlobalPosition.DirectionTo(mousePos) != Vector2.Zero)
                        {
                            TryMoveTo(GlobalPosition.DirectionTo(mousePos), delta);
                        }
                        break;
                    case GamePlatform.Mobile:
                        TryMoveTo(JoystickNode.TargetDir, delta);
                        break;
                }
                break;
        }
    }

    private void ConnectActionMachineProcess(State state, float delta)
    {
        switch (state.GetName())
        {
            case "Shooting":
                Shoot();
                OnShooting?.Invoke();
                break;
        }
    }
    
    public void SetShield(BaseShield shield)
    {
        Shield = shield;
        Shield.Health.ValueChanged += _ =>
        {
            UpdateUi();
        };
    }

    public override void OnHit(float value)
    {
        base.OnHit(value);

        var shakeLevel = MathF.Max(10f, value / 20f);
        
        Global.Shake(shakeLevel);
    }

    protected override void InitStats()
    {
        Stats.Health.BaseValue = DataBuilder.Constants.PlayerHealth;
        Stats.Health.MaxValue.BaseValue = DataBuilder.Constants.PlayerHealth;
        Stats.Health.MaxValue.BaseValue = DataBuilder.Constants.PlayerHealth;
        
        Stats.Speed.BaseValue = DataBuilder.Constants.PlayerSpeed;
        
        Stats.ShootSpeed.BaseValue = DataBuilder.Constants.PlayerShootSpeed;
        Stats.ShootKnockBack.BaseValue = DataBuilder.Constants.PlayerKnockBack;
        Stats.ShootSpread.BaseValue = DataBuilder.Constants.PlayerShootSpread;

        Stats.Damage.BaseValue = DataBuilder.Constants.PlayerDamage;
        
        Stats.Recoil.BaseValue = DataBuilder.Constants.PlayerRecoil;
        
        Stats.Exp.BaseValue = 0;
        Stats.Exp.MaxValue.BaseValue = DataBuilder.GetNextLevelExp(Stats.Level);
        
        Stats.BulletCount.BaseValue = DataBuilder.Constants.PlayerBulletCount;
        Stats.BulletSize.BaseValue = DataBuilder.Constants.PlayerBulletSize;
        Stats.BulletSpeed.BaseValue = DataBuilder.Constants.PlayerBulletSpeed;
        Stats.BulletDegeneration.BaseValue = DataBuilder.Constants.PlayerBulletDegeneration;
        Stats.BlastDamage.BaseValue = DataBuilder.Constants.PlayerBlastDamage;
        Stats.BlastRadius.BaseValue = DataBuilder.Constants.PlayerBlastRadius;
        Stats.BurstFire.BaseValue = DataBuilder.Constants.PlayerBurstFire;
        
        Stats.MaxShield.BaseValue = DataBuilder.Constants.PlayerMaxShield;
        
        Scale = new Vector2 { X = Stats.Size.Value, Y = Stats.Size.Value };
        
        Stats.Exp.ValueToMax += UpLevel;
        Stats.Exp.ValueChanged += UpdateUi;
        Stats.Health.ValueChanged += UpdateUi;
        Stats.Size.ValueChanged += f => Scale = new Vector2 { X = f, Y = f };
    }

    public override void Die()
    {
        if (IsDead) return;
        IsDead = true;
        
        EventBus.OnPlayerDead?.Invoke();
        EventBus.OnGameOver?.Invoke();
        
        // TODO: 接入广告了再开下面的
        // if (Global.GameContext.ReliveCount > 0)
        // {
        //     EventBus.OnPlayerDead?.Invoke();
        //     EventBus.OnGameOver?.Invoke();
        //     return;
        // }
        // Global.StopGame();
        // UiManager.Open_Relife();
    }

    public void UpLevel(float value = 0f)
    {
        SoundManager.PlayUiSound("event:/UI/Uplevel");
        
        Stats.Exp.Clear();
        Stats.Exp.MaxValue.BaseValue = DataBuilder.GetNextLevelExp(Stats.Level);
        
        Stats.Health.Increase(Stats.Health.MaxValue.Value * 0.5f);
        
        UpdateUi();

        EventBus.OnPlayerUpLevel(Stats.Level);
    }

    private void UpdateUi(float value = 0)
    {
        if (UiManager.Get_Hud_Instance().Length <= 0) return;
        UiManager.Get_Hud_Instance()[0].UpdateExpBar(Stats.Exp.BaseValue / Stats.Exp.MaxValue.Value);
        UiManager.Get_Hud_Instance()[0].UpdateHpBar(Stats.Health.BaseValue / Stats.Health.MaxValue.Value);
        UiManager.Get_Hud_Instance()[0].UpdateShieldBar(Shield.Health.BaseValue / Shield.Health.MaxValue.Value);
    }

    public void RemoveSelf()
    {
        Stats.BuffSystem.RemoveAllBuffs();
        Stats.EffectSystem.RemoveAllEffects();
        Global.Player = null;
        CallDeferred(Node.MethodName.QueueFree);
    }
    
    // public override void _Input(InputEvent @event)
    // {
    //     _actionMachine.SetTrigger(Input.IsActionPressed("RClick") ? "GoToShooting" : "GoToIdle");
    //     _movementMachine.SetTrigger(Input.IsActionPressed("Click") ? "GoToRunning" : "GoToIdle");
    // }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!_updateShieldCooldown) return;
        if (UiManager.Get_Hud_Instance().Length <= 0) return;
        UiManager.Get_Hud_Instance()[0].UpdateShieldCooldownBar(Shield.GetCooldownRatio());
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();

        if (Input.IsActionPressed("RClick"))
        {
            if (IsCharge)
            {
                OnCharging?.Invoke();
            }
            else
            {
                _actionMachine.SetTrigger("GoToShooting");
            }
        }
        else
        {
            _actionMachine.SetTrigger("GoToIdle");
        }

        if (Input.IsActionJustReleased("RClick") && IsCharge) OnStopCharging?.Invoke();
        
        
        switch (Global.CurrentPlatform)
        {
            case GamePlatform.Desktop:
                Rotation = RotationTo(GlobalPosition.AngleToPoint(mousePos), delta);
                _movementMachine.SetTrigger(Input.IsActionPressed("Click") ? "GoToRunning" : "GoToIdle");
                break;
            case GamePlatform.Mobile:
                Rotation = RotationTo(JoystickNode.TargetDir.Angle(), delta);
                _movementMachine.SetTrigger(JoystickNode.IsPressed() ? "GoToRunning" : "GoToIdle");
                break;
        }
        
        base._PhysicsProcess(delta);
    }

    private Vector2 GetControllerDir()
    {
        return new Vector2(
            -Input.GetActionStrength("Left") + Input.GetActionStrength("Right"),
            +Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
        ).Normalized();
    }
}
