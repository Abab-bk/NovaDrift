using Godot;

namespace NovaDrift.Scripts.Ui.SalvoBulletCount;

public partial class SalvoBulletCountPanel : SalvoBulletCount
{

    public override void OnCreateUi()
    {
        
    }

    public void UpdateUi(int bulletCount)
    {
        L_Label.Instance.Text = bulletCount.ToString();
    }

    public override void OnDestroyUi()
    {
        
    }

}
