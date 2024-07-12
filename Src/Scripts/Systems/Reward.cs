using System;

namespace NovaDrift.Scripts.Systems;

public class Reward(Reward.RewardType type, int value)
{
    public enum RewardType
    {
        Coins,
    }
    
    public int Value = value;
    public RewardType Type = type;
    
    public string GetReward()
    {
        var tip = "";
        
        switch (Type)
        {
            case RewardType.Coins:
                Global.AcidCoins += Value;
                tip = $"获得 {Value} 酸酸币";
                break;
        }

        return tip;
    }

    /// <summary>
    /// 解析 content 为 Reward。
    /// content 格式：
    /// 类型-值-过期日期-用户ID
    /// 过期日期可为：None
    /// 用户ID可为：None
    /// </summary>
    /// <param name="content"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool ParseReward(string content, out Reward result)
    {
        bool Break(out Reward reward)
        {
            reward = new Reward(RewardType.Coins, 10);
            return false;
        }

        var parts = content.Split("-");

        if (parts.Length != 4) return Break(out result);
        
        result = new Reward(RewardType.Coins, 10);

        var type = parts[0];
        var value = parts[1];
        var date = parts[2];
        var userId = parts[3];

        switch (type)
        {
            case "coins":
                result.Type = RewardType.Coins;
                break;
            default:
                return Break(out result);
        }

        result.Value = Int32.Parse(value);

        if (date != "None")
        {
        }
        
        if (userId != "None")
        {
        }
        
        return true;
    }
}