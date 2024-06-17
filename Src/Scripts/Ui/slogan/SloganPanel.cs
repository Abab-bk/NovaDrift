namespace NovaDrift.Scripts.Ui.Slogan;

public partial class SloganPanel : Slogan
{
    public override void _Ready()
    {
        L_AnimationPlayer.Instance.AnimationFinished += _ => { QueueFree(); };
    }
    
    public override void OnCreateUi()
    {
        
    }

    public override void OnDestroyUi()
    {
        
    }

}
