using System;
using AcidJoystick;
using AcidWallStudio.Fmod;
using DsUi;
using DwarfImpulse;
using Godot;
using NovaDrift.Scripts.Prefabs.Shields;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    [GetNode("%RegenerationTimer")] private Timer _regenerationTimer;
    
    private HFSM _movementMachine;
    private HFSM _actionMachine;

    private bool _updateShieldCooldown;
    
    public Joystick JoystickNode;

    // private SmokeTrail _smokeTrail;
    
    public override void _Ready()
    {
        base._Ready();
        Global.Player = this;

        DataBuilder.BuildBodyById(1000).Use();
        DataBuilder.BuildWeaponById(1000).Use();
        DataBuilder.BuildShieldById(1000).Use();
        
        // _smokeTrail = GetNode<SmokeTrail>("%SmokeTrail");
        
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
                var mousePos = GetGlobalMousePosition();
                if (GlobalPosition.DirectionTo(mousePos) != Vector2.Zero)
                {
                    TryMoveTo(GlobalPosition.DirectionTo(mousePos), delta);
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

        var shakeLevel = MathF.Min(10f, value / 10f);
        
        Global.ShakeDirector.Shake(
            NoiseShake.CreateWithNoise(Global.Noise)
                .WithDuration(0.5f)
                .WithEulersAmount(new Vector3(shakeLevel, shakeLevel, 0.02f))
            );
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
        
        Scale = new Vector2 { X = Stats.Size.Value, Y = Stats.Size.Value };
        
        Stats.Exp.ValueToMax += UpLevel;
        Stats.Exp.ValueChanged += UpdateUi;
        Stats.Health.ValueChanged += UpdateUi;
        Stats.Size.ValueChanged += f => Scale = new Vector2 { X = f, Y = f };
    }

    public override void Die()
    {
        EventBus.OnPlayerDead?.Invoke();
        EventBus.OnGameOver?.Invoke();
    }

    public void UpLevel(float value = 0f)
    {
        SoundManager.PlayUiSound("event:/UI/Uplevel");
        
        Stats.Exp.Clear();
        Stats.Exp.MaxValue.BaseValue = DataBuilder.GetNextLevelExp(Stats.Level);
        
        Stats.Health.Replenish();
        
        UpdateUi();

        EventBus.OnPlayerUpLevel(Stats.Level);
    }

    private void UpdateUi(float value = 0)
    {
        if (UiManager.Get_Hud_Instance().Length <= 0) return;
        UiManager.Get_Hud_Instance()[0].UpdateExpBar(Stats.Exp.BaseValue / Stats.Exp.MaxValue.Value);
        UiManager.Get_Hud_Instance()[0].UpdateHpBar(Stats.Health.BaseValue / Stats.Health.MaxValue.Value);
    }

    public void RemoveSelf()
    {
        Stats.BuffSystem.RemoveAllBuffs();
        Stats.EffectSystem.RemoveAllEffects();
        Global.Player = null;
        CallDeferred(Node.MethodName.QueueFree);
    }
    
    public override void _Input(InputEvent @event)
    {
        _movementMachine.SetTrigger(Input.IsActionPressed("Click") ? "GoToRunning" : "GoToIdle");
        _actionMachine.SetTrigger(Input.IsActionPressed("RClick") ? "GoToShooting" : "GoToIdle");
    }

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

        if (Global.CurrentPlatform == GamePlatform.Desktop)
        {
            Rotation = RotationTo(GlobalPosition.AngleToPoint(mousePos), delta);
        }
        else
        {
            Rotation = RotationTo(JoystickNode.TargetPos.Angle(), delta);
            if (JoystickNode.TargetPos != Vector2.Zero)
            {
                TryMoveTo(JoystickNode.TargetPos, delta);
                // _smokeTrail.AddAgePoint(GlobalPosition);
            }
            else
            {
                TryStop(delta);
            }
        }
        
        base._PhysicsProcess(delta);
    }
}
