using Godot;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    [Export] private Shooter _shooter;
    [Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
    
    public CharacterStats Stats = new CharacterStats();
    protected float ShootCd = 1f;
    
    public override void _Ready()
    {
        InitStats();
        _visibleOnScreenNotifier2D.ScreenExited += MoveToWorldEdge;
    }

    private void MoveToWorldEdge()
    {
        Vector2 newPos = GlobalPosition;
        if (GlobalPosition.X < 0)
        {
            newPos.X = 2560;
        }

        if (GlobalPosition.X > 2560)
        {
            newPos.X = 0;
        }
        
        if (GlobalPosition.Y < 0)
        {
            newPos.Y = 1440;
        }
        
        if (GlobalPosition.Y > 1440)
        {
            newPos.Y = 0;
        }

        GlobalPosition = newPos;
    }

    protected virtual void InitStats()
    {
    }

    protected virtual void Shoot(Vector2 targetDir)
    {
        _shooter.Shoot(targetDir);
    }
    
}
