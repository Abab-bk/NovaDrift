using Godot;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts.Prefabs.Weapons;

public partial class Sword : Shooter
{
    private Node2D _sword1;
    private Node2D _sword2;

    protected override void Init()
    {
        _sword1 = GetNode<Node2D>("%Sword1");
        _sword1 = GetNode<Node2D>("%Sword2");

        GetNode<HitBox>("%HitBox1").SetIsPlayer(IsPlayer);
        GetNode<HitBox>("%HitBox2").SetIsPlayer(IsPlayer);
        
        ShootTimer.Timeout += Run;
        Run();
    }

    private async void Run()
    {
        if (!ShootTimer.IsStopped())
        {
            return;
        }

        Tween tw = CreateTween();
        tw.TweenProperty(this, "rotation_degrees", Rotation == 0 ? 360 : 0, 0.5f);
        await ToSignal(tw, Tween.SignalName.Finished);
        ShootTimer.Start();
    }

    public override void Shoot()
    {
        
    }
}
