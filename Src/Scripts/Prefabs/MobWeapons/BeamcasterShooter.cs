using Godot;
using NovaDrift.Scripts.Prefabs.Weapons;

namespace NovaDrift.Scripts.Prefabs.MobWeapons;

public partial class BeamcasterShooter : BaseShooter
{
    private Timer _timer;
    
    public override void Destroy()
    {
    }

    public override void Shoot()
    {
        
    }

    public override void Init()
    {
        SetDefaultCooldownTimer(1f);
    }
}