using System.Linq;
using DsUi;
using Godot;
using NovaDrift.Scripts.Systems.QuestSystem;
using NovaDrift.Scripts.Ui.QuestItem;

namespace NovaDrift.Scripts.Ui.DailyQuests;

public partial class DailyQuestsPanel : DailyQuests
{
    public override void _Ready()
    {
        base._Ready();
        QuestManager.GenerateQuests(10);

        S_FinishedContainer.Instance.Hide();
        S_UnfinishedContainer.Instance.Hide();
        
        foreach (var quest in QuestManager.Quests)
        {
            if (quest.IsDone)
            {
                S_FinishedContainer.Instance.Show();
                S_FinishedQuests.AddChild(CreateQuestItem(quest));
                continue;
            }
            S_UnfinishedContainer.Instance.Show();
            S_UnfinishedQuests.AddChild(CreateQuestItem(quest));
        }
        
        S_CloseBtn.Instance.Pressed += () =>
        {
            this.ChangeTo(UiManager.Create_StartMenu());
        };
    }

    private QuestItemPanel CreateQuestItem(Quest quest)
    {
        var questItem = GD.Load<PackedScene>("res://Scenes/Ui/QuestItem.tscn").Instantiate<QuestItemPanel>();
        questItem.Quest = quest;
        return questItem;
    }

    public override void OnCreateUi()
    {
    }

    public override void OnDestroyUi()
    {
        
    }

}
