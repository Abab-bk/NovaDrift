using Godot;
using NovaDrift.addons.AcidStats;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Systems.Effects;

public class ChargedShot : Effect
{
    private const int MaxCount = 5;
    private int _count;
    private Timer _timer;

    private readonly StatModifier
        _damageMod = new StatModifier(0f, StatModType.PercentAdd),
        _bulletSpeedMod = new StatModifier(0f, StatModType.PercentAdd),
        _bulletSizeMod = new StatModifier(0f, StatModType.PercentAdd),
        _blastRadiusMod = new StatModifier(0f, StatModType.PercentAdd),
        _accelerationMod = new StatModifier(0f, StatModType.PercentAdd);

    private FocusParticles _focusVfx;
    private PackedScene _focusVfxScene;
    
    public override void OnCreate()
    {
        base.OnCreate();

        _focusVfxScene = GD.Load<PackedScene>("res://Scenes/Vfx/FocusParticles.tscn");
        
        _timer = new Timer()
        {
            WaitTime = 1f,
            OneShot = false
        };

        _timer.Timeout += () =>
        {
            if (_count >= MaxCount) return;
            _count += 1;
            Enhance();
        };

        Global.Player.AddChild(_timer);
        
        Global.Player.IsCharge = true;

        Global.Player.OnCharging += () =>
        {
            if (!_timer.IsStopped()) return;
            _timer.Start();
            _focusVfx = _focusVfxScene.Instantiate<FocusParticles>();
            Target.AddChild(_focusVfx);
            _focusVfx.OneShot = false;
            _focusVfx.Play();
        };

        Global.Player.OnStopCharging += () =>
        {
            _timer.Stop();
            _focusVfx.QueueFree();
            _count = 0;
            Shoot();
        };
        
        _accelerationMod.Value = Values[0];
        AddModifierToTarget(_damageMod, Target.Stats.Damage);
        AddModifierToTarget(_bulletSpeedMod, Target.Stats.BulletSpeed);
        AddModifierToTarget(_bulletSizeMod, Target.Stats.BulletSize);
        AddModifierToTarget(_blastRadiusMod, Target.Stats.BlastRadius);
        AddModifierToTarget(_accelerationMod, Target.Stats.Acceleration);
    }

    private void Enhance()
    {
        Logger.Log("[ChargedShot] Enhance");
        _damageMod.Value = Mathf.Min(_damageMod.Value + 0.2f, 1f);
        _bulletSpeedMod.Value = Mathf.Min(_bulletSpeedMod.Value + 0.2f, 1f);
        _bulletSizeMod.Value = Mathf.Min(_bulletSizeMod.Value + 0.2f, 1f);
        _blastRadiusMod.Value = Mathf.Min(_blastRadiusMod.Value + 0.2f, 1f);
    }

    private void Shoot()
    {
        Global.Player.Shoot();
        
        _damageMod.Value = 0f;
        _bulletSpeedMod.Value = 0f;
        _bulletSizeMod.Value = 0f;
        _blastRadiusMod.Value = 0f;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Global.Player.IsCharge = false;
    }
}