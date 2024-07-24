using Godot;
using System;
using NovaDrift.Scripts.Prefabs.Others;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Pendulum : BaseShooter
{
    [Export] private Marker2D _tailMarker;
    [Export] private Node2D _rope;
    // private PendulumHead _pendulumHead;
    
    public override void Init()
    {
        // _pendulumHead = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/PendulumHead.tscn")
        //     .Instantiate<PendulumHead>();
        // Actor.AddChild(_pendulumHead);
        // _pendulumHead.GlobalPosition = _tailMarker.GlobalPosition;
        // _pendulumHead.SetRopePath(_rope.GetPath());
    }

    public override void Shoot()
    {
    }

    public override void Destroy()
    {
    }
}
