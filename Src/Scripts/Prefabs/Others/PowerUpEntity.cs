using DsUi;
using Godot;
using NovaDrift.Scripts.Systems.PowerUps;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class PowerUpEntity : Node2D
{
    [GetNode("Sprite2D")] private Sprite2D _sprite;
    [GetNode("Timer")] private Timer _timer;
    
    public PowerUp PowerUp;

    private static int _currentPowerUpCount = 0;
    
    public override void _Ready()
    {
        _timer.Timeout += QueueFree;
        _sprite.Texture = GD
            .Load<Texture2D>($"res://Assets/Ui/Icons/PowerUpsIcon/{PowerUp.PowerUpInfo.IconName}.png");
        _timer.Start();
    }

    public void Get()
    {
        if (_currentPowerUpCount >= PlayerGrowth.MaxPowerUpCount)
        {
            UiManager.Open_Tip().Text = "超能力数量达到上限！";
            return;
        }

        _currentPowerUpCount++;
        EventBus.OnPlayerGetPowerUp?.Invoke(PowerUp);
        QueueFree();
    }
}
