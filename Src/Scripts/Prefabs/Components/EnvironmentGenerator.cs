using System;
using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class EnvironmentGenerator : Node2D
{
    [Export] private Node2D _parallaxBackground;
    
    private Timer _timer;
    
    enum SpawnType
    {
        Star,
        Nebula,
    }

    public override void _Ready()
    {
        _timer = new Timer
        {
            WaitTime = 10f,
            OneShot = false
        };
        
        AddChild(_timer);
        _timer.Start();

        _timer.Timeout += () =>
        {
            Generate(Random.Shared.GetRandomEnum<SpawnType>());
        };

        Generate(Random.Shared.GetRandomEnum<SpawnType>());
        Generate(Random.Shared.GetRandomEnum<SpawnType>());
        Generate(Random.Shared.GetRandomEnum<SpawnType>());
    }
    
    private void Generate(SpawnType type)
    {
        var newParallaxLayer = GetNewParallaxLayer();
        _parallaxBackground.AddChild(newParallaxLayer);
        newParallaxLayer.AddChild(GetNewSprite(type));
    }

    private Parallax2D GetNewParallaxLayer()
    {
        var newParallaxLayer = new Parallax2D();
        newParallaxLayer.Autoscroll = new Vector2(100, 100);
        return newParallaxLayer;
    }
    
    private Sprite2D GetNewSprite(SpawnType type)
    {
        Sprite2D newSprite = new Sprite2D();

        GD.Print(Wizard.GetRandomTexturePath("res://Assets/Textures/Backgrounds/Stars/"));
        
        switch (type)
        {
            case SpawnType.Star:
                newSprite.Texture = GD.Load<AtlasTexture>(Wizard.GetRandomTexturePath("res://Assets/Textures/Backgrounds/Stars/"));
                break;
            case SpawnType.Nebula:
                newSprite.Texture = GD.Load<AtlasTexture>(Wizard.GetRandomTexturePath("res://Assets/Textures/Backgrounds/Nebulas/"));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        return newSprite;
    }
}