using Godot;
using NovaDrift.Scripts.Systems.PowerUps;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class PowerUpEntity : Node2D
{
    [GetNode("Sprite2D")] private Sprite2D _sprite;
    
    public PowerUp PowerUp;

    public override void _Ready()
    {
        _sprite.Texture = GD
            .Load<Texture2D>($"res://Assets/Ui/Icons/PowerUpsIcon/{PowerUp.PowerUpInfo.IconName}.png");
    }

    public void Get()
    {
        EventBus.OnPlayerGetPowerUp?.Invoke(PowerUp);
        QueueFree();
    }
}
