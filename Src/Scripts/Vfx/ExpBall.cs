using Godot;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class ExpBall : BaseVfx
{
    public Vector2 Pos;
    
    public override void _Ready()
    {
        base._Ready();
        GlobalPosition = Pos;
        this.TweenGlobalPosition(Global.Player.GlobalPosition, 0.2f)
            .OnComplete(() =>
            {
                Global.Player.Stats.Exp.Increase(1);
                OnAnimationEnd?.Invoke();
            })
            .Play();
    }
}
