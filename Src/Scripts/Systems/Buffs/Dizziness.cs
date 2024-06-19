using Godot;

namespace NovaDrift.Scripts.Systems.Buffs;

public class Dizziness : Buff
{
    protected override void Process()
    {
        base.Process();
        Target.Velocity = Vector2.Zero;
    }
}