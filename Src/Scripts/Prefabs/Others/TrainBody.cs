using Godot;
using System;
using AcidWallStudio.AcidUtilities;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Vfx;

namespace NovaDrift.Scripts.Prefabs.Others;

public partial class TrainBody : Node2D
{
    public float Health;
    
    public event Action OnDead;
    
    private PureHurtBox _pureHurtBox;
    private HitBox _hitBox;
    
    public override void _Ready()
    {
        _pureHurtBox = GetNode<PureHurtBox>("PureHurtBox");
        _hitBox = GetNode<HitBox>("HitBox");
        
        _hitBox.Damage = 10f;
        _pureHurtBox.OnHurt += (f, _) =>
        {
            Health -= f;
            if (Health > 0) return;
            
            switch (Random.Shared.Next(0, 3))
            {
                case 0:
                    // Nothing
                    break;
                case 1:
                    // ExpBall
                    var count = Random.Shared.Next(5, 11);
                        
                    var temp = new Vector2(10f, 10f);
                    for (int i = 0; i < count; i++)
                    {
                        var expBall = GD.Load<PackedScene>("res://Scenes/Vfx/ExpBall.tscn").Instantiate<ExpBall>();
                        expBall.Pos = GlobalPosition + temp * i;
                        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, expBall);
                    }
                        
                    break;
                case 2:
                    // PowerUp
                    var powerTemp = new Vector2(10f, 10f);
                    for (int i = 0; i < 1; i++)
                    {
                        var powerUp = GD.Load<PackedScene>("res://Scenes/Prefabs/Others/PowerUpEntity.tscn")
                            .Instantiate<PowerUpEntity>();
                        powerUp.PowerUp = DataBuilder.BuildPowerUpById(DataBuilder.Tables.TbPowertUpInfo.DataMap.Keys.PickRandom());
                        powerUp.GlobalPosition = GlobalPosition + powerTemp * i;
                        Global.GameWorld.CallDeferred(Node.MethodName.AddChild, powerUp);
                    }
                    break;
            }
                
            OnDead?.Invoke();
            QueueFree();
        };
    }
}
