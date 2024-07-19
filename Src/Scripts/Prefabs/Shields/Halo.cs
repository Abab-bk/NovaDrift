using Godot;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class Halo : BaseShield
{
    private Timer _haloTimer;
    
    public override void _Ready()
    {
        base._Ready();
        _haloTimer = new Timer
        {
            WaitTime = 1,
            OneShot = false,
        };
        
        AddChild(_haloTimer);
        _haloTimer.Start();

        _haloTimer.Timeout += () =>
        {
            foreach (var body in ShieldArea.GetOverlappingBodies())
            {
                if (body is not Actor actor) return;
                actor.TakeDamageWithoutKnockBack(Values[0]);
                Target.TakeDamageWithoutKnockBack(Values[0] * 0.01f);
            }
        };
    }

    public override void SetPlayerColor()
    {
        base.SetPlayerColor();
        Global.GameContext.SetPlayerColor(new Color("ffa3a5"));
    }
}
