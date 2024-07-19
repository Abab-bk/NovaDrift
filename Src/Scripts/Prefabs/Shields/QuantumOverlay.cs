using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Shields;

public partial class QuantumOverlay : BaseShield
{
    protected override void OnHurt(float value, Node2D node2D)
    {
        if (Wizard.GetChance() > Values[0]) return;
        base.OnHurt(value * Values[1], node2D);
    }
    
    public override void SetPlayerColor()
    {
        base.SetPlayerColor();
        Global.GameContext.SetPlayerColor(new Color("fff4a3"));
    }
}
