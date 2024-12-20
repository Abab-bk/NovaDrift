using Godot;
using GTweens.Builders;
using GTweensGodot.Extensions;

namespace NovaDrift.Scripts.Vfx;

public partial class RectDangerZoneIndicator : BaseVfx
{
    [GetNode("%Area2D")] public Area2D Area2D;
    public Vector2 Size;

    public void RulePosition()
    {
        GlobalPosition = new Vector2(
            GlobalPosition.X == 0 ? (Scale * 100f / 2).X : GlobalPosition.X,
            GlobalPosition.Y == 0 ? (Scale * 100f / 2).Y : GlobalPosition.Y
            );
    }

    public override void _Ready()
    {
        Area2D.SetIsPlayer(IsPlayer);

        Scale = Size / 100f;
        
        // RED: f8000033 White: ffffff33
        Modulate = new Color("ffffff00");
        
        GTweenSequenceBuilder.New()
            .Append(this.TweenModulate(new Color("ffffff33"), ActionData.PreparationTime))
            .Append(this.TweenModulate(new Color("f8000033"), ActionData.Duration))
            .Append(this.TweenModulate(new Color("ffffff33"), ActionData.RecoveryTime).OnComplete(() => OnAnimationEnd?.Invoke()))
            .Append(this.TweenModulateAlpha(0f, 0.5f))
            .AppendCallback(QueueFree)
            .Build()
            .Play();
    }
}
