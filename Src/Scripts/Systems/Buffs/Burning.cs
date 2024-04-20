using Godot;

namespace NovaDrift.Scripts.Systems.Buffs;

public class Burning : Buff
{
    protected override void Process()
    {
        Target.Stats.Health.Decrease(Values[0]);
    }
}