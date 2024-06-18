namespace NovaDrift.Scripts.Systems;

public class Reward(Reward.RewardType type, int value)
{
    public enum RewardType
    {
        Coins,
    }
    
    public int Value = value;
    public RewardType Type = type;
    
    public void GetReward()
    {
        switch (Type)
        {
            case RewardType.Coins:
                Global.AcidCoins += Value;
                break;
        }
    }
}