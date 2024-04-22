namespace NovaDrift.Scripts.Systems.Effects;

public class IncendiaryStrike : Effect
{
    public override void OnCreate()
    {
        Target.OnShoot += bullet =>
        {
            bullet.OnHit += actor =>
            {
                actor.Stats.AddBuff(DataBuilder.BuildBuffById(1001));
            };
        };
    }
}