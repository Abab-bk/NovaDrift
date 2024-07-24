using Godot;
using NovaDrift.Scripts.Systems.PowerUps;

namespace NovaDrift.Scripts.Ui.PowerUpBtn;

public partial class PowerUpBtnPanel : PowerUpBtn
{
    public PowerUp PowerUp;

    public override void _Ready()
    {

    }

    public void UpdateUi(PowerUp powerUp)
    {
        PowerUp = powerUp;
        L_Icon.Instance.Texture = GD
            .Load<Texture2D>($"res://Assets/Ui/Icons/PowerUpsIcon/{PowerUp.PowerUpInfo.IconName}.png");
        L_TouchScreenButton.Instance.Pressed += () =>
        {
            L_Icon.Instance.Modulate = new Color("#ababab");
            PowerUp.Use();
            Destroy();
        };
    }

    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
