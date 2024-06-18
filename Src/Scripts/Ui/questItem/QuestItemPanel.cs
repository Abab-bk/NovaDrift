using Godot;
using NovaDrift.Scripts.Systems.QuestSystem;

namespace NovaDrift.Scripts.Ui.QuestItem;

public partial class QuestItemPanel : QuestItem
{
    public Quest Quest;

    public override void _Ready()
    {
        base._Ready();
        S_Title.Instance.Text = Quest.Name;
        S_ProgressBar.Instance.Value = Quest.GetProgress();
    }

    public override void OnCreateUi()
    {
    }

    public override void OnDestroyUi()
    {
    }

}
