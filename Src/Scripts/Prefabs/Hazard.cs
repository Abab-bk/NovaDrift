using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs;


public abstract partial class Hazard : Node2D
{
    [Export] private float _damage;
    [Export] private float _scale = 1f;
    [Export] private HitBox _hitBox;
    
    public override void _Ready()
    {
        _hitBox.Damage = _damage * _scale;
        _hitBox.SetIsPlayer(false);
    }
}
