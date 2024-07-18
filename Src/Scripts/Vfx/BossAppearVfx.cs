using Godot;
using System;
using GTweens.Builders;
using GTweens.Easings;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class BossAppearVfx : Node2D
{
    public event Action OnAnimationEnd;
    
    [GetNode("%OriginSprite")] private Sprite2D _originSprite;
    [GetNode("%YellowSprite")] private Sprite2D _yellowSprite;
    [GetNode("%RedSprite")] private Sprite2D _redSprite;
    [GetNode("%BlueSprite")] private Sprite2D _blueSprite;
    [GetNode("%Name")] private Control _name;
    [GetNode("%NameLabel")] private Label _nameLabel;
    [GetNode("%NameLabel2")] private Label _nameLabel2;
    [GetNode("%Sprites")] private Node2D _sprites;
    [GetNode("%DragonBones")] private Node2D _dragonBones;

    public string Title = "The Knight";
    public string IconPath = "res://Assets/Textures/Mobs/TheKnight.png";
    public string DragonPath = "";
    
    public override void _Ready()
    {
        _nameLabel.Text = Title;
        _nameLabel2.Text = Title;

        if (DragonPath != "")
        {
            _sprites.Hide();
            _dragonBones.Set("factory", GD.Load(DragonPath));
        }
        else
        {
            _originSprite.Texture = GD.Load<Texture2D>(IconPath);
            _yellowSprite.Texture = _originSprite.Texture;
            _redSprite.Texture = _originSprite.Texture;
            _blueSprite.Texture = _originSprite.Texture;
        }

        _name.Position = new Vector2(3145f, 974f);
        _sprites.Position = new Vector2(-340f, 550f);
        _dragonBones.Position = new Vector2(-340f, 874f);
        
        _yellowSprite.Position = _originSprite.Position;
        _redSprite.Position = _originSprite.Position;
        _blueSprite.Position = _originSprite.Position;
        
        // Global.Shake(10f);
        
        GTweenSequenceBuilder.New()
            .Append(_sprites.TweenPositionX(1280f, 0.5f))
                .Join(_name.TweenPositionX(1280f, 0.5f))
                .Join(_dragonBones.TweenPositionX(1280f, 0.5f))
            
            .Append(_yellowSprite.TweenPositionX(50f, 0.2f))
            .Append(_redSprite.TweenPositionX(100f, 0.2f))
            .Append(_blueSprite.TweenPositionX(150f, 0.2f))
            
            .AppendTime(1f)
            .AppendCallback(() =>
            {
                OnAnimationEnd?.Invoke();
                QueueFree();
            })
            .Build()
            .SetEasing(Easing.OutCubic)
            .PlayUnpausable();
    }
}
