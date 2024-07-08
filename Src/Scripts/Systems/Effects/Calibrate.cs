using Godot;

namespace NovaDrift.Scripts.Systems.Effects;

public class Calibrate : Effect
{
    private int _count;
    
    public override void OnCreate()
    {
        Global.Player.OnShoot += @base =>
        {
            if (_count >= (int)Values[0])
            {
                var bullet = Global.Player.Shooter.GetBulletFunc.Invoke(Global.Player.Shooter);
                
                bullet.GlobalPosition = Global.Player.GlobalPosition;
                bullet.Direction = bullet.Direction
                    .Rotated(Global.Player.GlobalRotation)
                    .Rotated(Mathf.DegToRad(180f));

                Global.GameWorld.AddChild(bullet);
                
                Global.Player.OnShoot?.Invoke(bullet);
                bullet.OnHit += actor => { Global.Player.Shooter.OnHit?.Invoke(actor); };
                _count = 0;
                return;
            }

            _count += 1;
        };
    }
}