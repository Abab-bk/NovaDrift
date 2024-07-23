using Godot;
using System;

namespace NovaDrift.Scripts.Prefabs;

public partial class DestroyArea : Area2D
{
    public override void _Ready()
    {
        base._Ready();
        BodyEntered += body =>
        {
            if (body is not BulletBase bullet) return;
            bullet.Release();
        };
    }
}
