using Godot;

namespace NovaDrift.Scripts.Ui.GameOver;

public partial class GameOverPanel : GameOver
{

    public override void OnCreateUi()
    {
        S_ReStartBtn.Instance.Pressed += () =>
        {
            Global.OnGameInit?.Invoke();
            Destroy();
        };
    }

    public override void OnDestroyUi()
    {
        
    }

}
