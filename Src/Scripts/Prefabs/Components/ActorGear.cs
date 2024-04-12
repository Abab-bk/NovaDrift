using Godot;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Components;

[GlobalClass]
public partial class ActorGear : Node
{
    [Export] public Sprite2D ActorSprite;
    [Export] public Shooter Shooter;
    [Export] public Actor Actor;

    private CharacterStats _stats;
    
    public override void _Ready()
    {
        _stats = Actor.Stats;

        _stats.OnBodyChanged += UpdateSprite;
    }
    
    private void UpdateSprite()
    {
    }
    
}