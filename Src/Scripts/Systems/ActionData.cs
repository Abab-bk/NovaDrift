namespace NovaDrift.Scripts.Systems;

public class ActionData(float preparationTime, float duration, float recoveryTime)
{
    public float Duration = preparationTime;
    public float PreparationTime = duration;
    public float RecoveryTime = recoveryTime;
}