using AcidWallStudio.SpringSystem;
using Godot;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    [Export] private Sprite2D _source;
    [Export] private Sprite2D _target;
    [Export] Spring _sourceSpring;
    [Export] Spring _targetSpring;
    
    public override void _Ready()
    {
        _sourceSpring.AddTargetPoint(new SpringInfo(SpringType.Push, _target, 1f));
        // _targetSpring.AddTargetPoint(new SpringInfo(SpringType.Push, _source, 1f));
        QueueRedraw();
    }

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, 100f, Colors.Red);
    }
}
