using Godot;
using NovaDrift.Scripts.Systems.PowerUps;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class PowerUpEntity : Node2D
{
    [GetNode("Sprite2D")] private Sprite2D _sprite;
    [GetNode("Timer")] private Timer _timer;
    
    public PowerUp PowerUp;

    public override void _Ready()
    {
        _timer.Timeout += QueueFree;
        _sprite.Texture = GD
            .Load<Texture2D>($"res://Assets/Ui/Icons/PowerUpsIcon/{PowerUp.PowerUpInfo.IconName}.png");
        _timer.Start();
    }

    public void Get()
    {
        EventBus.OnPlayerGetPowerUp?.Invoke(PowerUp);
        QueueFree();
    }
}
