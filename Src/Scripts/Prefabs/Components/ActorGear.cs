using Godot;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class ActorGear : Node2D
{
    [Export] public Sprite2D ActorSprite;
    [Export] public Actor Actor;

    public Shooter Shooter;

    private CharacterStats _stats;
    
    public override void _Ready()
    {
        Shooter = GetChild<Shooter>(0);
        Shooter.Actor = Actor;
        
        _stats = Actor.Stats;

        _stats.OnBodyChanged += UpdateSprite;
    }
    
    private void UpdateSprite()
    {
    }
    
}