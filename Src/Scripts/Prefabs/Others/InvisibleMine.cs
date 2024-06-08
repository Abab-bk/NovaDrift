using NovaDrift.Scripts.Prefabs.Actors;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class InvisibleMine : Mine
{
    protected override void ConnectMonitorArea()
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        foreach (var body in MonitorArea.GetOverlappingBodies())
        {
            if (IsPlayer)
            {
                if (body is not MobBase mobBase) return;
                mobBase.TakeDamage(Damage);
                return;
            }
            if (body is not Player player) return;
            player.TakeDamage(Damage);
        }
    }
}
