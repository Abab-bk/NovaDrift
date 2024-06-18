using System;

namespace NovaDrift.Scripts.Systems.QuestSystem;

public class Quest(int targetValue, Reward reward, Quest.QuestType type)
{
    public event Action OnFinish;
    
    public enum QuestType
    {
        KillEnemy,
    }
    
    public int CurrentValue;
    public int TargetValue = targetValue;
    
    public Reward Reward = reward;
    
    public string Name;
    public bool IsDone;
    public QuestType Type = type;
    
    public void Init()
    {
        switch (Type)
        {
            case QuestType.KillEnemy:
                EventBus.OnMobDied += _ => CurrentValue += 1;
                Name = $"击杀 {TargetValue} 个敌人";
                break;
        }
    }
    
    public void AddValue(int value)
    {
        CurrentValue += value;
        if (CurrentValue >= TargetValue)
        {
            Finish();
        }
    }
    
    public void Finish()
    {
        Reward.GetReward();
        IsDone = true;
        OnFinish?.Invoke();
    }
    
    public float GetProgress()
    {
        return ((float)CurrentValue / TargetValue) * 100f;
    }
}