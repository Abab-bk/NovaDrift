using Godot;
using System;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class PendulumHead : Node2D
{
    private Node _ropeHandle;

    public override void _Ready()
    {
        base._Ready();
        _ropeHandle = GetNode<Node>("RopeHandle");
    }

    public void SetRopePath(NodePath ropePath)
    {
        _ropeHandle.Call("set_rope_path", ropePath);
        _ropeHandle.Call("set_enable", true);
    }
}
