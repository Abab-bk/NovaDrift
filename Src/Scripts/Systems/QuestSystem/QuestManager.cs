using System;
using System.Collections.Generic;

namespace NovaDrift.Scripts.Systems.QuestSystem;

public static class QuestManager
{
    public static List<Quest> Quests = new List<Quest>();
    
    public static void GenerateQuests(int count)
    {
        for (int i = 0; i < count; i++)
        {
            AddQuest(
                new Quest(
                    Random.Shared.Next(10, 20),
                    new Reward(Reward.RewardType.Coins, 10),
                    Quest.QuestType.KillEnemy
                    )
                );
        }
    }
    
    public static void AddQuest(Quest quest)
    {
        Quests.Add(quest);
        quest.Init();
    }
    
    public static void RemoveQuest(Quest quest)
    {
        Quests.Remove(quest);
    }
}