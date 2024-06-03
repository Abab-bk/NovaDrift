using Godot;

namespace NovaDrift.Scripts.Ui.Loading;

public partial class LoadingPanel : Loading
{
    [GetNode("%ProgressBar")] private ProgressBar _progressBar;
    
    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
