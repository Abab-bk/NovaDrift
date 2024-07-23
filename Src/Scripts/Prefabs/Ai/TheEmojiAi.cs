using Godot;
using System;
using AcidWallStudio.AcidUtilities;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.BulletPatterns;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class TheEmojiAi : MobAiComponent, IBossAiHelper
{
    [Export] private Sprite2D _sprite;
    [Export] private Timer _timer;
    [Export] private Timer _nextTimer;

    private Texture2D _angerTexture;
    private Texture2D _nerdTexture;
    private Texture2D _dizzyTexture;
    private Texture2D _pickTexture;

    private readonly CirclePattern _circlePattern = new ();
    
    public override void _Ready()
    {
        base._Ready();
        Mob.IsBoss = true;
        Mob.Tags.Add(Constants.Tags.IsDisabledRotation);
        
        Mob.Shooter.GetBulletFunc = _ => new BulletBuilder(BulletBuilder.BulletType.Shit)
            .SetOwner(Mob)
            .SetIsPlayer(Mob.IsPlayer)
            .SetDamage(Mob.Stats.Damage.Value)
            .SetSpeed(Mob.Stats.BulletSpeed.Value)
            .SetSize(Mob.Stats.BulletSize.Value)
            .SetDegeneration(Mob.Stats.BulletDegeneration.Value)
            .SetSteering(Mob.Stats.Targeting.Value)
            .Build();
        
        _angerTexture = GD.Load<Texture2D>("res://Assets/Textures/Mobs/TheEmojiAnger.png");
        _nerdTexture = GD.Load<Texture2D>("res://Assets/Textures/Mobs/TheEmojiNerd.png");
        _dizzyTexture = GD.Load<Texture2D>("res://Assets/Textures/Mobs/TheEmojiDizzy.png");
        _pickTexture = GD.Load<Texture2D>("res://Assets/Textures/Mobs/TheEmoji.png");
        
        _timer.Timeout += () =>
        {
            switch (Random.Shared.Next(0, 3))
            {
                case 0:
                    Machine.SetTrigger("ToAnger");
                    break;
                case 1:
                    Machine.SetTrigger("ToNerd");
                    break;
                case 2:
                    Machine.SetTrigger("ToDizzy");
                    break;
                default:
                    _sprite.Texture = _pickTexture;
                    break;
            }
        };

        _nextTimer.Timeout += () =>
        {
            Machine.SetTrigger("Next");
        };
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Anger":
                _sprite.Texture = _angerTexture;
                SetNextTimer(Random.Shared.FloatRange(2f, 4f));
                break;
            case "Nerd":
                _sprite.Texture = _nerdTexture;
                SetNextTimer(Random.Shared.FloatRange(2f, 4f));
                break;
            case "Dizzy":
                _sprite.Texture = _dizzyTexture;
                SetNextTimer(Random.Shared.FloatRange(2f, 4f));
                break;
            case "Pick":
                _sprite.Texture = _pickTexture;
                _timer.WaitTime = Random.Shared.FloatRange(2f, 4f);
                _timer.Start();
                break;
        }
    }

    private void SetNextTimer(float waitTime)
    {
        _nextTimer.WaitTime = waitTime;
        _nextTimer.Start();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Anger":
                Mob.Shooter.ShootWithConfig(_circlePattern, 10);
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
            case "Nerd":
                Mob.Shoot();
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
            case "Dizzy":
                Mob.Rotation += 1f;
                Mob.Shoot();
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
            case "Pick":
                Mob.SetTargetAndMove(Global.Player, delta);
                break;
        }
    }

    protected override void ConnectExitedSignals(State state)
    {
        base.ConnectExitedSignals(state);
        switch (state.GetName())
        {
            case "Dizzy":
                Mob.Rotation = 0f;
                break;
        }
    }
}
