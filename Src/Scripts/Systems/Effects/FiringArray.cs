using Godot;

namespace NovaDrift.Scripts.Systems.Effects;

public class FiringArray : Effect
{
    private int _count;
    
    public override void OnCreate()
    {
        Global.Player.OnShoot += @base =>
        {
            if (_count >= (int)Values[0])
            {
                for (int i = 0; i < Values[1]; i++)
                {
                    var bullet = Global.Player.Shooter.GetBulletFunc.Invoke(Global.Player.Shooter);
                
                    bullet.GlobalPosition = Global.Player.GlobalPosition;
                    
                    float arcRad = Mathf.DegToRad(Global.Player.Stats.ShootSpread.Value);
                    float increment = arcRad / (Global.Player.Stats.BulletCount.Value - 1);
                    bullet.Direction = bullet.Direction.Rotated(Global.Player.GlobalRotation + increment * i - arcRad / 2);

                    Global.GameWorld.AddChild(bullet);
                
                    bullet.OnHit += actor => { Global.Player.Shooter.OnHit?.Invoke(actor); };
                    _count = 0;
                }
                return;
            }

            _count += 1;
        };
    }
}