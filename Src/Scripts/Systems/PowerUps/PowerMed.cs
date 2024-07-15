namespace NovaDrift.Scripts.Systems.PowerUps;

public class PowerMed : PowerUp
{
    public override void Use()
    {
        base.Use();
        Global.Player.Stats.Health.Increase(Global.Player.Stats.Health.MaxValue.Value * 0.2f);
        Global.Player.Shield.Health.Increase(Global.Player.Stats.MaxShield.Value * 0.2f);
    }
}