using Godot;
using System;
using NovaDrift.Scripts.Prefabs;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class TheEmojiAi : MobAiComponent
{
    [Export] private Sprite2D _sprite;
    [Export] private Timer _timer;

    private Texture2D _angerTexture;
    private Texture2D _nerdTexture;
    private Texture2D _dizzyTexture;
    private Texture2D _pickTexture;

    public override void _Ready()
    {
        base._Ready();
        Mob.IsBoss = true;
        Mob.Tags.Add(Constants.Tags.IsDisabledRotation);
        
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
    }

    protected override void ConnectEnteredSignals(State state)
    {
        base.ConnectEnteredSignals(state);
        switch (state.GetName())
        {
            case "Anger":
                _sprite.Texture = _angerTexture;
                break;
            case "Nerd":
                _sprite.Texture = _nerdTexture;
                break;
            case "Dizzy":
                _sprite.Texture = _dizzyTexture;
                break;
            case "Pick":
                _sprite.Texture = _pickTexture;
                _timer.Start();
                break;
        }
    }
}
