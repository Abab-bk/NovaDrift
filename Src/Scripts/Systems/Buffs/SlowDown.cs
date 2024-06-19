namespace NovaDrift.Scripts.Systems.Buffs;

public class SlowDown : Buff
{
    protected override void Process()
    {
        base.Process();
        Target.Velocity /= Values[0];
    }
}