using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Pendulum : BaseShooter
{
    private PendulumHead _pendulumHead;
    
    public override void Init()
    {
        _pendulumHead = GetNode<PendulumHead>("%PendulumHead");
    }

    public override void Shoot()
    {
    }

    public override void Destroy()
    {
    }
}
