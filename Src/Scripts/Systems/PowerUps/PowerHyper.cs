using Godot;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerHyper : PowerUp
{
    private Timer _timer;

    private StatModifier _modifier;
    
    public override void Use()
    {
        base.Use();

        _modifier = new StatModifier(0.33f, StatModType.PercentAdd, this);
        
        Global.Player.Stats.Acceleration.AddModifier(_modifier);
        Global.Player.Stats.ShootSpeed.AddModifier(_modifier);
        Global.Player.Stats.Regeneration.AddModifier(_modifier);
        
        _timer = new Timer();
        Global.Player.AddChild(_timer);
        _timer.Timeout += Destroy;
    }

    public override void Destroy()
    {
        base.Destroy();
        Global.Player.Stats.Acceleration.RemoveAllModifiersFromSource(this);
        Global.Player.Stats.ShootSpeed.RemoveAllModifiersFromSource(this);
        Global.Player.Stats.Regeneration.RemoveAllModifiersFromSource(this);
        _timer.QueueFree();
    }
}