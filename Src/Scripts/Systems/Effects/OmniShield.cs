namespace NovaDrift.Scripts.Systems.Effects;

public class OmniShield : Effect
{
    public override void OnCreate()
    {
        base.OnCreate();
        AddModifierToTarget(DataBuilder.BuildFlatModifier(Values[0]), Target.Stats.MaxShield);
        
    }
}