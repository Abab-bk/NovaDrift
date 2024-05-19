using AcidJoystick;
using AcidWallStudio.AcidNodes;
using AcidWallStudio.Fmod;
using DsUi;
using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Prefabs.Shields;

namespace NovaDrift.Scripts.Prefabs.Actors;

public partial class Player : Actor
{
    public Joystick JoystickNode;

    private SmokeTrail _smokeTrail;
    
    public override void _Ready()
    {
        base._Ready();
        Global.Player = this;

        DataBuilder.BuildBodyById(1000).Use();
        DataBuilder.BuildWeaponById(1000).Use();
        DataBuilder.BuildShieldById(1000).Use();
        
        _smokeTrail = GetNode<SmokeTrail>("%SmokeTrail");
        
        EventBus.OnMobDied += _ => { UpdateUi(); };
        EventBus.OnWorldColorChanged += ChangeColor;
        ChangeColor();
        
        Stats.Health.ValueChanged += (float value) =>
        {
            UpdateUi();

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
        
        UpdateUi();
    }

    public void SetShield(BaseShield shield)
    {
        Shield = shield;
        Shield.Health.ValueChanged += (float value) =>
        {
            UpdateUi();
        };
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
        Stats.Exp.Clear();
        Stats.Exp.MaxValue.BaseValue += 300;
        UpdateUi();

        EventBus.OnPlayerUpLevel(Stats.Level);
    }

    private void UpdateUi(float value = 0)
    {
        UiManager.Get_Hud_Instance()[0].UpdateExpBar(Stats.Exp.BaseValue / Stats.Exp.MaxValue.Value);
        UiManager.Get_Hud_Instance()[0].UpdateHpBar(Stats.Health.BaseValue / Stats.Health.MaxValue.Value);
        UiManager.Get_Hud_Instance()[0].UpdateShieldBar(Shield.Health.BaseValue / Shield.Health.MaxValue.Value);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();

        if (Global.CurrentPlatform == GamePlatform.Desktop)
        {
            Rotation = RotationTo(GlobalPosition.AngleToPoint(mousePos), delta);
            if (Input.IsActionPressed("Click"))
            {
                if (GlobalPosition.DirectionTo(mousePos) != Vector2.Zero)
                {
                    TryMoveTo(GlobalPosition.DirectionTo(mousePos), delta);
                    _smokeTrail.AddAgePoint(GlobalPosition);
                }
            }
            else
            {
                TryStop(delta);
            }
        }
        else
        {
            Rotation = RotationTo(JoystickNode.TargetPos.Angle(), delta);
            if (JoystickNode.TargetPos != Vector2.Zero)
            {
                TryMoveTo(JoystickNode.TargetPos, delta);
                _smokeTrail.AddAgePoint(GlobalPosition);
            }
            else
            {
                TryStop(delta);
            }
        }
        
        base._PhysicsProcess(delta);

        if (Input.IsActionPressed("RClick"))
        {
            Shoot();
            if (IsShooting)
            {
                OnShooting?.Invoke();
                return;
            }

            IsShooting = true;
            StartShooting?.Invoke();
        }
        else
        {
            if (!IsShooting) return;
            
            IsShooting = false;
            StopShooting?.Invoke();
        }
    }
}
